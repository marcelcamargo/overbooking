using System.Collections.Generic;
using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;
using System.Linq;
using Overbooking.Compartilhado.Implementacoes;

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
            var listaVoos = new List<IVoo>();

            var passageirosAgrupadosPorVoo = ObtenhaTodosPassageiros().GroupBy(x => new { x.Rota.Origem, x.Rota.Destino, x.DataDeSaida.Data });

            foreach (var vooAgrupado in passageirosAgrupadosPorVoo)
            {
                var voo = new Voo()
                {
                    Rota = new Rota() { Origem = vooAgrupado.Key.Origem, Destino = vooAgrupado.Key.Destino },
                    DataDeSaida = new DataDeSaida() { Data = vooAgrupado.Key.Data }
                };

                foreach (var passageiroNoVoo in vooAgrupado)
                {
                    voo.Passageiros.Add(new Passageiro() { Nome = passageiroNoVoo.Nome, IdadePassageiro = passageiroNoVoo.IdadePassageiro });
                }

                voo.RiscoDeOverbooking = CalculadoraDeRisco.CalculeProbabilidadeDeComparecimento(voo);

                listaVoos.Add(voo);
            }

            return listaVoos;
        }
    }
}
