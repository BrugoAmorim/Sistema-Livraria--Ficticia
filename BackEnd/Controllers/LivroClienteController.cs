using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroClienteController
    {
        Business.LivroClienteBusiness validacoes = new Business.LivroClienteBusiness();
        Utils.TbLivroClienteUtils conversor = new Utils.TbLivroClienteUtils();

        [HttpGet("buscarcompras")]
        public ActionResult<List<Models.Respnse.ResponseLivroCliente.ListaLivroCliente>> buscarcompras(){

            try{
            List<Models.TbLivroCliente> lista = validacoes.buscaregistros();
            List<Models.Respnse.ResponseLivroCliente.ListaLivroCliente> listares = new List<Models.Respnse.ResponseLivroCliente.ListaLivroCliente>();

            foreach(Models.TbLivroCliente i in lista)
            {
                listares.Add(conversor.TabelaparaResponseCustom(i));
            }
            return listares;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }

        [HttpPost("adicionarcompra")]
        public ActionResult<Models.Respnse.ResponseLivroCliente.LivroClienteResponse> adicionarcompra(Models.Request.RequestLivroCliente.LivroClienteRequest req){

            try{
                Models.TbLivroCliente compra = validacoes.validarcampos(req);
                Models.Respnse.ResponseLivroCliente.LivroClienteResponse res = conversor.TabelaparaResponse(compra);
                return res;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }

        [HttpDelete("apagarcompra/{idlivroclient}")]
        public ActionResult<string> apagarcompra(int idlivroclient)
        {
            try{
                validacoes.confirmardelete(idlivroclient);
                return "deletado com sucesso";
            }
            catch(System.Exception ex){
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }

        [HttpPut("alterarcompra/{idlivroclient}")]
        public ActionResult<Models.Respnse.ResponseLivroCliente.LivroClienteResponse> alterarcompra(Models.Request.RequestLivroCliente.AlterarLivroCliente req,int idlivroclient){

            try{
            Models.TbLivroCliente alterado = validacoes.validaralteracao(req,idlivroclient);
            Models.Respnse.ResponseLivroCliente.LivroClienteResponse res = conversor.TabelaparaResponse(alterado);
            return res;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }
    }
}