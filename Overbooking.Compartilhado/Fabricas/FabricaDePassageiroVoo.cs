using Overbooking.Compartilhado.Implementacoes;
using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Fabricas
{
    public static class FabricaDePassageiroVoo
    {
        public static IPassageiroVoo Crie(string nome, IIdadeDoPassageiro idadePassageiro, IRota rota, IDataDeSaida dataDeSaida)
        {
            return new PassageiroVoo(nome, idadePassageiro, rota, dataDeSaida);
        }
    }
}
