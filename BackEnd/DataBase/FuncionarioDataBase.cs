using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.DataBase
{
    public class FuncionarioDataBase
    {
        Models.livrariaContext db = new Models.livrariaContext();
        Utils.TbFuncionarioConversor conversor = new Utils.TbFuncionarioConversor();
        public Models.TbFuncionario inserirfunc(Models.Request.FuncionarioRequest req)
        {
            Models.TbFuncionario nvfunc = conversor.ReqparaTabela(req);

            db.TbFuncionario.Add(nvfunc);
            db.SaveChanges();
            return nvfunc;
        }
        
        public void deletarfunc(Models.TbFuncionario func){

            db.RemoveRange(func);
            db.SaveChanges();
        }

        public Models.TbFuncionario confirmaralteracao(Models.Request.FuncionarioRequest req,int id)
        {
            Models.TbFuncionario func = conversor.RequestparaTabela(req, db.TbFuncionario.First(x => x.IdFuncionario == id));

            db.SaveChanges();
            return func;
        }

        public List<Models.TbFuncionario> listarfunc(){

            List<Models.TbFuncionario> func = db.TbFuncionario.ToList();
            return func;
        }
    }
}