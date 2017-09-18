using Business;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Blackstar.Controllers
{
    [RoutePrefix("segmentacao")]
    public class SegmentacaoController : ApiController
    {

        [HttpPost]
        [Route("inserir")]
        public HttpResponseMessage InserirSegmentacao(oSegmentacao segmentacao)
        {
            try
            {
                bSessao.Validar();

                bSegmentacao.InserirSegmentacao(segmentacao);

                return Request.CreateResponse(HttpStatusCode.Created, "Segmentação criada com sucesso.");
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
        public HttpResponseMessage ResgatarTodasSegmentacoes()
        {
            try
            {
                bSessao.Validar();

                List<oSegmentacao> Segmentacoes = bSegmentacao.ResgatarTodasSegmentacoes();

                return Request.CreateResponse(HttpStatusCode.OK, Segmentacoes);
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
        [Route("resgatarativas")]
        public HttpResponseMessage ResgatarSegmentacoesAtivas()
        {
            try
            {
                bSessao.Validar();

                List<oSegmentacao> Segmentacoes = bSegmentacao.ResgatarSegmentacoes();

                return Request.CreateResponse(HttpStatusCode.OK, Segmentacoes);
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
        public HttpResponseMessage EditarSegmentacao(oSegmentacao segmentacao)
        {
            try
            {
                bSessao.Validar();

                bSegmentacao.EditarSegmentacao(segmentacao);

                return Request.CreateResponse(HttpStatusCode.OK, "Segmentação alterada com sucesso.");
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
