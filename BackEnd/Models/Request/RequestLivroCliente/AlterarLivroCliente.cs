using System;

namespace BackEnd.Models.Request.RequestLivroCliente
{
    public class AlterarLivroCliente
    {
        public int idcliente{get;set;}
        public int idlivro{get;set;}
        public DateTime datacompra {get;set;}
    }
}