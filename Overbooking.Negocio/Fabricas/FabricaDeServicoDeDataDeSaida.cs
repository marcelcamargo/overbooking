using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Fabricas;
using Overbooking.Negocio.Implementacoes;
using Overbooking.Negocio.Interfaces;

namespace Overbooking.Negocio.Fabricas
{
    public class FabricaDeServicoDeDataDeSaida
    {
        public static IServicoDeDataDeSaida Crie()
        {
            return new ServicoDeDataDeSaida(FabricaDeRepositorio.CrieRepositorio<IDataDeSaida>());
        }
    }
}
