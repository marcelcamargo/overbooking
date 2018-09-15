using System;
using System.ComponentModel.DataAnnotations;

namespace Overbooking.Models
{
    public class DataDeSaidaModel : ParametroIndependenteModel
    {
        [Required(ErrorMessage = "O valor da data de saída é obrigatório", AllowEmptyStrings = false)]
        public DateTime? Data { get; set; }
    }
}