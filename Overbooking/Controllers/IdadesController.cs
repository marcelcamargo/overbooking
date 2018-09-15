using Overbooking.Compartilhado.Implementacoes;
using Overbooking.Compartilhado.Interfaces;
using Overbooking.Models;
using Overbooking.Negocio.Fabricas;
using Overbooking.Negocio.Interfaces;
using System;
using System.Web.Mvc;

namespace Overbooking.Controllers
{
    public class IdadesController : ControladorPadrao
    {
        private IServicoDeIdade _servicoDeIdade;

        public IdadesController()
        {
            _servicoDeIdade = FabricaDeServicos.FabricaDeServicoDeIdade.Crie();
        }

        public ActionResult Index()
        {
            ViewBag.ItensCadastrados = ObtenhaItensParaApresentacao(_servicoDeIdade.ObtenhaTodos());
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(IdadeDoPassageiroModel idadeDoPassageiroView)
        {
            if (ModelState.IsValid)
            {
                var idadeDoPassageiro = CrieIdadeDoPassageiro(idadeDoPassageiroView);

                _servicoDeIdade.Adicione(idadeDoPassageiro);

                return RedirectToAction("Index");
            }

            return View("Index", idadeDoPassageiroView);
        }

        private IIdadeDoPassageiro CrieIdadeDoPassageiro(IdadeDoPassageiroModel idadeDoPassageiroModel)
        {
            var idadeDoPassageiro = new IdadeDoPassageiro
            {
                Identificador = Guid.NewGuid().ToString(),
                Idade = idadeDoPassageiroModel.Idade.Value,
                ProbabilidadeDeComparecimento = idadeDoPassageiroModel.ProbabilidadeDeComparecimento.Value
            };

            return idadeDoPassageiro;
        }
    }
}