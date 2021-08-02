using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.Models
{
    public partial class TbLivroCliente
    {
        public int IdLivroCliente { get; set; }
        public int? IdLivro { get; set; }
        public int? IdCliente { get; set; }
        public DateTime? DataCompra { get; set; }

        public virtual TbCliente IdClienteNavigation { get; set; }
        public virtual TbLivro IdLivroNavigation { get; set; }
    }
}
