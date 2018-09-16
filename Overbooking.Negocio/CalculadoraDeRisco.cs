using Overbooking.Compartilhado.Interfaces;
using System;
using System.Linq;

namespace Overbooking.Negocio
{
    internal class CalculadoraDeRisco
    {
        public static decimal CalculeProbabilidadeDeComparecimento(IVoo voo)
        {
            if (voo.Passageiros.Count == 0) return 0;

            return voo.Passageiros.Sum(passageiro => CalculeProbabilidadeDeComparecimentoDoPassageiro(voo, passageiro)) / voo.Passageiros.Count;
        }

        private static decimal CalculeProbabilidadeDeComparecimentoDoPassageiro(IVoo voo, IPassageiro passageiro)
        {
            const int VALOR_CASAS_DECIMAIS = 2;

            decimal porcentagemRota = ObtenhaPicRota(voo.Rota) / 100;
            decimal porcentagemData = ObtenhaPicData(voo.DataDeSaida) / 100;
            decimal porcentagemIdade = ObtenhaPicIdade(passageiro.IdadePassageiro) / 100;

            return Math.Round(100 * (porcentagemRota * porcentagemData * porcentagemIdade), VALOR_CASAS_DECIMAIS);
        }

        private static decimal ObtenhaPicRota(IRota rota)
        {
            var servicoDeRota = Fabricas.FabricaDeServicos.FabricaDeServicoDeRota.Crie();

            return servicoDeRota.Obtenha(rota)?.ProbabilidadeDeComparecimento ?? 100;
        }

        private static decimal ObtenhaPicData(IDataDeSaida data)
        {
            var servicoDeData = Fabricas.FabricaDeServicos.FabricaDeServicoDeDataDeSaida.Crie();

            return servicoDeData.Obtenha(data)?.ProbabilidadeDeComparecimento ?? 100;
        }

        private static decimal ObtenhaPicIdade(IIdadeDoPassageiro idade)
        {
            var servicoDeIdade = Fabricas.FabricaDeServicos.FabricaDeServicoDeIdade.Crie();

            return servicoDeIdade.Obtenha(idade)?.ProbabilidadeDeComparecimento ?? 100;
        }
    }
}