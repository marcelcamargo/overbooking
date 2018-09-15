using Overbooking.Compartilhado.Interfaces;
using System;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class DataDeSaida : ParametroIndependente, IDataDeSaida
    {
        public DateTime Data { get; set; }
    }
}
