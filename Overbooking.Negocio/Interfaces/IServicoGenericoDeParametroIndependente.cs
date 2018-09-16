using System.Collections.Generic;

namespace Overbooking.Negocio.Interfaces
{
    public interface IServicoGenericoDeParametroIndependente<T> where T : class
    {
        void Adicione(T entidade);
        IEnumerable<T> ObtenhaTodos();
        T Obtenha(T entidade);
    }
}
