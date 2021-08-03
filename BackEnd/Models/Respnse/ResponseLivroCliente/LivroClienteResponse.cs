using System;

namespace BackEnd.Models.Respnse.ResponseLivroCliente
{
    public class LivroClienteResponse
    {
        public int idlivrocliente {get;set;}
        public int idlivro {get;set;}
        public int idcliente {get;set;}
        public DateTime datacompra {get;set;}
    }
}