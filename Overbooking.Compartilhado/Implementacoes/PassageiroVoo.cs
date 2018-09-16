using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class PassageiroVoo : Passageiro, IPassageiroVoo
    {
        public IRota Rota { get; set; }
        public IDataDeSaida DataDeSaida { get; set; }

        public PassageiroVoo(string nome, IIdadeDoPassageiro idade, IRota rota, IDataDeSaida dataDeSaida) : base(nome, idade)
        {
            Rota = rota;
            DataDeSaida = dataDeSaida;
        }
    }
}