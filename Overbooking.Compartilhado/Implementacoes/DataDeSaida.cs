using Overbooking.Compartilhado.Interfaces;
using System;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class DataDeSaida : ParametroIndependente, IDataDeSaida
    {
        public DateTime Data { get; set; }

        public override string ToString()
        {
            return Data.ToString("dd/MM/yyyy HH:mm");
        }

        public override bool Equals(object obj)
        {
            return (obj as DataDeSaida)?.ToString() == ToString();
        }
    }
}
