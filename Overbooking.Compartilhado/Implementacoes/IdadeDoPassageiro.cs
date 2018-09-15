using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class IdadeDoPassageiro : ParametroIndependente, IIdadeDoPassageiro
    {
        public int Idade { get; set; }

        public override string ToString()
        {
            return Idade.ToString();
        }
    }
}