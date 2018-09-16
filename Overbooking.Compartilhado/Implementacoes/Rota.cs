using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class Rota : ParametroIndependente, IRota
    {
        public string Origem { get; set ; }
        public string Destino { get ; set; }

        public override string ToString()
        {
            return $"{Origem} - {Destino}";
        }

        public override bool Equals(object obj)
        {
            return (obj as Rota)?.ToString() == ToString();
        }
    }
}