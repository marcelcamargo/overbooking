using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;

namespace Overbooking.Negocio.Implementacoes
{
    public class ServicoDeVoo : ServicoGenericoDeParametroIndependente<IVoo>, IServicoDeVoo
    {
        private IRepositorio<IVoo> _repositorio;

        protected override IRepositorio<IVoo> Repositorio { get => _repositorio; }

        public ServicoDeVoo(IRepositorio<IVoo> repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
