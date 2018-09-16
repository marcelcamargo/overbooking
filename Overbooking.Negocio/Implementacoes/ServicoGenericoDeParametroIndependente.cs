using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;
using System.Collections.Generic;

namespace Overbooking.Negocio.Implementacoes
{
    public abstract class ServicoGenericoDeParametroIndependente<T> : IServicoGenericoDeParametroIndependente<T> where T : class
    {
        protected abstract IRepositorio<T> Repositorio { get; }

        public void Adicione(T pi)
        {
            Repositorio.Adicione(pi);
        }

        public IEnumerable<T> ObtenhaTodos()
        {
            return Repositorio.ObtenhaTodos();
        }
    }
}
