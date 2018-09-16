using Overbooking.Compartilhado.Implementacoes;
using Overbooking.Compartilhado.Interfaces;
using System;

namespace Overbooking.Compartilhado.Fabricas
{
    public static class FabricaDeDataDeSaida
    {
        public static IDataDeSaida Crie(DateTime data)
        {
            return new DataDeSaida(data);
        }

        public static IDataDeSaida Crie(DateTime data, int pi)
        {
            return new DataDeSaida(data, pi);
        }
    }
}
