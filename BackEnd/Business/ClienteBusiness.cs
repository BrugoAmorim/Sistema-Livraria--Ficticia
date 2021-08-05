using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Business
{
    public class ClienteBusiness
    {
        DataBase.ClienteDataBase salvar = new DataBase.ClienteDataBase();

        public bool registrovalido(Models.Request.ClienteRequest req){

            Models.livrariaContext db = new Models.livrariaContext();

            List<Models.TbCliente> listaclientes = db.TbCliente.ToList();
            bool x = false;
            foreach(Models.TbCliente i in listaclientes)
            {
                if(i.Nome == req.nome && i.Email == req.email 
                && i.Telefone == req.telefone && i.Nascimento == req.nascimento)
                    x = true;
            }
            return x;

        }
        public bool validaralteracao(int id){

            Models.livrariaContext db = new Models.livrariaContext();
            bool x = false;

            if(db.TbCliente.FirstOrDefault(x => x.IdCliente == id) == null)
                x = true;

            return x;
        }
        public Models.TbCliente validarcliente(Models.Request.ClienteRequest req)
        {
            if(string.IsNullOrEmpty(req.nome))
                throw new ArgumentException("nome do cliente é obrigatorio");
            
            if(string.IsNullOrEmpty(req.email))
                throw new ArgumentException("email do cliente é obrigatorio");
            
            if(string.IsNullOrEmpty(req.telefone))
                throw new ArgumentException("telefone do cliente é obrigatorio");
            
            if(req.nascimento == null)
                throw new ArgumentException("data de nascimento é obrigatorio");
            
            if(registrovalido(req) == true)
                throw new ArgumentException("não é possivel inserir o mesmo registro");

            Models.TbCliente cliente = salvar.salvarcliente(req);
            return cliente;
        }
        public Models.TbCliente alterardadoscliente(Models.Request.ClienteRequest req,int id){

            if(registrovalido(req) == true)
                throw new ArgumentException("não é possivel inserir o mesmo registro");

            if(validaralteracao(id) == true)
                throw new ArgumentException("nao foi possivel encontrar esse registro");

            if(string.IsNullOrEmpty(req.nome))
                throw new ArgumentException("nome do cliente é obrigatorio");
            
            if(string.IsNullOrEmpty(req.email))
                throw new ArgumentException("email do cliente é obrigatorio");
            
            if(string.IsNullOrEmpty(req.telefone))
                throw new ArgumentException("telefone do cliente é obrigatorio");
            
            if(req.nascimento == null)
                throw new ArgumentException("data de nascimento é obrigatorio");

            Models.TbCliente x = salvar.alteraregistro(req,id);
            return x;
        }
        public void validardelete(int id){

            Models.livrariaContext db = new Models.livrariaContext();
            Models.TbCliente cliente = db.TbCliente.FirstOrDefault(x => x.IdCliente == id);

            if(cliente == null)
                throw new ArgumentException("não foi possivel achar este registro");

            salvar.confirmardelete(cliente.IdCliente);
        }
        public List<Models.TbCliente> procuraregistro(){

            List<Models.TbCliente> list = salvar.procurar();

            if(list.Count == 0)
                throw new ArgumentException("não encontramos nenhum registro");

            return list;
        }
        public List<Models.TbCliente> buscarcomfiltro(string nomepessoa){
            
            List<Models.TbCliente> clients = salvar.procurar();
            
            if(nomepessoa.Contains('0') ||
               nomepessoa.Contains('1') ||
               nomepessoa.Contains('2') ||
               nomepessoa.Contains('3') ||
               nomepessoa.Contains('4') ||
               nomepessoa.Contains('5') ||
               nomepessoa.Contains('6') ||
               nomepessoa.Contains('7') ||
               nomepessoa.Contains('8') ||
               nomepessoa.Contains('9'))
                throw new ArgumentException("Você colocou um caracter inválido");
            
            if(nomepessoa.Contains('!') ||
               nomepessoa.Contains('@') ||
               nomepessoa.Contains('#') ||
               nomepessoa.Contains('$') ||
               nomepessoa.Contains('%') ||
               nomepessoa.Contains('&') ||
               nomepessoa.Contains('*') ||
               nomepessoa.Contains('(') ||
               nomepessoa.Contains(')'))
                throw new ArgumentException("Você colocou um caracter inválido");

            string nm = "";
            foreach(char caracter in nomepessoa)
            {
                if(caracter == ' ')
                    continue;
                else
                    nm += caracter;
            }

            List<Models.TbCliente> lista2 = clients.Where(x => x.Nome.Substring(0,nm.Length).ToLower() == nm.ToLower()).ToList(); 
            if(lista2.Count == 0)
                throw new ArgumentException("não encontramos nenhum registro");
                
            return lista2;
        }


    }
}