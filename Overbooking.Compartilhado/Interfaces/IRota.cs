namespace Overbooking.Compartilhado.Interfaces
{
    public interface IRota : IParametroIndependente
    {
        string Origem { get; set; }
        string Destino { get; set; }
    }
}