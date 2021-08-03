using System;
using System.Collections;

namespace BackEnd.Models.Respnse.ResponseLivroCliente
{
    public class ListaLivroCliente
    {
        public int idlivrocompra {get;set;}
        public string nomecliente{get;set;}
        public string telefone {get;set;}
        public string nomelivro {get;set;}
        public decimal precolivro {get;set;}
        public DateTime datadacompra {get;set;}
    }
}