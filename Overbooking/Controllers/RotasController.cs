using Overbooking.Compartilhado.Implementacoes;
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
        public ActionResult Cadastrar(RotaModel rotaView)
        {
            if (ModelState.IsValid)
            {
                var rota = CrieRota(rotaView);

                _servicoGenerico.Adicione(rota);

                return RetorneViewIndex(null);
            }

            return RetorneViewIndex(rotaView);
        }

        private IRota CrieRota(RotaModel rotaModel)
        {
            var rota = new Rota
            {
                Origem = rotaModel.Origem,
                Destino = rotaModel.Destino,
                ProbabilidadeDeComparecimento = rotaModel.ProbabilidadeDeComparecimento.Value
            };

            return rota;
        }
    }
}