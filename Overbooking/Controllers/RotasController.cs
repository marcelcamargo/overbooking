using Overbooking.Compartilhado.Fabricas;
using Overbooking.Compartilhado.Interfaces;
using Overbooking.Models;
using Overbooking.Negocio.Fabricas;
using System.Web.Mvc;

namespace Overbooking.Controllers
{
    public class RotasController : ControladorPadraoParametroIndependente<IRota>
    {
        public RotasController()
        {
            _servicoGenerico = FabricaDeServicos.FabricaDeServicoDeRota.Crie();
        }

        [HttpPost]
        public ActionResult Cadastrar(RotaModel model)
        {
            if (ModelState.IsValid)
            {
                var rota = FabricaDeRota.Crie(model.Origem, model.Destino, model.ProbabilidadeDeComparecimento.Value);

                _servicoGenerico.Adicione(rota);

                return RetorneViewIndex(null);
            }

            return RetorneViewIndex(model);
        }
    }
}