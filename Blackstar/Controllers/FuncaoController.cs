using Business;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blackstar.Controllers
{
    [RoutePrefix("funcao")]
    public class FuncaoController : ApiController
    {
        [HttpPost]
        [Route("resgatartodas")]
        public HttpResponseMessage ResgatarTodasFuncoes()
        {
            try
            {
                bSessao.Validar();

                List<oFuncao> Funcoes = bFuncao.ResgatarTodasFuncoes();

                return Request.CreateResponse(HttpStatusCode.OK, Funcoes);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            finally
            {
                bSessao.RegistrarRequisicao();
            }
        }
    }
}
