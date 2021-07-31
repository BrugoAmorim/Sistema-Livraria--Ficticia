using System;

namespace API.Models.Respnse
{
    public class LivroResponse
    {
        public int idlivro {get;set;}
        public string nomelivro {get;set;}
        public string nomeautor {get;set;}
        public string linguagem {get;set;}
        public decimal preco {get;set;}
        public bool disponivel {get;set;}
        public DateTime publicado {get;set;}
        
    }
}