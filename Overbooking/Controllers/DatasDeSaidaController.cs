using Overbooking.Negocio.Fabricas;
using Overbooking.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Overbooking.Controllers
{
    public class DatasDeSaidaController : Controller
    {
        private IServicoDeDataDeSaida _servicoDeDataDeSaida;

        public DatasDeSaidaController()
        {
            _servicoDeDataDeSaida = FabricaDeServicoDeDataDeSaida.Crie();
        }

        // GET: DatasDeSaida
        public ActionResult Index()
        {
            return View();
        }
    }
}