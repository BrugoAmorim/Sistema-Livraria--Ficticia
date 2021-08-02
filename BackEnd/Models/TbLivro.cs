using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.Models
{
    public partial class TbLivro
    {
        public TbLivro()
        {
            TbLivroCliente = new HashSet<TbLivroCliente>();
        }

        public int IdLivro { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Linguagem { get; set; }
        public decimal Preco { get; set; }
        public bool Disponivel { get; set; }
        public DateTime Publicado { get; set; }

        public virtual ICollection<TbLivroCliente> TbLivroCliente { get; set; }
    }
}
