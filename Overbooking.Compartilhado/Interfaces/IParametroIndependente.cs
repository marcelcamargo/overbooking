namespace Overbooking.Compartilhado.Interfaces
{
    public interface IParametroIndependente
    {
        string Identificador { get; set; }
        int ProbabilidadeDeComparecimento { get; set; }
    }
}
