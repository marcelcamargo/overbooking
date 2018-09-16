using Microsoft.VisualStudio.TestTools.UnitTesting;
using Overbooking.Compartilhado.Fabricas;
using Overbooking.Negocio.Fabricas;
using Overbooking.Negocio.Interfaces;
using System.Linq;

namespace Overbooking.Tests.Controllers
{
    [TestClass]
    public class ServicoDeIdade
    {
        private IServicoDeIdade _servico;

        [TestInitialize]
        public void Setup()
        {
            _servico = FabricaDeServicos.FabricaDeServicoDeIdade.Crie();
        }

        [TestMethod]
        public void TesteSalvar()
        {
            var objTeste = FabricaDeIdadeDoPassageiro.Crie(27, 95);

            _servico.Salve(objTeste);

            var objDoServico = _servico.Obtenha(objTeste);

            Assert.AreEqual(objTeste.Idade, objDoServico.Idade);
            Assert.AreEqual(objTeste.ProbabilidadeDeComparecimento, objDoServico.ProbabilidadeDeComparecimento);
        }

        [TestMethod]
        public void TesteObtenhaTodos()
        {
            var objTeste = FabricaDeIdadeDoPassageiro.Crie(27, 95);

            _servico.Salve(objTeste);

            var listaDeObjetos = _servico.ObtenhaTodos();

            Assert.IsTrue(listaDeObjetos.Count() > 0);
        }
    }
}
