using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Fabricas;
using Overbooking.Negocio.Implementacoes;
using Overbooking.Negocio.Interfaces;

namespace Overbooking.Negocio.Fabricas
{
    public static class FabricaDeServicos
    {
        public static class FabricaDeServicoDeDataDeSaida
        {
            public static IServicoDeDataDeSaida Crie()
            {
                return new ServicoDeDataDeSaida(FabricaDeRepositorio<IDataDeSaida>.ObtenhaRepositorio());
            }
        }

        public static class FabricaDeServicoDeIdade
        {
            public static IServicoDeIdade Crie()
            {
                return new ServicoDeIdade(FabricaDeRepositorio<IIdadeDoPassageiro>.ObtenhaRepositorio());
            }
        }

        public static class FabricaDeServicoDeRota
        {
            public static IServicoDeRota Crie()
            {
                return new ServicoDeRota(FabricaDeRepositorio<IRota>.ObtenhaRepositorio());
            }
        }
    }
}
