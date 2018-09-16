using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;
using System.Collections.Generic;

namespace Overbooking.Negocio.Implementacoes
{
    internal abstract class ServicoGenericoDeParametroIndependente<T> : IServicoGenericoDeParametroIndependente<T> where T : class
    {
        protected abstract IRepositorio<T> Repositorio { get; }

        public void Adicione(T entidade)
        {
            Repositorio.Adicione(entidade);
        }

        public IEnumerable<T> ObtenhaTodos()
        {
            return Repositorio.ObtenhaTodos();
        }

        public T Obtenha(T entidade)
        {
            return Repositorio.Obtenha(entidade);
        }
    }
}
