using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;
using System.Collections.Generic;

namespace Overbooking.Negocio.Implementacoes
{
    public abstract class ServicoGenerico<T> : IServicoGenerico<T> where T : IParametroIndependente
    {
        protected abstract IRepositorio<T> Repositorio { get; }

        public void Adicione(T dataDeSaida)
        {
            Repositorio.Adicione(dataDeSaida);
        }

        public IEnumerable<T> ObtenhaTodos()
        {
            return Repositorio.ObtenhaTodos();
        }
    }
}
