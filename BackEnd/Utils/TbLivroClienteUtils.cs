using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Utils
{
    public class TbLivroClienteUtils
    {
        public Models.Respnse.ResponseLivroCliente.ListaLivroCliente TabelaparaResponseCustom(Models.TbLivroCliente req){

            Models.Respnse.ResponseLivroCliente.ListaLivroCliente res = new Models.Respnse.ResponseLivroCliente.ListaLivroCliente();

            res.idlivrocompra = req.IdLivroCliente;
            res.nomecliente = req.IdClienteNavigation.Nome;
            res.nomelivro = req.IdLivroNavigation.Nome;
            res.precolivro = req.IdLivroNavigation.Preco;
            res.telefone = req.IdClienteNavigation.Telefone;
            res.datadacompra = req.DataCompra;

            return res;
        }
        public Models.TbLivroCliente RequestparaTabela(Models.Request.RequestLivroCliente.LivroClienteRequest requisicao)
        {
            Models.TbLivroCliente ctx = new Models.TbLivroCliente();

            ctx.IdCliente = requisicao.idcliente;
            ctx.IdLivro = requisicao.idlivro;
            ctx.DataCompra = DateTime.Now;

            return ctx;
        }

        public Models.Respnse.ResponseLivroCliente.LivroClienteResponse TabelaparaResponse(Models.TbLivroCliente requisicao)
        {
            Models.Respnse.ResponseLivroCliente.LivroClienteResponse ctx = new Models.Respnse.ResponseLivroCliente.LivroClienteResponse();

            ctx.idlivrocliente = requisicao.IdLivroCliente;
            ctx.idlivro = requisicao.IdLivro;
            ctx.idcliente = requisicao.IdCliente;
            ctx.datacompra = requisicao.DataCompra;

            return ctx;
        }

        public Models.TbLivroCliente RequestparaTabela2(Models.Request.RequestLivroCliente.AlterarLivroCliente requisicao, Models.TbLivroCliente ctx)
        {
            ctx.IdLivro = requisicao.idlivro;
            ctx.IdCliente = requisicao.idcliente;
            ctx.DataCompra = requisicao.datacompra;

            return ctx;
        }
    }
}