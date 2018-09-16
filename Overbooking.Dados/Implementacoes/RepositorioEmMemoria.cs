using Overbooking.Dados.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Overbooking.Dados.Implementacoes
{
    internal class RepositorioEmMemoria<T> : IRepositorio<T> where T : class
    {
        private IList<T> _listaDeEntidades;

        public RepositorioEmMemoria()
        {
            _listaDeEntidades = new List<T>();
        }

        public IEnumerable<T> ObtenhaTodos()
        {
            return _listaDeEntidades;
        }

        public T Obtenha(T entidade)
        {
            return _listaDeEntidades.FirstOrDefault(x => x.Equals(entidade));
        }

        public void Salve(T entidade)
        {
            _listaDeEntidades.Remove(entidade);
            _listaDeEntidades.Add(entidade);
        }
    }
}
