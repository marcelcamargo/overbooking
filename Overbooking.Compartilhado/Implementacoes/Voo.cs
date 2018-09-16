using System.Collections.Generic;
using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class Voo : IVoo
    {
        private const int CAPACIDADE_MAXIMA = 200;

        public IRota Rota { get; set; }
        public IDataDeSaida DataDeSaida { get; set; }
        public IList<IPassageiro> Passageiros { get; set; }
        public decimal RiscoDeOverbooking { get; set; }

        public int CapacidadePassageiros => CAPACIDADE_MAXIMA;

        public Voo()
        {
            Passageiros = new List<IPassageiro>();
        }
    }
}