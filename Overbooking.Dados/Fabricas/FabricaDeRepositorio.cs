using Overbooking.Dados.Implementacoes;
using Overbooking.Dados.Interfaces;

namespace Overbooking.Dados.Fabricas
{
    public class FabricaDeRepositorio
    {
        public static IRepositorio<T> CrieRepositorio<T>() where T : class
        {
            return new RepositorioEmMemoria<T>();
        }
    }
}
