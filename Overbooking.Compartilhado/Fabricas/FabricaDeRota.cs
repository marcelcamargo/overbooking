using Overbooking.Compartilhado.Implementacoes;
using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Fabricas
{
    public static class FabricaDeRota
    {
        public static IRota Crie(string origem, string destino)
        {
            return new Rota(origem, destino);
        }

        public static IRota Crie(string origem, string destino, int pi)
        {
            return new Rota(origem, destino, pi);
        }
    }
}
