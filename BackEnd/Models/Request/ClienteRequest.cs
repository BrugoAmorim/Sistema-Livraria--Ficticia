using System;

namespace BackEnd.Models.Request
{
    public class ClienteRequest
    {
        public string nome { get; set; }
        public DateTime nascimento { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

    }
}