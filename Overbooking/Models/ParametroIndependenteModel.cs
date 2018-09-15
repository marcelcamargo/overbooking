using System.ComponentModel.DataAnnotations;

namespace Overbooking.Models
{
    public class ParametroIndependenteModel
    {
        [Required(ErrorMessage = "O valor da PI é obrigatório", AllowEmptyStrings = false)]
        public int? ProbabilidadeDeComparecimento { get; set; }
    }
}