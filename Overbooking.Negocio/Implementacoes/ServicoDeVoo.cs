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

            var agrupados = ObtenhaTodosPassageiros().GroupBy(x => new { x.Rota.Origem, x.Rota.Destino, x.DataDeSaida.Data });

            foreach (var grupo in agrupados)
            {
                var voo = new Voo()
                {
                    Rota = new Rota() { Origem = grupo.Key.Origem, Destino = grupo.Key.Destino },
                    DataDeSaida = new DataDeSaida() { Data = grupo.Key.Data }
                };

                foreach (var item in grupo)
                {
                    voo.Passageiros.Add(new Passageiro() { Nome = item.Nome, IdadePassageiro = item.IdadePassageiro });
                }

                voo.RiscoDeOverbooking = CalculadoraDeRisco.CalculeProbabilidadeDeComparecimento(voo);

                listaVoos.Add(voo);
            }

            return listaVoos;
        }
    }
}
