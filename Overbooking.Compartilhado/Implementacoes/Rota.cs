using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class Rota : ProbabilidadeDeComparecimento, IRota
    {
        public string Origem { get; set ; }
        public string Destino { get ; set; }
    }
}