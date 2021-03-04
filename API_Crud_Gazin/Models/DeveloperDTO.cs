using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Crud_Gazin.Models
{
    public class DeveloperDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public int Idade { get; set; }
        public string Hobby { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
