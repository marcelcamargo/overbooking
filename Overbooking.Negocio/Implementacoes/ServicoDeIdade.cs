using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;

namespace Overbooking.Negocio.Implementacoes
{
    internal class ServicoDeIdade : ServicoGenericoDeParametroIndependente<IIdadeDoPassageiro>, IServicoDeIdade
    {
        private IRepositorio<IIdadeDoPassageiro> _repositorio;

        protected override IRepositorio<IIdadeDoPassageiro> Repositorio { get => _repositorio; }

        public ServicoDeIdade(IRepositorio<IIdadeDoPassageiro> repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
