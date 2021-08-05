using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FuncionariosController : ControllerBase
    {
        Utils.TbFuncionarioConversor converter = new Utils.TbFuncionarioConversor();
        Business.FuncionarioBusiness validacoes = new Business.FuncionarioBusiness();

        [HttpGet("listarfuncionarios")]
        public ActionResult<List<Models.Respnse.FuncionarioResponse>> consultarfuncionarios(){

            try{
                List<Models.TbFuncionario> func = validacoes.listarfuncionarios();
                List<Models.Respnse.FuncionarioResponse> listfuncionarios = new List<Models.Respnse.FuncionarioResponse>();

                foreach(TbFuncionario i in func)
                {
                    listfuncionarios.Add((converter.TabelaparaRes(i)));
                }
                return listfuncionarios;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }

        [HttpPost("cadastrarfunc")]
        public ActionResult<Models.Respnse.FuncionarioResponse> inserirfuncionario(Models.Request.FuncionarioRequest req)
        {
            try{
                Models.TbFuncionario ctx = validacoes.validarcampos(req);
                Models.Respnse.FuncionarioResponse res = converter.TabelaparaRes(ctx);
                return res;
            }
            catch(System.Exception ex){
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }
        
        [HttpPut("alteraregistro/{idfuncionario}")]
        public ActionResult<Models.Respnse.FuncionarioResponse> alteraregistrofunc(Models.Request.FuncionarioRequest req,int idfuncionario)
        {
            try{
                Models.TbFuncionario altfunc = validacoes.alterarcamposfuncionario(req,idfuncionario);
                Models.Respnse.FuncionarioResponse func = converter.TabelaparaRes(altfunc);
                return func;
            }
            catch(System.Exception ex)
            {
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }

        [HttpDelete("apagaregistro/{idfuncionario}")]
        public ActionResult<string> deletarfuncionario(int idfuncionario)
        {
            try{
                validacoes.confirmardelete(idfuncionario);
                return "deletado com sucesso";
            }
            catch(System.Exception ex){
                return new BadRequestObjectResult(
                    ex.Message + ", codigo de erro 400"
                );
            }
        }
    
        [HttpGet("filtrarfuncionarios")]
        public ActionResult<List<Models.Respnse.FuncionarioResponse>> filtrofunc(string nome)
        {
            try{
            List<Models.TbFuncionario> funclist = validacoes.buscarcomfiltro(nome);
            List<Models.Respnse.FuncionarioResponse> funcres = new List<Models.Respnse.FuncionarioResponse>();
            foreach(Models.TbFuncionario i in funclist)
            {
                funcres.Add(converter.TabelaparaRes(i));
            }
            return funcres;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    ex.Message
                );
            }
        }
    }
}