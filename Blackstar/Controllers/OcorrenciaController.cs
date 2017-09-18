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
    [RoutePrefix("ocorrencia")]
    public class OcorrenciaController : ApiController
    {

        [HttpPost]
        [Route("inserir")]
        public HttpResponseMessage InserirOcorrencia(oOcorrencia Ocorrencia)
        {
            try
            {
                bSessao.Validar();

                bOcorrencia.InserirOcorrencia(Ocorrencia);

                return Request.CreateResponse(HttpStatusCode.Created, "Ocorrência criada com sucesso.");
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
        [Route("resgatartodas")]
        public HttpResponseMessage ResgatarTodasOcorrencias()
        {
            try
            {
                bSessao.Validar();

                List<oOcorrencia> Ocorrencias = bOcorrencia.ResgatarTodasOcorrencias();

                return Request.CreateResponse(HttpStatusCode.OK, Ocorrencias);
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
        public HttpResponseMessage EditarOcorrencia(oOcorrencia Ocorrencia)
        {
            try
            {
                bSessao.Validar();

                bOcorrencia.EditarOcorrencia(Ocorrencia);

                return Request.CreateResponse(HttpStatusCode.OK, "Ocorrência alterada com sucesso.");
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
