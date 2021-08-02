using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Business
{
    public class FuncionarioBusiness
    {
        DataBase.FuncionarioDataBase salvar = new DataBase.FuncionarioDataBase();
        
        public bool procurarfuncionario(int id){

            Models.livrariaContext db = new Models.livrariaContext();

            bool x = false;
            if(db.TbFuncionario.FirstOrDefault(x => x.IdFuncionario == id) == null)
                x = true;

            return x;
        }
        public bool acharregistro(Models.Request.FuncionarioRequest req){

            Models.livrariaContext db = new Models.livrariaContext();

            bool x = false;
            if(db.TbFuncionario.Any(x => 
               x.Nome       == req.nome           &&
               x.Nascimento == req.datanascimento &&
               x.Telefone   == req.telefone       &&
               x.Endereco   == req.endereco       &&
               x.Email      == req.email          &&
               x.Salario    == req.salario))
                x = true;

            return x;
        }

        public Models.TbFuncionario validarcampos(Models.Request.FuncionarioRequest req)
        {
            if(acharregistro(req) == true)
                throw new ArgumentException("nao é possivel inserir um registro já existente");

            if(string.IsNullOrEmpty(req.nome))
                throw new ArgumentException("nome é obrigatorio");
            
            if(string.IsNullOrEmpty(req.telefone))
                throw new ArgumentException("telefone é obrigatorio");
            
            if(string.IsNullOrEmpty(req.endereco))
                throw new ArgumentException("endereco é obrigatorio");
            
            if(string.IsNullOrEmpty(req.email))
                throw new ArgumentException("email é obrigatorio");
            
            if(req.salario <= 0)
                throw new ArgumentException("salario esta inválido");
            
            if(req.datanascimento == null)
                throw new ArgumentException("data de nascimento está inválida");

            Models.TbFuncionario func = salvar.inserirfunc(req);
            return func;
        }
        public void confirmardelete(int id){

            Models.livrariaContext db = new Models.livrariaContext();
            Models.TbFuncionario funcionario = db.TbFuncionario.FirstOrDefault(x => x.IdFuncionario == id);

            if(funcionario == null)
                throw new ArgumentException("não encontramos nenhum registro");

            salvar.deletarfunc(funcionario);
        }
        public Models.TbFuncionario alterarcamposfuncionario(Models.Request.FuncionarioRequest req,int id)
        {
            if(procurarfuncionario(id) == true)
                throw new ArgumentException("não foi possivel achar esse registro");

            if(string.IsNullOrEmpty(req.nome))
                throw new ArgumentException("nome é obrigatorio");
            
            if(string.IsNullOrEmpty(req.telefone))
                throw new ArgumentException("telefone é obrigatorio");
            
            if(string.IsNullOrEmpty(req.endereco))
                throw new ArgumentException("endereco é obrigatorio");
            
            if(string.IsNullOrEmpty(req.email))
                throw new ArgumentException("email é obrigatorio");
            
            if(req.salario <= 0)
                throw new ArgumentException("salario esta inválido");
            
            if(req.datanascimento == null)
                throw new ArgumentException("data de nascimento está inválida");
        
            Models.TbFuncionario ctx = salvar.confirmaralteracao(req,id);
            return ctx;
        }

        public List<Models.TbFuncionario> listarfuncionarios(){

            List<Models.TbFuncionario> x = salvar.listarfunc();

            if(x.Count < 0)
                throw new ArgumentException("não encontramos nenhum registro");

            return x;
        }
    }
}