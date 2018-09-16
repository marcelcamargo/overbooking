using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class Rota : ParametroIndependente, IRota
    {
        public string Origem { get; set ; }
        public string Destino { get ; set; }

        public Rota(string origem, string destino)
        {
            Origem = origem;
            Destino = destino;
        }

        public Rota(string origem, string destino, int pi) : this(origem, destino)
        {
            ProbabilidadeDeComparecimento = pi;
        }

        public override string ToString()
        {
            return $"{Origem} - {Destino}";
        }

        public override bool Equals(object obj)
        {
            return (obj as Rota)?.ToString() == ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}