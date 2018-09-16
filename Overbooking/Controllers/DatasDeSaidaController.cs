using Overbooking.Compartilhado.Fabricas;
using Overbooking.Compartilhado.Interfaces;
using Overbooking.Models;
using Overbooking.Negocio.Fabricas;
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
        public ActionResult Cadastrar(DataDeSaidaModel model)
        {
            if (ModelState.IsValid)
            {
                var dataDeSaida = FabricaDeDataDeSaida.Crie(model.Data.Value, model.ProbabilidadeDeComparecimento.Value);

                _servicoGenerico.Adicione(dataDeSaida);

                return RedirectToAction("Index");
            }

            return View("Index", model);
        }
    }
}