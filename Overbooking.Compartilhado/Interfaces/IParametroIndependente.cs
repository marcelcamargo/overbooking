namespace Overbooking.Compartilhado.Interfaces
{
    public interface IParametroIndependente
    {
        string Identificador { get; set; }
        decimal? ProbabilidadeDeComparecimento { get; set; }
    }
}
