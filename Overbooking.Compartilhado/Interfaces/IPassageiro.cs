namespace Overbooking.Compartilhado.Interfaces
{
    public interface IPassageiro 
    {
        string Nome { get; set; }
        IIdadeDoPassageiro IdadePassageiro { get; set; }
    }
}