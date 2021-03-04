using System;
using System.ComponentModel.DataAnnotations;

namespace Gazin.Developer.WebApp.Models
{
    public class Developer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado")]
        [MinLength(3, ErrorMessage = "O nome deve conter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome deve conter no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sexo deve ser informado")]
        public char Sexo { get; set; }

        [Required(ErrorMessage = "A idade deve ser informada")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O hobby deve ser informado")]
        public string Hobby { get; set; }

        [Required(ErrorMessage = "A data de nascimento deve ser informada")]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
