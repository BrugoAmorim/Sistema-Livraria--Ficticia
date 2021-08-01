using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController
    {
        livrariaContext db = new livrariaContext();
        Utils.TbClienteUtils conversor = new Utils.TbClienteUtils();

        [HttpGet("listarclientes")]
        public List<Models.Respnse.ClienteResponse> consultarclientes(){

            List<TbCliente> clientes = db.TbCliente.ToList();
            List<Models.Respnse.ClienteResponse> res = new List<Models.Respnse.ClienteResponse>();
            
            foreach(TbCliente i in clientes)
            {
                res.Add(conversor.TabelaparaRes(i));
            }
            return res;
        }
        [HttpPost("cadastrarcliente")]
        public Models.Respnse.ClienteResponse cadastrarcliente(Models.Request.ClienteRequest req)
        {
            TbCliente nvcliente = conversor.ReqparaTabela(req);

            db.TbCliente.Add(nvcliente);
            db.SaveChanges();

            Models.Respnse.ClienteResponse response = conversor.TabelaparaRes(nvcliente);
            return response;
        }
        [HttpPut("alteraregistro/{idclient}")]
        public Models.Respnse.ClienteResponse alterardadoscliente(Models.Request.ClienteRequest req, int idclient)
        {
            TbCliente altcliente = conversor.AlterarCliente(req,db.TbCliente.First(x => x.IdCliente == idclient));

            db.SaveChanges();

            Models.Respnse.ClienteResponse retorno = conversor.TabelaparaRes(altcliente);
            return retorno;
        }

        [HttpDelete("deletarcliente/{idclient}")]
        public void apagardadoscliente(int idclient){

            TbCliente cliente = db.TbCliente.First(x => x.IdCliente == idclient);
            db.TbCliente.Remove(cliente);
            db.SaveChanges();
        }
    }
}