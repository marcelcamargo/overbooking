namespace Overbooking.Compartilhado.Interfaces
{
    public interface IPassageiroVoo  : IPassageiro
    {
        string Identificador { get; }
        IRota Rota { get; set; }
        IDataDeSaida DataDeSaida { get; set; }        
    }
}