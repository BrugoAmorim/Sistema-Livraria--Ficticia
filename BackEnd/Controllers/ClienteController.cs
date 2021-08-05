using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using BackEnd.Models;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController
    {
        Business.ClienteBusiness validacoes = new Business.ClienteBusiness();
        Utils.TbClienteUtils conversor = new Utils.TbClienteUtils();

        [HttpGet("listarclientes")]
        public ActionResult<List<Models.Respnse.ClienteResponse>> consultarclientes(){

            try{
                List<Models.TbCliente> clientes = validacoes.procuraregistro();
                List<Models.Respnse.ClienteResponse> res = new List<Models.Respnse.ClienteResponse>();

                foreach(TbCliente i in clientes)
                {
                    res.Add(conversor.TabelaparaRes(i));
                }
                return res;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }

        [HttpPost("cadastrarcliente")]
        public ActionResult<Models.Respnse.ClienteResponse> cadastrarcliente(Models.Request.ClienteRequest req)
        {
            try{
                Models.TbCliente cliente = validacoes.validarcliente(req);

                Models.Respnse.ClienteResponse res = conversor.TabelaparaRes(cliente);
                return res;
            }
            catch(System.Exception ex){
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }

        [HttpPut("alteraregistro/{idclient}")]
        public ActionResult<Models.Respnse.ClienteResponse> alterardadoscliente(Models.Request.ClienteRequest req, int idclient)
        {
            try{
                Models.TbCliente altcliente = validacoes.alterardadoscliente(req,idclient);
                Models.Respnse.ClienteResponse retorno = conversor.TabelaparaRes(altcliente);
                return retorno;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }

        [HttpDelete("deletarcliente/{idclient}")]
        public ActionResult<string> apagardadoscliente(int idclient){

            try{
                validacoes.validardelete(idclient);
                return "deletado com sucesso";
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }

        [HttpGet("filtrarclientes")]
        public ActionResult<List<Models.Respnse.ClienteResponse>> buscarclientes(string nome)
        {
            try{
            List<Models.TbCliente> clients = validacoes.buscarcomfiltro(nome);
            List<Models.Respnse.ClienteResponse> clientres = new List<Models.Respnse.ClienteResponse>();
            foreach(Models.TbCliente i in clients)
            {
                clientres.Add(conversor.TabelaparaRes(i));
            }
            return clientres;
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