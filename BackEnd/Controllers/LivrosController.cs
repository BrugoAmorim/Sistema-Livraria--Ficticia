using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LivrosController
    {
        Models.livrariaContext db = new Models.livrariaContext();

        [HttpPost]
        public Models.Respnse.LivroResponse inserirlivro(Models.Request.LivroRequest req){

            Utils.TbLivroPLivroResponseUtils conversor = new Utils.TbLivroPLivroResponseUtils();
            
            Models.TbLivro nvlivro = conversor.ReqParaTabela(req);
            db.TbLivro.Add(nvlivro);
            db.SaveChanges();

            Models.Respnse.LivroResponse retorno = conversor.TabelaParaRes(nvlivro);
            return retorno;   
        }
    
        [HttpGet("consultarlivros")]
        public List<Models.Respnse.LivroResponse> verlivros(){

            List<Models.TbLivro> livros = db.TbLivro.ToList();
            Models.Respnse.LivroResponse res = new Models.Respnse.LivroResponse();
            Utils.TbLivroPLivroResponseUtils conversor = new Utils.TbLivroPLivroResponseUtils();

            List<Models.Respnse.LivroResponse> listalivros = new List<Models.Respnse.LivroResponse>();

            foreach(Models.TbLivro i in livros)
            {
                listalivros.Add(conversor.TabelaParaRes(i));
            }
            return listalivros;
        }

        [HttpPut("alterarlivro/{idlivro}")]
        public Models.Respnse.LivroResponse alterarlivro (Models.Request.LivroRequest req, int idlivro)
        {
            Utils.TbLivroPLivroResponseUtils conversor = new Utils.TbLivroPLivroResponseUtils();
            
            Models.TbLivro livro = conversor.ReqParaTabela2
                    (req,db.TbLivro.First(x => x.IdLivro == idlivro));

            db.SaveChanges();            

            Models.Respnse.LivroResponse resposta = conversor.TabelaParaRes(livro);
            return resposta;
        }

        [HttpDelete("deletarlivro/{idlivro}")]
        public void apagarlivro (int idlivro){

            Models.TbLivro modelo = db.TbLivro.First(x => x.IdLivro == idlivro);

            db.TbLivro.Remove(modelo);
            db.SaveChanges();
        }
    }
}