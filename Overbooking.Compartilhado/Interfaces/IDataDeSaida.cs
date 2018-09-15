using System;

namespace Overbooking.Compartilhado.Interfaces
{
    public interface IDataDeSaida : IParametroIndependente
    {
        DateTime Data { get; set; }
    }
}
