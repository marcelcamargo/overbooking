using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;
using System.Collections.Generic;

namespace Overbooking.Negocio.Implementacoes
{
    public class ServicoDeDataDeSaida : IServicoDeDataDeSaida
    {
        private IRepositorio<IDataDeSaida> _repositorio;

        public ServicoDeDataDeSaida(IRepositorio<IDataDeSaida> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicione(IDataDeSaida dataDeSaida)
        {
            _repositorio.Adicione(dataDeSaida);
        }

        public IEnumerable<IDataDeSaida> ObtenhaTodos()
        {
            return _repositorio.ObtenhaTodos();
        }
    }
}
