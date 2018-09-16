using Overbooking.Compartilhado.Fabricas;
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
        public ActionResult Cadastrar(IdadeDoPassageiroModel model)
        {
            if (ModelState.IsValid)
            {
                var idadeDoPassageiro = FabricaDeIdadeDoPassageiro.Crie(model.Idade.Value, model.ProbabilidadeDeComparecimento.Value);

                _servicoGenerico.Adicione(idadeDoPassageiro);

                return RedirectToAction("Index");
            }

            return View("Index", model);
        }

    }
}