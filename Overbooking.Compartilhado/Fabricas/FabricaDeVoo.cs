using Overbooking.Compartilhado.Implementacoes;
using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Fabricas
{
    public static class FabricaDeVoo
    {
        public static IVoo Crie(IRota rota, IDataDeSaida data)
        {
            return new Voo(rota, data);
        }
    }
}
