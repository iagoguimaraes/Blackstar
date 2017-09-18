using Business;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Blackstar.Controllers
{
    [RoutePrefix("sessao")]
    public class SessaoController : ApiController
    {
        [HttpPost]
        [Route("gerartoken")]
        public HttpResponseMessage GerarToken(oAutenticacao autenticacao)
        {
            try
            {
                oSessao Sessao = new oSessao();
                Sessao.ip = RequestHelper.getIP();
                Sessao.browser = HttpContext.Current.Request.Browser.Browser;
                Sessao.ismobile = HttpContext.Current.Request.Browser.IsMobileDevice;
                Sessao.platform = HttpContext.Current.Request.Browser.Platform;
                Sessao.device = HttpContext.Current.Request.Browser.MobileDeviceModel;

                string token = bSessao.Gerar(autenticacao.login, autenticacao.senha, Sessao);

                return Request.CreateResponse(HttpStatusCode.Accepted, token);
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

        [HttpPost]
        [Route("resgatar")]
        public HttpResponseMessage ResgatarSessao()
        {
            try
            {
                oSessao Sessao = bSessao.ResgatarSessao();
                return Request.CreateResponse(HttpStatusCode.OK, Sessao);
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
