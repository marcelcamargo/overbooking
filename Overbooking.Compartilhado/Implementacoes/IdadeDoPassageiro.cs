using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class IdadeDoPassageiro : ProbabilidadeDeComparecimento, IIdadeDoPassageiro
    {
        public int Idade { get; set; }
    }
}