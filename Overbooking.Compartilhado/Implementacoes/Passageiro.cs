using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class Passageiro : IPassageiro
    {
        public string Nome { get; set; }
        public IIdadeDoPassageiro IdadePassageiro { get; set; }
    }
}