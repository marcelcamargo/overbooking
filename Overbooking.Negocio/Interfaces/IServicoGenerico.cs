using Overbooking.Compartilhado.Interfaces;
using System.Collections.Generic;

namespace Overbooking.Negocio.Interfaces
{
    public interface IServicoGenerico<T> where T : IParametroIndependente
    {
        void Adicione(T dataDeSaida);
        IEnumerable<T> ObtenhaTodos();
    }
}
