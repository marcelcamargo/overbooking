using System.Collections.Generic;
using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class Voo : IVoo
    {
        const int CAPACIDADE_MAXIMA_VOO = 200;

        public IRota Rota { get; set; }
        public IDataDeSaida DataDeSaida { get; set; }
        public IList<IPassageiro> Passageiros { get; set; }
        public int CapacidadePassageiros => CAPACIDADE_MAXIMA_VOO;
    }
}