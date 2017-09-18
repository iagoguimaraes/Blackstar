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
    [RoutePrefix("email")]
    public class EmailController : ApiController
    {

        [HttpPost]
        [Route("inserir")]
        public HttpResponseMessage InserirEmail(oEmail email)
        {
            try
            {
                bSessao.Validar();

                oEmail mailcriado = bEmail.InserirEmail(email);

                return Request.CreateResponse(HttpStatusCode.Created, mailcriado);
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
        [Route("inativar")]
        public HttpResponseMessage InativarEmail([FromBody]int idmail)
        {
            try
            {
                bSessao.Validar();

                bEmail.Inativar(idmail);

                return Request.CreateResponse(HttpStatusCode.OK);
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
        [Route("reativar")]
        public HttpResponseMessage ReativarEmail([FromBody]int idmail)
        {
            try
            {
                bSessao.Validar();

                bEmail.Reativar(idmail);

                return Request.CreateResponse(HttpStatusCode.OK);
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
        [Route("preferencial")]
        public HttpResponseMessage EmailPreferencial([FromBody]int idmail)
        {
            try
            {
                bSessao.Validar();

                bEmail.EmailPreferencial(idmail);

                return Request.CreateResponse(HttpStatusCode.OK);
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
        [Route("naopreferencial")]
        public HttpResponseMessage EmailNaoPreferencial([FromBody]int idmail)
        {
            try
            {
                bSessao.Validar();

                bEmail.EmailNaoPreferencial(idmail);

                return Request.CreateResponse(HttpStatusCode.OK);
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
