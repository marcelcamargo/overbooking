using Overbooking.Compartilhado.Interfaces;
using Overbooking.Models;
using Overbooking.Negocio.Fabricas;
using Overbooking.Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Overbooking.Controllers
{
    public class VoosController : Controller
    {
        private IServicoDeVoo _servicoDeVoo;

        public VoosController()
        {
            _servicoDeVoo = FabricaDeServicos.FabricaDeServicoDeVoo.Crie();
        }

        public ActionResult Index()
        {
            var voos = _servicoDeVoo.ObtenhaTodosVoos();
            var voosModel = ObtenhaVoosModel(voos);

            return View(voosModel);
        }

        private IEnumerable<VooModel> ObtenhaVoosModel(IEnumerable<IVoo> listaVoos)
        {
            var listaVoosModel = from voo in listaVoos
                                 select new VooModel()
                                 {
                                     Rota = voo.Rota.ToString(),
                                     Data = voo.DataDeSaida.ToString(),
                                     QtdPassageiros = $"{voo.Passageiros.Count}/{voo.CapacidadePassageiros}",
                                     RiscoDeOverbooking = voo.RiscoDeOverbooking
                                 };

            return listaVoosModel;
        }
    }
}