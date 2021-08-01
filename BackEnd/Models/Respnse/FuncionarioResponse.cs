using System;

namespace BackEnd.Models.Respnse
{
    public class FuncionarioResponse
    {
        public int idfuncionario {get;set;}
        public string nome {get;set;}
        public DateTime datanascimento {get;set;}
        public string Telefone {get;set;}
        public string endereco {get;set;}
        public string email {get;set;}
        public decimal salario {get;set;}
    }
}