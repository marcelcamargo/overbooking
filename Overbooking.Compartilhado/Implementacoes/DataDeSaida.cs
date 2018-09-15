using Overbooking.Compartilhado.Interfaces;
using System;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class DataDeSaida : ProbabilidadeDeComparecimento, IDataDeSaida
    {
        public DateTime Data { get; set; }
    }
}
