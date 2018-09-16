using Overbooking.Compartilhado.Implementacoes;
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
        public ActionResult Cadastrar(DataDeSaidaModel dataDeSaidaView)
        {
            if (ModelState.IsValid)
            {
                var dataDeSaida = CrieDataDeSaida(dataDeSaidaView);

                _servicoGenerico.Adicione(dataDeSaida);

                return RedirectToAction("Index");
            }

            return View("Index", dataDeSaidaView);
        }

        private IDataDeSaida CrieDataDeSaida(DataDeSaidaModel dataDeSaidaModel)
        {
            var dataDeSaida = new DataDeSaida
            {
                Data = dataDeSaidaModel.Data.Value,
                ProbabilidadeDeComparecimento = dataDeSaidaModel.ProbabilidadeDeComparecimento.Value
            };

            return dataDeSaida;
        }

    }
}