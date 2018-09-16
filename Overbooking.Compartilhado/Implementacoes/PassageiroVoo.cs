using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class PassageiroVoo : Passageiro, IPassageiroVoo
    {
        public IRota Rota { get; set; }
        public IDataDeSaida DataDeSaida { get; set; }
    }
}