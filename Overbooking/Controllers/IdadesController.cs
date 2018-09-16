using Overbooking.Compartilhado.Fabricas;
using Overbooking.Compartilhado.Interfaces;
using Overbooking.Models;
using Overbooking.Negocio.Fabricas;
using System;
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
        public ActionResult Salvar(IdadeDoPassageiroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idadeDoPassageiro = FabricaDeIdadeDoPassageiro.Crie(model.Idade.Value, model.ProbabilidadeDeComparecimento.Value);

                    _servicoGenerico.Salve(idadeDoPassageiro);

                    return RetorneViewIndex(null);
                }
                catch (Exception ex)
                {
                    return PartialView("Erro", ex.Message);
                }
            }

            return RetorneViewIndex(model);
        }

    }
}