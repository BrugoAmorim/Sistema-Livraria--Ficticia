using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;

namespace BackEnd.Utils
{
    public class TbClienteUtils
    {
        public TbCliente ReqparaTabela(Models.Request.ClienteRequest req)
        {
            TbCliente ctx = new TbCliente();

            ctx.Nome = req.nome;
            ctx.Telefone = req.telefone;
            ctx.Nascimento = req.nascimento;
            ctx.Email = req.email;
            return ctx;
        }
        public Models.Respnse.ClienteResponse TabelaparaRes(TbCliente req)
        {
            Models.Respnse.ClienteResponse ctx = new Models.Respnse.ClienteResponse();
        
            ctx.idcliente = req.IdCliente;
            ctx.nome = req.Nome;
            ctx.telefone = req.Telefone;
            ctx.nascimento = req.Nascimento;
            ctx.email = req.Email;
            return ctx;
        }
        public TbCliente AlterarCliente(Models.Request.ClienteRequest req,TbCliente ctx){

            ctx.Nome = req.nome;
            ctx.Telefone = req.telefone;
            ctx.Nascimento = req.nascimento;
            ctx.Email = req.email;
            return ctx;
        }
    }
}