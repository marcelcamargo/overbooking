using Overbooking.Compartilhado.Implementacoes;
using Overbooking.Compartilhado.Interfaces;
using Overbooking.Models;
using Overbooking.Negocio.Fabricas;
using Overbooking.Negocio.Interfaces;
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
            ViewBag.PassageirosCadastrados = _servicoDeVoo.ObtenhaTodosPassageiros();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Adicionar(PassageiroVooModel passageiroVooView)
        {            
            if (ModelState.IsValid)
            {
                var passageiroVoo = CriePassageiroVoo(passageiroVooView);

                _servicoDeVoo.AdicionePassageiro(passageiroVoo);
                
                return RetorneViewIndex(null);
            }
            
            return RetorneViewIndex(passageiroVooView);
        }

        private IPassageiroVoo CriePassageiroVoo(PassageiroVooModel model)
        {
            var passageiroVoo = new PassageiroVoo
            {
                Nome = model.Nome,
                IdadePassageiro = new IdadeDoPassageiro() { Idade = model.Idade.Value },
                Rota = new Rota() { Origem = model.Origem, Destino = model.Destino },
                DataDeSaida = new DataDeSaida() { Data = model.Data.Value }

            };

            return passageiroVoo;
        }

    }
}