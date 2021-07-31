using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class TbFuncionario
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public decimal? Salario { get; set; }
    }
}
