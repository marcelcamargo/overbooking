namespace Overbooking.Compartilhado.Interfaces
{
    public interface IIdadeDoPassageiro : IProbabilidadeDeComparecimento
    {
        int Idade { get; set; }
    }
}
