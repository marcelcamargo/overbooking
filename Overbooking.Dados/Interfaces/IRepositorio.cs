using System.Collections.Generic;

namespace Overbooking.Dados.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> ObtenhaTodos();
        T Obtenha(T entidade);
        void Salve(T entidade);
    }
}
