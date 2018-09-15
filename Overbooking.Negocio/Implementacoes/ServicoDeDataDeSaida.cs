using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;

namespace Overbooking.Negocio.Implementacoes
{
    public class ServicoDeDataDeSaida : ServicoGenerico<IDataDeSaida>, IServicoDeDataDeSaida
    {
        private IRepositorio<IDataDeSaida> _repositorio;

        protected override IRepositorio<IDataDeSaida> Repositorio { get => _repositorio; }

        public ServicoDeDataDeSaida(IRepositorio<IDataDeSaida> repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
