using System;

namespace BackEnd.Models.Request
{
    public class FuncionarioRequest
    {
        public string nome {get;set;}
        public DateTime datanascimento {get;set;}
        public string telefone {get;set;}
        public string endereco {get;set;}
        public string email {get;set;}
        public decimal salario {get;set;}
    }
}