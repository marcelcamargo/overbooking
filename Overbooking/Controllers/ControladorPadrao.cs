using Overbooking.Compartilhado.Interfaces;
using Overbooking.Models;
using Overbooking.Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Overbooking.Controllers
{
    public class ControladorPadraoParametroIndependente<T> : Controller  where T : class
    {
        protected IServicoGenericoDeParametroIndependente<T> _servicoGenerico;

        public ActionResult Index()
        {
            return RetorneViewIndex(null);
        }

        protected ActionResult RetorneViewIndex(object model)
        {
            ViewBag.ItensCadastrados = ObtenhaItensParaApresentacao(_servicoGenerico.ObtenhaTodos());

            return View("Index", model);
        }

        protected IEnumerable<ApresentacaoPicModel> ObtenhaItensParaApresentacao(IEnumerable<T> listaPic)
        {
            return from IParametroIndependente pic in listaPic
                   select new ApresentacaoPicModel()
                   {
                       Parametro = pic.ToString(),
                       ProbabilidadeDeComparecimento = pic.ProbabilidadeDeComparecimento
                   };
        }
    }
}