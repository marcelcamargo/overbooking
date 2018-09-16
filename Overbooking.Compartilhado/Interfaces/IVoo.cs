using System.Collections.Generic;

namespace Overbooking.Compartilhado.Interfaces
{
    public interface IVoo
    {        
        IRota Rota { get; set; }
        IDataDeSaida DataDeSaida { get; set; }
        IList<IPassageiro> Passageiros { get; set; }
        decimal RiscoDeOverbooking { get; set; }
        int CapacidadePassageiros { get; }
    }
}