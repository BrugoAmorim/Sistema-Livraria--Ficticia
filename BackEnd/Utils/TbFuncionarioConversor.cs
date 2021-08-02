using System;
using System.Collections;
using BackEnd.Models;

namespace BackEnd.Utils
{
    public class TbFuncionarioConversor
    {
        public TbFuncionario ReqparaTabela(Models.Request.FuncionarioRequest req)
        {
            TbFuncionario func = new TbFuncionario();

            func.Nome = req.nome;
            func.Nascimento = req.datanascimento;
            func.Salario = req.salario;
            func.Telefone = req.telefone;
            func.Email = req.email;
            func.Endereco = req.endereco;
            
            return func;
        }
        public Models.Respnse.FuncionarioResponse TabelaparaRes(TbFuncionario req)
        {
            Models.Respnse.FuncionarioResponse funcres = new Models.Respnse.FuncionarioResponse();

            funcres.idfuncionario = req.IdFuncionario;
            funcres.nome = req.Nome;
            funcres.datanascimento = req.Nascimento;
            funcres.salario = req.Salario;
            funcres.Telefone = req.Telefone;
            funcres.email = req.Email;
            funcres.endereco = req.Endereco;

            return funcres;
        }
        public TbFuncionario RequestparaTabela(Models.Request.FuncionarioRequest req, TbFuncionario func)
        {
            func.Nome = req.nome;
            func.Nascimento = req.datanascimento;
            func.Salario = req.salario;
            func.Telefone = req.telefone;
            func.Email = req.email;
            func.Endereco = req.endereco;

            return func;
        }
    }
}