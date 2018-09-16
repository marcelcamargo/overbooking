using Overbooking.Compartilhado.Interfaces;
using System;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class DataDeSaida : ParametroIndependente, IDataDeSaida
    {
        public DateTime Data { get; set; }

        public DataDeSaida(DateTime data)
        {
            Data = data;
        }

        public DataDeSaida(DateTime data, int pi) : this(data)
        {
            ProbabilidadeDeComparecimento = pi;
        }

        public override string ToString()
        {
            return Data.ToString("dd/MM/yyyy HH:mm");
        }

        public override bool Equals(object obj)
        {
            return (obj as DataDeSaida)?.ToString() == ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
