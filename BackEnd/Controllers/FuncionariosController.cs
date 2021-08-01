using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using API.Models;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FuncionariosController : ControllerBase
    {
        livrariaContext db = new livrariaContext();
        Utils.TbFuncionarioConversor converter = new Utils.TbFuncionarioConversor();
        [HttpGet("listarfuncionarios")]
        public List<Models.Respnse.FuncionarioResponse> consultarfuncionarios(){

            List<TbFuncionario> func = db.TbFuncionario.ToList();
            List<Models.Respnse.FuncionarioResponse> listfuncionarios = new List<Models.Respnse.FuncionarioResponse>();

            foreach(TbFuncionario i in func)
            {
                listfuncionarios.Add((converter.TabelaparaRes(i)));
            }
            return listfuncionarios;
        }

        [HttpPost("cadastrarfunc")]
        public Models.Respnse.FuncionarioResponse inserirfuncionario(Models.Request.FuncionarioRequest req)
        {
            TbFuncionario nvfunc = converter.ReqparaTabela(req);
            
            db.TbFuncionario.Add(nvfunc);
            db.SaveChanges();

            Models.Respnse.FuncionarioResponse res = converter.TabelaparaRes(nvfunc);
            return res;
        }
        
        [HttpPut("alteraregistro/{idfuncionario}")]
        public Models.Respnse.FuncionarioResponse alteraregistrofunc(Models.Request.FuncionarioRequest request,int idfuncionario)
        {
            TbFuncionario altfunc = converter.RequestparaTabela(request,db.TbFuncionario.First(x => x.IdFuncionario == idfuncionario));

            db.SaveChanges();

            Models.Respnse.FuncionarioResponse func = converter.TabelaparaRes(altfunc);
            return func;
        }

        [HttpDelete("apagaregistro/{idfuncionario}")]
        public void deletarfuncionario(int idfuncionario)
        {
            TbFuncionario func = db.TbFuncionario.First(x => x.IdFuncionario == idfuncionario);

            db.TbFuncionario.Remove(func);
            db.SaveChanges();
        }
    }
}