using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Business
{
    public class LivroClienteBusiness
    {
        DataBase.LivroClienteDataBase database = new DataBase.LivroClienteDataBase();

        //funcoes do verbo put
        public bool procurarcliente(Models.Request.RequestLivroCliente.AlterarLivroCliente req)
        {
            Models.livrariaContext db = new Models.livrariaContext();

            bool x = false;
            if(db.TbCliente.FirstOrDefault(x => x.IdCliente == req.idcliente) == null)
                x = true;
            return x;
        }
        public bool procurarlivro(Models.Request.RequestLivroCliente.AlterarLivroCliente req)
        {
            Models.livrariaContext db = new Models.livrariaContext();

            bool x = false;
            if(db.TbLivro.FirstOrDefault(x => x.IdLivro == req.idlivro) == null)
                x = true;
            return x;
        }
        
        
        //funcao do verbo get
        public bool procuraregistro(int id){

            Models.livrariaContext ctx = new Models.livrariaContext();

            bool x = false;
            if(ctx.TbLivroCliente.FirstOrDefault(x => x.IdLivroCliente == id) == null)
                x = true;
            return x;
        }
        
        //funcoes do verbo post
        public bool procurarcompra(Models.Request.RequestLivroCliente.LivroClienteRequest req){

            Models.livrariaContext db = new Models.livrariaContext();

            bool x = false;
            if(db.TbLivroCliente.Any(x => x.IdCliente == req.idcliente && x.IdLivro == req.idlivro))
                x = true;

            return x;
        }

        public bool procurarclient(Models.Request.RequestLivroCliente.LivroClienteRequest req)
        {
            Models.livrariaContext db = new Models.livrariaContext();

            bool x = false;
            if(db.TbCliente.FirstOrDefault(x => x.IdCliente == req.idcliente) == null)
                x = true;
            return x;
        }
        public bool livrosregistrados(Models.Request.RequestLivroCliente.LivroClienteRequest req)
        {
            Models.livrariaContext db = new Models.livrariaContext();

            bool x = false;
            if(db.TbLivro.FirstOrDefault(x => x.IdLivro == req.idlivro) == null)
                x = true;
            return x;
        }

        //funcao do verbo delete
        public void confirmardelete(int id){

            if(procuraregistro(id) == true)
                throw new ArgumentException("esse registro não existe");

            if(id <= 0)
                throw new ArgumentException("esse registro é inválido");

            database.confirmardelete(id);
        }

        public List<Models.TbLivroCliente> buscaregistros(){

            List<Models.TbLivroCliente> lista = database.listarregistros();

            if(lista.Count <= 0)
                throw new ArgumentException("não encontramos nenhum registro");

            return  lista;
        }
        public Models.TbLivroCliente validarcampos(Models.Request.RequestLivroCliente.LivroClienteRequest req)
        {
            if(procurarcompra(req) == true)
                throw new ArgumentException("o cliente já comprou este livro");

            if(req.idcliente <= 0 || procurarclient(req) == true)
                throw new ArgumentException("este cliente não existe");

            if(req.idlivro <= 0 || livrosregistrados(req) == true)
                throw new ArgumentException("este livro não existe");

            Models.TbLivroCliente salvo = database.salvarcompra(req);
            return salvo; 
        }
    
        public Models.TbLivroCliente validaralteracao(Models.Request.RequestLivroCliente.AlterarLivroCliente req, int id)
        {
            if(procuraregistro(id) == true)
                throw new ArgumentException("está compra não existe");

            if(req.idcliente <= 0 || procurarcliente(req) == true)
                throw new ArgumentException("não encontramos este cliente");

            if(req.idlivro <= 0 || procurarlivro(req) == true)
                throw new ArgumentException("não encontramos este livro");

            if(req.datacompra == null)
                throw new ArgumentException("a data da compra esta inválida");

            Models.TbLivroCliente x = database.confirmaralteracao(req,id);
            return x;
        }
    
    }
}