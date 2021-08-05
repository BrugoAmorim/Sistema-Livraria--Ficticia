using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.DataBase
{
    public class ClienteDataBase
    {
        Models.livrariaContext db = new Models.livrariaContext();
        Utils.TbClienteUtils conversor = new Utils.TbClienteUtils();
        public Models.TbCliente salvarcliente(Models.Request.ClienteRequest req){

            Models.TbCliente cliente = conversor.ReqparaTabela(req);
            db.TbCliente.Add(cliente);
            db.SaveChanges();
            
            return cliente;
        }
        public Models.TbCliente alteraregistro(Models.Request.ClienteRequest req,int id){

            Utils.TbClienteUtils conversor = new Utils.TbClienteUtils();

            Models.TbCliente cliente = conversor.AlterarCliente(req,db.TbCliente.First(x => x.IdCliente == id));
            db.SaveChanges();
            return cliente;
        }
        public void confirmardelete(int id){

            List<Models.TbLivroCliente> comprascliente = db.TbLivroCliente.Where(x => x.IdCliente == id).ToList();
            foreach(Models.TbLivroCliente i in comprascliente)
            {
                db.Remove(i);
                db.SaveChanges();
            }

            Models.TbCliente client = db.TbCliente.First(x => x.IdCliente == id);
            db.TbCliente.Remove(client);
            db.SaveChanges();
        }

        public List<Models.TbCliente> procurar(){

            List<Models.TbCliente> lista = db.TbCliente.ToList();
            return lista;
        }
    }
}