using System;
using System.Collections.Generic;

namespace Overbooking.Dados.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> ObtenhaTodos();
        IEnumerable<T> Obtenha(Func<T, bool> expressao);
        void Adicione(T entidade);
        void Atualize(T entidade);
        void Remova(T entidade);
    }
}
