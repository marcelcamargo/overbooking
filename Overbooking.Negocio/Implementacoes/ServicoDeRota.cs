using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;

namespace Overbooking.Negocio.Implementacoes
{
    public class ServicoDeRota : ServicoGenerico<IRota>, IServicoDeRota
    {
        private IRepositorio<IRota> _repositorio;

        protected override IRepositorio<IRota> Repositorio { get => _repositorio; }

        public ServicoDeRota(IRepositorio<IRota> repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
