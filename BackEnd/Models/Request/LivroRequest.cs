using System;

namespace BackEnd.Models.Request
{
    public class LivroRequest
    {
        public string nomelivro {get;set;}
        public string nomeautor {get;set;}
        public string linguagem {get;set;}
        public decimal preco {get;set;}
        public bool disponivel {get;set;}
        public DateTime publicado {get;set;}
        
    }
}