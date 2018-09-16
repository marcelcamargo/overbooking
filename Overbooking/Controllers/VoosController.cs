using Overbooking.Compartilhado.Interfaces;
using Overbooking.Models;
using Overbooking.Negocio.Fabricas;
using Overbooking.Negocio.Interfaces;
using System;
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
            try
            {
                var voos = _servicoDeVoo.ObtenhaTodosVoos();
                var voosModel = ObtenhaVoosModel(voos);

                return View(voosModel);
            }
            catch (Exception ex)
            {
                return PartialView("Erro", ex.Message);
            }
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