using Overbooking.Compartilhado.Fabricas;
using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Overbooking.Negocio.Implementacoes
{
    internal class ServicoDeVoo : IServicoDeVoo
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

        public IEnumerable<IVoo> ObtenhaTodosVoos()
        {
            var passageirosAgrupadosPorVoo = ObtenhaTodosPassageiros().GroupBy(x => new { x.Rota.Origem, x.Rota.Destino, x.DataDeSaida.Data });

            foreach (var passageirosPorVoo in passageirosAgrupadosPorVoo)
            {
                yield return CrieVoo(passageirosPorVoo);
            }
        }

        private IVoo CrieVoo(IGrouping<dynamic, IPassageiro> passageirosPorVoo)
        {
            IVoo voo = FabricaDeVoo.Crie(FabricaDeRota.Crie(passageirosPorVoo.Key.Origem, passageirosPorVoo.Key.Destino),
                                         FabricaDeDataDeSaida.Crie(passageirosPorVoo.Key.Data));

            voo.Passageiros = passageirosPorVoo.ToList();

            voo.RiscoDeOverbooking = CalculadoraDeRisco.CalculeProbabilidadeDeComparecimento(voo);

            return voo;
        }
    }
}
