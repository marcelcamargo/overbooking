using System;
using System.ComponentModel.DataAnnotations;

namespace Overbooking.Models
{
    public class PassageiroVooModel 
    {
        [Required(ErrorMessage = "O valor do nome é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O valor da idade é obrigatório", AllowEmptyStrings = false)]
        public int? Idade { get; set; }

        [Required(ErrorMessage = "O valor da origem é obrigatório", AllowEmptyStrings = false)]
        public string Origem { get; set; }
        [Required(ErrorMessage = "O valor do destino é obrigatório", AllowEmptyStrings = false)]
        public string Destino { get; set; }

        [Required(ErrorMessage = "O valor da data de saída é obrigatório", AllowEmptyStrings = false)]
        public DateTime? Data { get; set; }
    }
}