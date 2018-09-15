namespace Overbooking.Compartilhado.Interfaces
{
    public interface IRota : IProbabilidadeDeComparecimento
    {
        string Origem { get; set; }
        string Destino { get; set; }
    }
}