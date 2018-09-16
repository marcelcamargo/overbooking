using Overbooking.Compartilhado.Implementacoes;
using Overbooking.Compartilhado.Interfaces;
using Overbooking.Models;
using Overbooking.Negocio.Fabricas;
using System.Web.Mvc;

namespace Overbooking.Controllers
{
    public class IdadesController : ControladorPadraoParametroIndependente<IIdadeDoPassageiro>
    {
        public IdadesController()
        {
            _servicoGenerico = FabricaDeServicos.FabricaDeServicoDeIdade.Crie();
        }

        [HttpPost]
        public ActionResult Cadastrar(IdadeDoPassageiroModel idadeDoPassageiroView)
        {
            if (ModelState.IsValid)
            {
                var idadeDoPassageiro = CrieIdadeDoPassageiro(idadeDoPassageiroView);

                _servicoGenerico.Adicione(idadeDoPassageiro);

                return RedirectToAction("Index");
            }

            return View("Index", idadeDoPassageiroView);
        }

        private IIdadeDoPassageiro CrieIdadeDoPassageiro(IdadeDoPassageiroModel idadeDoPassageiroModel)
        {
            var idadeDoPassageiro = new IdadeDoPassageiro
            {
                Idade = idadeDoPassageiroModel.Idade.Value,
                ProbabilidadeDeComparecimento = idadeDoPassageiroModel.ProbabilidadeDeComparecimento.Value
            };

            return idadeDoPassageiro;
        }
    }
}