using System;

namespace Overbooking.Compartilhado.Interfaces
{
    public interface IDataDeSaida : IProbabilidadeDeComparecimento
    {
        DateTime Data { get; set; }
    }
}
