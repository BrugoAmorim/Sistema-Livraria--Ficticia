using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.DataBase
{
    public class LivroClienteDataBase
    {
        Models.livrariaContext db = new Models.livrariaContext();
        Utils.TbLivroClienteUtils conversor = new Utils.TbLivroClienteUtils();

        public void confirmardelete(int id){

            Models.TbLivroCliente remover = db.TbLivroCliente.First(x => x.IdLivroCliente == id);
            db.TbLivroCliente.Remove(remover);
            db.SaveChanges();
        }

        public List<Models.TbLivroCliente> listarregistros(){

            List<Models.TbLivroCliente> lista = db.TbLivroCliente.Include(x => x.IdClienteNavigation).Include(x => x.IdLivroNavigation).ToList();
            return lista;
        }

        public Models.TbLivroCliente salvarcompra(Models.Request.RequestLivroCliente.LivroClienteRequest req)
        {
            Models.TbLivroCliente ctx = conversor.RequestparaTabela(req);
            db.TbLivroCliente.Add(ctx);
            db.SaveChanges();
            return ctx;
        }
    
        public Models.TbLivroCliente confirmaralteracao(Models.Request.RequestLivroCliente.AlterarLivroCliente req, int id)
        {
            Models.TbLivroCliente compra = conversor.RequestparaTabela2(req,db.TbLivroCliente.First(x => x.IdLivroCliente == id));
            
            db.SaveChanges();
            return compra;
        }
    }
}