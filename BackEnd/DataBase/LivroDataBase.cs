using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.DataBase
{
    public class LivroDataBase
    {
        Models.livrariaContext db = new Models.livrariaContext();
        Utils.TbLivroPLivroResponseUtils conversor = new Utils.TbLivroPLivroResponseUtils();
        public Models.TbLivro salvarlivro(Models.Request.LivroRequest req){

            Utils.TbLivroPLivroResponseUtils conversor = new Utils.TbLivroPLivroResponseUtils();

            Models.TbLivro livro = conversor.ReqParaTabela(req);
            db.TbLivro.Add(livro);
            db.SaveChanges();

            return livro;            
        }   
        public void salvardelete(int id){

            Models.TbLivro livro = db.TbLivro.FirstOrDefault(x => x.IdLivro == id);
            db.TbLivro.Remove(livro);
            db.SaveChanges();
        }
        public List<Models.TbLivro> buscarlivros(){

            List<Models.TbLivro> livros = db.TbLivro.ToList();
            return livros;
        }

        public Models.TbLivro confirmaralteracao(Models.Request.LivroRequest req,int id)
        {
            Models.TbLivro altlivro = conversor.ReqParaTabela2(req,db.TbLivro.First(x => x.IdLivro == id));
            db.SaveChanges();
            return altlivro;
        }
    }
}