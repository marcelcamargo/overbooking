using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class PassageiroVoo : Passageiro, IPassageiroVoo
    {
        public IRota Rota { get; set; }
        public IDataDeSaida DataDeSaida { get; set; }

        public string Identificador => $"{Rota.ToString()}_{DataDeSaida.ToString()}".Replace(" ", "_");
    }
}