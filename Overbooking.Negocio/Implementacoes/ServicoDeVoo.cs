using System.Collections.Generic;
using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;

namespace Overbooking.Negocio.Implementacoes
{
    public class ServicoDeVoo : IServicoDeVoo
    {
        private IRepositorio<IPassageiroVoo> _repositorio;

        public ServicoDeVoo(IRepositorio<IPassageiroVoo> repositorio)
        {
            _repositorio = repositorio;
        }

        public void AdicionePassageiro(IPassageiroVoo passageiroVoo)
        {
            _repositorio.Adicione(passageiroVoo);
        }

        public IEnumerable<IPassageiroVoo> ObtenhaTodosPassageiros()
        {
            return _repositorio.ObtenhaTodos();
        }
    }
}
