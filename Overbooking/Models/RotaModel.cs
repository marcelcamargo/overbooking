using System;
using System.ComponentModel.DataAnnotations;

namespace Overbooking.Models
{
    public class RotaModel : ParametroIndependenteModel
    {
        [Required(ErrorMessage = "O valor da origem é obrigatório", AllowEmptyStrings = false)]
        public string Origem { get; set; }
        [Required(ErrorMessage = "O valor do destino é obrigatório", AllowEmptyStrings = false)]
        public string Destino { get; set; }
    }
}