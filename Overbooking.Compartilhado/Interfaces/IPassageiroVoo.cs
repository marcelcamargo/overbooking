using System.Collections.Generic;

namespace Overbooking.Compartilhado.Interfaces
{
    public interface IPassageiroVoo  : IPassageiro
    {
        IRota Rota { get; set; }
        IDataDeSaida DataDeSaida { get; set; }
    }
}