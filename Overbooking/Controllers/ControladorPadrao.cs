using Overbooking.Compartilhado.Interfaces;
using Overbooking.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Overbooking.Controllers
{
    public class ControladorPadrao : Controller
    {
        protected IEnumerable<ApresentacaoPicModel> ObtenhaItensParaApresentacao(IEnumerable<IParametroIndependente> listaPic)
        {
            return from pic in listaPic
                   select new ApresentacaoPicModel()
                   {
                       Parametro = pic.ToString(),
                       ProbabilidadeDeComparecimento = pic.ProbabilidadeDeComparecimento
                   };
        }
    }
}