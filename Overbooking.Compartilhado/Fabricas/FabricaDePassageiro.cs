using Overbooking.Compartilhado.Implementacoes;
using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Fabricas
{
    public static class FabricaDePassageiro
    {
        public static IPassageiro Crie(string nome, IIdadeDoPassageiro idadePassageiro)
        {
            return new Passageiro(nome, idadePassageiro);
        }
    }
}
