using Overbooking.Compartilhado.Fabricas;
using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Overbooking.Negocio.Implementacoes
{
    internal class ServicoDeVoo : IServicoDeVoo
    {
        private const int CAPACIDADE_MAXIMA_PADRAO = 200;

        private IRepositorio<IPassageiroVoo> _repositorio;

        public ServicoDeVoo(IRepositorio<IPassageiroVoo> repositorio)
        {
            _repositorio = repositorio;
        }

        public void AdicionePassageiro(IPassageiroVoo passageiroVoo)
        {
            var qtdPassageirosNoVoo = ObtenhaQtdPassageirosNoVoo(passageiroVoo.Rota, passageiroVoo.DataDeSaida);

            if (qtdPassageirosNoVoo >= CAPACIDADE_MAXIMA_PADRAO)
            {
                throw new Exception($"A capacidade máxima de {CAPACIDADE_MAXIMA_PADRAO} passageiros do vôo [{passageiroVoo.Rota} as {passageiroVoo.DataDeSaida}] foi atingida.");
            }

            _repositorio.Salve(passageiroVoo);
        }

        public int ObtenhaQtdLimiteDePassageirosPadrao() => CAPACIDADE_MAXIMA_PADRAO;

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

        private int ObtenhaQtdPassageirosNoVoo(IRota rota, IDataDeSaida data)
        {
            const int NENHUM_PASSAGEIRO = 0;

            var passageirosAgrupadosPorVoo = ObtenhaTodosPassageiros().GroupBy(x => new { x.Rota.Origem, x.Rota.Destino, x.DataDeSaida.Data })
                                            .Where(x => x.Key.Origem == rota.Origem &&
                                                        x.Key.Destino == rota.Destino &&
                                                        x.Key.Data == data.Data)
                                            .Select(group => new
                                            {
                                                qtdPassageiros = group.Count()
                                            });

            return passageirosAgrupadosPorVoo.FirstOrDefault()?.qtdPassageiros ?? NENHUM_PASSAGEIRO;
        }
    }
}
