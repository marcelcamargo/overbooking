using Overbooking.Compartilhado.Fabricas;
using Overbooking.Compartilhado.Interfaces;
using Overbooking.Models;
using Overbooking.Negocio.Fabricas;
using System;
using System.Web.Mvc;

namespace Overbooking.Controllers
{
    public class DatasDeSaidaController : ControladorPadraoParametroIndependente<IDataDeSaida>
    {
        public DatasDeSaidaController()
        {
            _servicoGenerico = FabricaDeServicos.FabricaDeServicoDeDataDeSaida.Crie();
        }

        [HttpPost]
        public ActionResult Salvar(DataDeSaidaModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dataDeSaida = FabricaDeDataDeSaida.Crie(model.Data.Value, model.ProbabilidadeDeComparecimento.Value);

                    _servicoGenerico.Salve(dataDeSaida);

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