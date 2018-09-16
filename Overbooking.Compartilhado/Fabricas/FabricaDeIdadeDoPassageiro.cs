using Overbooking.Compartilhado.Implementacoes;
using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Fabricas
{
    public static class FabricaDeIdadeDoPassageiro
    {
        public static IIdadeDoPassageiro Crie(int idade)
        {
            return new IdadeDoPassageiro(idade);
        }

        public static IIdadeDoPassageiro Crie(int idade, int pi)
        {
            return new IdadeDoPassageiro(idade, pi);
        }
    }
}
