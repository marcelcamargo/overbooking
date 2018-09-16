using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class IdadeDoPassageiro : ParametroIndependente, IIdadeDoPassageiro
    {
        public int Idade { get; set; }

        public IdadeDoPassageiro(int idade)
        {
            Idade = idade;
        }

        public IdadeDoPassageiro(int idade, int pi) : this(idade)
        {
            ProbabilidadeDeComparecimento = pi;
        }

        public override string ToString()
        {
            return Idade.ToString();
        }

        public override bool Equals(object obj)
        {
            return (obj as IdadeDoPassageiro)?.ToString() == ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}