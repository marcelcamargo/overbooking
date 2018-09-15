using Overbooking.Compartilhado.Interfaces;

namespace Overbooking.Compartilhado.Implementacoes
{
    public class ParametroIndependente : IParametroIndependente
    {
        public string Identificador { get; set; }
        public decimal? ProbabilidadeDeComparecimento { get; set; }

        public override bool Equals(object obj)
        {
            return obj != null && 
                   obj.GetType() == typeof(ParametroIndependente) && 
                   ((ParametroIndependente)obj).Identificador == this.Identificador;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    
}
