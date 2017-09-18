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
    [RoutePrefix("tabulacao")]
    public class TabulacaoController : ApiController
    {

        [HttpPost]
        [Route("inserir")]
        public HttpResponseMessage InserirTabulacao(oTabulacao tabulacao)
        {
            try
            {
                bSessao.Validar();

                oTabulacao tabcriada = bTabulacao.InserirTabulacao(tabulacao);

                return Request.CreateResponse(HttpStatusCode.OK, tabcriada);
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
