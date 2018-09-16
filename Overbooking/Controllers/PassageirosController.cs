using Overbooking.Compartilhado.Fabricas;
using Overbooking.Models;
using Overbooking.Negocio.Fabricas;
using Overbooking.Negocio.Interfaces;
using System;
using System.Web.Mvc;

namespace Overbooking.Controllers
{
    public class PassageirosController : Controller
    {
        private IServicoDeVoo _servicoDeVoo;

        public PassageirosController()
        {
            _servicoDeVoo = FabricaDeServicos.FabricaDeServicoDeVoo.Crie();
        }

        public ActionResult Index()
        {
            return RetorneViewIndex(null);
        }

        protected ActionResult RetorneViewIndex(object model)
        {
            try
            {
                ViewBag.PassageirosCadastrados = _servicoDeVoo.ObtenhaTodosPassageiros();

                return View("Index", model);
            }
            catch (Exception ex)
            {
                return PartialView("Erro", ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Adicionar(PassageiroVooModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var passageiroVoo = FabricaDePassageiroVoo.Crie(model.Nome,
                                                                    FabricaDeIdadeDoPassageiro.Crie(model.Idade.Value),
                                                                    FabricaDeRota.Crie(model.Origem, model.Destino),
                                                                    FabricaDeDataDeSaida.Crie(model.Data.Value));

                    _servicoDeVoo.AdicionePassageiro(passageiroVoo);

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