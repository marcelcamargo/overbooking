using Microsoft.VisualStudio.TestTools.UnitTesting;
using Overbooking.Compartilhado.Fabricas;
using Overbooking.Negocio.Fabricas;
using Overbooking.Negocio.Interfaces;
using System;
using System.Linq;

namespace Overbooking.Tests.Controllers
{
    [TestClass]
    public class ServicoDeDataDeSaidaTest
    {
        private IServicoDeDataDeSaida _servico;

        [TestInitialize]
        public void Setup()
        {
            _servico = FabricaDeServicos.FabricaDeServicoDeDataDeSaida.Crie();
        }

        [TestMethod]
        public void TesteSalvar()
        {
            var objTeste = FabricaDeDataDeSaida.Crie(DateTime.Now, 50);

            _servico.Salve(objTeste);

            var objDoServico = _servico.Obtenha(objTeste);

            Assert.AreEqual(objTeste.Data, objDoServico.Data);
            Assert.AreEqual(objTeste.ProbabilidadeDeComparecimento, objDoServico.ProbabilidadeDeComparecimento);
        }

        [TestMethod]
        public void TesteObtenhaTodos()
        {
            var objTeste = FabricaDeDataDeSaida.Crie(DateTime.Now, 50);

            _servico.Salve(objTeste);

            var listaDeObjetos = _servico.ObtenhaTodos();

            Assert.IsTrue(listaDeObjetos.Count() > 0);
        }
    }
}
