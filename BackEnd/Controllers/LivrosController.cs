using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using BackEnd.Models.Request;
using BackEnd.Models.Respnse;
using BackEnd.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LivrosController
    {
        livrariaContext db = new livrariaContext();
        Business.LivroBusiness validacoes = new Business.LivroBusiness();   
        Utils.TbLivroPLivroResponseUtils conversor = new TbLivroPLivroResponseUtils(); 

        [HttpPost("cadastrar")]
        public ActionResult<LivroResponse> inserirlivro(LivroRequest req){
               
            try{
            Models.TbLivro livro = validacoes.validacoescadastro(req);
            LivroResponse res = conversor.TabelaParaRes(livro);
            return res;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }
    
        [HttpGet("consultarlivros")]
        public ActionResult<List<LivroResponse>> verlivros(){

            try{
            List<Models.TbLivro> livros = validacoes.consultarlivros();

            List<LivroResponse> listalivros = new List<LivroResponse>();

            foreach(TbLivro i in livros)
            {
                listalivros.Add(conversor.TabelaParaRes(i));
            }
            return listalivros;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }

        [HttpPut("alterarlivro/{idlivro}")]
        public ActionResult<LivroResponse> alterarlivro (LivroRequest req, int idlivro)
        {
            try{
            TbLivro livro = validacoes.confirmaralteracao(req,idlivro);
            LivroResponse resposta = conversor.TabelaParaRes(livro);
            return resposta;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }

        [HttpDelete("deletarlivro/{idlivro}")]
        public ActionResult<string> apagarlivro (int idlivro){

            try{
                validacoes.confirmardelete(idlivro);
                return "livro deletador com sucesso";
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }
    
        [HttpDelete("deletarlivros")]
        public ActionResult<string> deletarvarioslivros(Models.Request.DeletearLivrosResquest idslivros)
        {
            try
            {
                validacoes.deletarlistalivros(idslivros);   
                return "deletados com sucesso";
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message
                );
            }
        }
    
        [HttpGet("filtrarlivros")]
        public ActionResult<List<Models.Respnse.LivroResponse>> filtrarlivrospelaletra(string letra){

            try{
            List<Models.TbLivro> livros = validacoes.buscarcomfiltro(letra);
            
            string parametro = "";
            List<Models.Respnse.LivroResponse> livrofilter = new List<LivroResponse>();
            foreach(Models.TbLivro i in livros)
            {
                parametro = i.Nome.Substring(0,1);
                
                if(parametro == letra)
                    livrofilter.Add(conversor.TabelaParaRes(i));
                else if(parametro == letra.ToUpper())
                    livrofilter.Add(conversor.TabelaParaRes(i));
            }
            return livrofilter;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message
                );
            }
        }
    }
}