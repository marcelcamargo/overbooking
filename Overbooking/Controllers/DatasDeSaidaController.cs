﻿using Overbooking.Compartilhado.Implementacoes;
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
    public class DatasDeSaidaController : Controller
    {
        private IServicoDeDataDeSaida _servicoDeDataDeSaida;

        public DatasDeSaidaController()
        {
            _servicoDeDataDeSaida = FabricaDeServicos.FabricaDeServicoDeDataDeSaida.Crie();
        }

        public ActionResult Index()
        {
            ViewBag.ItensCadastrados = ObtenhaItensParaApresentacao(_servicoDeDataDeSaida.ObtenhaTodos());
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(DataDeSaidaModel dataDeSaidaView)
        {
            if (ModelState.IsValid)
            {
                var dataDeSaida = CrieDataDeSaida(dataDeSaidaView);

                _servicoDeDataDeSaida.Adicione(dataDeSaida);

                return RedirectToAction("Index");
            }

            return View("Index", dataDeSaidaView);
        }

        private IDataDeSaida CrieDataDeSaida(DataDeSaidaModel dataDeSaidaModel)
        {
            var dataDeSaida = new DataDeSaida
            {
                Identificador = Guid.NewGuid().ToString(),
                Data = dataDeSaidaModel.Data,
                ProbabilidadeDeComparecimento = dataDeSaidaModel.ProbabilidadeDeComparecimento.Value
            };

            return dataDeSaida;
        }

        private IEnumerable<ApresentacaoPicModel> ObtenhaItensParaApresentacao(IEnumerable<IDataDeSaida> listaDataDeSaida)
        {
            return from dataDeSaida in listaDataDeSaida
                   select new ApresentacaoPicModel() { Parametro = dataDeSaida.ToString(),
                                                       ProbabilidadeDeComparecimento = dataDeSaida.ProbabilidadeDeComparecimento };
        }
    }
}