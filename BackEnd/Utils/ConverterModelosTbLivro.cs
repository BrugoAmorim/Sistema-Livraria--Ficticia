using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace API.Utils
{
    public class TbLivroPLivroResponseUtils
    {
        public Models.Respnse.LivroResponse TabelaParaRes(Models.TbLivro req)
        {
            Models.Respnse.LivroResponse x = new Models.Respnse.LivroResponse();

            x.disponivel = req.Disponivel;
            x.idlivro = req.IdLivro;
            x.linguagem = req.Linguagem;
            x.nomeautor = req.Autor;
            x.nomelivro = req.Nome;
            x.preco = req.Preco;
            x.publicado = req.Publicado;

            return x;
        }
        public Models.TbLivro ReqParaTabela2(Models.Request.LivroRequest req,Models.TbLivro ctx)
        {
            ctx.Autor = req.nomeautor;
            ctx.Nome = req.nomelivro;
            ctx.Disponivel = req.disponivel;
            ctx.Linguagem = req.linguagem;
            ctx.Preco = req.preco;
            ctx.Publicado = req.publicado;
            
            return ctx;
        }

        public Models.TbLivro ReqParaTabela(Models.Request.LivroRequest req)
        {
            Models.TbLivro ctx = new Models.TbLivro();   
                    
            ctx.Autor = req.nomeautor;
            ctx.Nome = req.nomelivro;
            ctx.Disponivel = req.disponivel;
            ctx.Linguagem = req.linguagem;
            ctx.Preco = req.preco;
            ctx.Publicado = req.publicado;
            
            return ctx;
        }
    }
}