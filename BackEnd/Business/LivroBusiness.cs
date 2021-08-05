using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;

namespace BackEnd.Business
{
    public class LivroBusiness
    {
        DataBase.LivroDataBase databaselivro = new DataBase.LivroDataBase();

        public bool validarcampos(Models.Request.LivroRequest req){

            Models.livrariaContext db = new livrariaContext();

            bool x = false; 
            if(db.TbLivro.Any(x => x.Nome == req.nomelivro    &&
                    x.Autor      == req.nomeautor    &&
                    x.Linguagem  == req.linguagem    &&
                    x.Disponivel == req.disponivel   &&
                    x.Preco      == req.preco        &&
                    x.Publicado  == req.publicado))
            x = true;

            return x;
        }
        public void confirmardelete(int id){

            Models.livrariaContext db = new livrariaContext();

            if(db.TbLivro.FirstOrDefault(x => x.IdLivro == id) == null)
                throw new ArgumentException("este livro nao existe");

            databaselivro.salvardelete(id);
        }

        public Models.TbLivro validacoescadastro(Models.Request.LivroRequest req)
        {
            if(validarcampos(req) == true)
                throw new ArgumentException("não é possivel inserir o mesmo livro");

            if(string.IsNullOrEmpty(req.nomelivro))
                throw new ArgumentException("nome do livro é obrigatorio");

            if(string.IsNullOrEmpty(req.nomeautor))
                throw new ArgumentException("nome do autor é obrigatorio");
            
            if(req.publicado == null)
                throw new ArgumentException("data de publicação é obrigatorio");
            
            if(string.IsNullOrEmpty(req.linguagem))
                throw new ArgumentException("liguagem do livro é obrigatorio");
            
            if(req.preco <= 0)
                throw new ArgumentException("preço do livro é obrigatorio");

            Models.TbLivro livroinserido = databaselivro.salvarlivro(req);
            return livroinserido;
        }
        public List<Models.TbLivro> consultarlivros(){

            List<Models.TbLivro> liv = databaselivro.buscarlivros();
           
            if(liv.Count < 0)
                throw new ArgumentException("não encontramos nenhum registro"); 

            return liv;
        }
        public bool procurarreg(int id){

            List<Models.TbLivro> liv = databaselivro.buscarlivros();

            bool x = false;
            if(liv.FirstOrDefault(x => x.IdLivro == id) == null)
                x = true;
            
            return x;
        }
        
        public Models.TbLivro confirmaralteracao(Models.Request.LivroRequest req,int id)
        {

            if(procurarreg(id) == true)
                throw new ArgumentException("este livro não existe");
            
            if(validarcampos(req) == true)
                throw new ArgumentException("não é possivel inserir o mesmo livro");

            if(string.IsNullOrEmpty(req.nomelivro))
                throw new ArgumentException("nome do livro é obrigatorio");

            if(string.IsNullOrEmpty(req.nomeautor))
                throw new ArgumentException("nome do autor é obrigatorio");
            
            if(req.publicado == null)
                throw new ArgumentException("data de publicação é obrigatorio");
            
            if(string.IsNullOrEmpty(req.linguagem))
                throw new ArgumentException("liguagem do livro é obrigatorio");
            
            if(req.preco <= 0)
                throw new ArgumentException("preço do livro é inválido");

            Models.TbLivro livroalterado = databaselivro.confirmaralteracao(req,id);
            return livroalterado;
        }

        public void deletarlistalivros(Models.Request.DeletearLivrosResquest idslivros)
        {
            List<Models.TbLivro> list = databaselivro.buscarlivros();

            foreach(int i in idslivros.ids){
                Models.TbLivro x = list.FirstOrDefault(x => x.IdLivro == i);
                if(x == null)
                    throw new ArgumentException("um ou mais livros não foram encontrados");
            }
            
            databaselivro.deletarlivros(idslivros);
        }

        public List<Models.TbLivro> buscarcomfiltro(string letra)
        {
            List<Models.TbLivro> livs = databaselivro.buscarlivros();
            if(letra == "0" || letra == "1" || letra == "2" ||
               letra == "3" || letra == "4" || letra == "5" ||
               letra == "6" || letra == "8" || letra == "9" 
               )
               throw new ArgumentException("está letra é inválida");
            
            if(letra == "!" || letra == "@" || letra == "#" ||
               letra == "$" || letra == "%" || letra == "&" ||
               letra == "*"  
               )
               throw new ArgumentException("está letra é inválida");

            if(letra.Length > 1)
                throw new ArgumentException("numero de caracteres inválido");
        
            List<Models.TbLivro> livrs = livs.Where(x => x.Nome.Substring(0,1) == letra).ToList(); 
            List<Models.TbLivro> livrs2 = livs.Where(x => x.Nome.Substring(0,1).ToLower() == letra).ToList(); 
            if(livrs.Count == 0 && livrs2.Count == 0)
                throw new ArgumentException("não encontramos nenhum registro");

            return livs;
        }
    }
}