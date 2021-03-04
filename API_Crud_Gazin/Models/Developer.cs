using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Crud_Gazin.Models
{
    public class Developer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado")]
        [MinLength(3, ErrorMessage = "O nome deve conter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome deve conter no máximo 80 caracteres")]
        [RegularExpression(@"^[ a-zA-Z á]*$", ErrorMessage = "O nome deve conter apenas letras.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sexo deve ser informado")]
        public char Sexo { get; set; }

        [Required(ErrorMessage = "A idade deve ser informada")]
        [RegularExpression(@"^[ 1-9]*$", ErrorMessage = "A idade deve conter apenas números.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O hobby deve ser informado")]
        public string Hobby { get; set; }

        [Required(ErrorMessage = "A data nascimento deve ser informada")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
