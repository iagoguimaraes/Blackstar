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
    [RoutePrefix("pagina")]
    public class PaginaController : ApiController
    {

        [HttpPost]
        [Route("resgatartodas")]
        public HttpResponseMessage ResgatarTodasPaginas()
        {
            try
            {
                bSessao.Validar();

                List<oPagina> Funcoes = bPagina.ResgatarTodasPaginas();

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
