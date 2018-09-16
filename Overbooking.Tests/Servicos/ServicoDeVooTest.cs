using Microsoft.VisualStudio.TestTools.UnitTesting;
using Overbooking.Compartilhado.Fabricas;
using Overbooking.Negocio.Fabricas;
using Overbooking.Negocio.Interfaces;
using System;
using System.Linq;

namespace Overbooking.Tests.Controllers
{
    [TestClass]
    public class ServicoDeVooTest
    {
        private IServicoDeVoo _servico;

        [TestInitialize]
        public void Setup()
        {
            _servico = FabricaDeServicos.FabricaDeServicoDeVoo.Crie();
        }

        [TestMethod]
        public void TesteAdicionarPassageiro()
        {
            var objTeste = FabricaDePassageiroVoo.Crie("Marcel Camargo",
                                                       FabricaDeIdadeDoPassageiro.Crie(27),
                                                       FabricaDeRota.Crie("GYN", "GRU"),
                                                       FabricaDeDataDeSaida.Crie(DateTime.Now));

            _servico.AdicionePassageiro(objTeste);

            var objDoServico = _servico.ObtenhaTodosPassageiros();

            Assert.IsTrue(objDoServico.Contains(objTeste));
        }

        [TestMethod]
        public void TesteLimiteDePassageirosDoVoo()
        {
            var dataVoo = DateTime.Now;
            var qtdLimite = _servico.ObtenhaQtdLimiteDePassageirosPadrao();

            for (var qtd = 0; qtd <= qtdLimite; qtd++)
            {
                var objTeste = FabricaDePassageiroVoo.Crie($"Passageiro {qtd}",
                                                           FabricaDeIdadeDoPassageiro.Crie(27),
                                                           FabricaDeRota.Crie("GYN", "GRU"),
                                                           FabricaDeDataDeSaida.Crie(dataVoo));

                try
                {
                    _servico.AdicionePassageiro(objTeste);
                }
                catch (Exception ex)
                {
                    Assert.IsTrue(ex.Message.Contains("A capacidade máxima de"));
                    return;
                }
            }
        }

        [TestMethod]
        public void TesteObtenhaVoos()
        {
            var objTeste = FabricaDePassageiroVoo.Crie("Marcel Camargo",
                                                       FabricaDeIdadeDoPassageiro.Crie(27),
                                                       FabricaDeRota.Crie("GYN", "GRU"),
                                                       FabricaDeDataDeSaida.Crie(DateTime.Now));

            var objTeste2 = FabricaDePassageiroVoo.Crie("Maria Eduarda",
                                                        FabricaDeIdadeDoPassageiro.Crie(32),
                                                        FabricaDeRota.Crie("GYN", "CGH"),
                                                        FabricaDeDataDeSaida.Crie(DateTime.Now));

            _servico.AdicionePassageiro(objTeste);
            _servico.AdicionePassageiro(objTeste2);

            var objDoServico = _servico.ObtenhaTodosVoos();

            Assert.IsTrue(objDoServico.Count() >= 2);
        }
    }
}
