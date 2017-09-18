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
    [RoutePrefix("nivel")]
    public class NivelController : ApiController
    {
        [HttpPost]
        [Route("inserir")]
        public HttpResponseMessage InserirNivel(oNivel nivel)
        {
            try
            {
                bSessao.Validar();

                bNivel.InserirNivel(nivel);

                return Request.CreateResponse(HttpStatusCode.Created, "Nível criado com sucesso.");
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
        [Route("resgatartodos")]
        public HttpResponseMessage ResgatarTodosNiveis()
        {
            try
            {
                bSessao.Validar();

                List<oNivel> Niveis = bNivel.ResgatarTodosNiveis();

                return Request.CreateResponse(HttpStatusCode.OK, Niveis);
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
        [Route("resgatarativos")]
        public HttpResponseMessage ResgatarNiveisAtivos()
        {
            try
            {
                bSessao.Validar();

                List<oNivel> Niveis = bNivel.ResgatarNiveis();

                return Request.CreateResponse(HttpStatusCode.OK, Niveis);
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
        [Route("editar")]
        public HttpResponseMessage EditarNivel(oNivel nivel)
        {
            try
            {
                bSessao.Validar();

                bNivel.EditarNivel(nivel);

                return Request.CreateResponse(HttpStatusCode.OK, "Nível alterado com sucesso.");
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
