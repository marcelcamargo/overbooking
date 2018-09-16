using Microsoft.VisualStudio.TestTools.UnitTesting;
using Overbooking.Compartilhado.Fabricas;
using Overbooking.Negocio.Fabricas;
using Overbooking.Negocio.Interfaces;
using System.Linq;

namespace Overbooking.Tests.Controllers
{
    [TestClass]
    public class ServicoDeRotaTest
    {
        private IServicoDeRota _servico;

        [TestInitialize]
        public void Setup()
        {
            _servico = FabricaDeServicos.FabricaDeServicoDeRota.Crie();
        }

        [TestMethod]
        public void TesteSalvar()
        {
            var objTeste = FabricaDeRota.Crie("GYN", "GRU", 99);

            _servico.Salve(objTeste);

            var objDoServico = _servico.Obtenha(objTeste);

            Assert.AreEqual(objTeste.Origem, objDoServico.Origem);
            Assert.AreEqual(objTeste.Destino, objDoServico.Destino);
            Assert.AreEqual(objTeste.ProbabilidadeDeComparecimento, objDoServico.ProbabilidadeDeComparecimento);
        }

        [TestMethod]
        public void TesteObtenhaTodos()
        {
            var objTeste = FabricaDeRota.Crie("GYN", "GRU");

            _servico.Salve(objTeste);

            var listaDeObjetos = _servico.ObtenhaTodos();

            Assert.IsTrue(listaDeObjetos.Count() > 0);
        }
    }
}
