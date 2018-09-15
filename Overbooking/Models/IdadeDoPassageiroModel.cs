using System;
using System.ComponentModel.DataAnnotations;

namespace Overbooking.Models
{
    public class IdadeDoPassageiroModel : ParametroIndependenteModel
    {
        [Required(ErrorMessage = "O valor da idade é obrigatório", AllowEmptyStrings = false)]
        public int? Idade { get; set; }
    }
}