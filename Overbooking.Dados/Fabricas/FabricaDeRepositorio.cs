using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Implementacoes;
using Overbooking.Dados.Interfaces;

namespace Overbooking.Dados.Fabricas
{
    public class FabricaDeRepositorio
    {
        public static IRepositorio<T> CrieRepositorio<T>() where T : IParametroIndependente
        {
            return new RepositorioEmMemoria<T>();
        }
    }
}
