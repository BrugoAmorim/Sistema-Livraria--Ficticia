using System;

namespace BackEnd.Models.Respnse
{
    public class ClienteResponse
    {
        public int idcliente {get;set;}
        public string nome { get; set; }
        public DateTime nascimento { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

    }
}