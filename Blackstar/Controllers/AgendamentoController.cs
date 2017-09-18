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
    [RoutePrefix("agendamento")]
    public class AgendamentoController : ApiController
    {

        [HttpPost]
        [Route("inserir")]
        public HttpResponseMessage InserirAgendamento(oAgendamento agendamento)
        {
            try
            {
                bSessao.Validar();

                oAgendamento agendamentocriado = bAgendamento.InserirAgendamento(agendamento);

                return Request.CreateResponse(HttpStatusCode.OK, agendamentocriado);
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
        public HttpResponseMessage EditarAgendamento(oAgendamento agendamento)
        {
            try
            {
                bSessao.Validar();

                bAgendamento.EditarAgendamento(agendamento);

                return Request.CreateResponse(HttpStatusCode.OK, "Agendamento alterado com sucesso.");
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
        public HttpResponseMessage ResgatarAgendamentos([FromBody]int idcart)
        {
            try
            {
                bSessao.Validar();

                List<oAgendamento> Agendamentos = bAgendamento.ResgatarAgendamentos(idcart);

                return Request.CreateResponse(HttpStatusCode.OK, Agendamentos);
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
        [Route("resgatarlocais")]
        public HttpResponseMessage ResgatarLocaisAgendamento([FromBody]int idcart)
        {
            try
            {
                bSessao.Validar();

                List<oLocalAgendamento> Agendamentos = bAgendamento.ResgatarLocaisAgendamento(idcart);

                return Request.CreateResponse(HttpStatusCode.OK, Agendamentos);
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
        [Route("resgatartipos")]
        public HttpResponseMessage ResgatarTiposAgendamento([FromBody]int idcart)
        {
            try
            {
                bSessao.Validar();

                List<oTipoAgendamento> Agendamentos = bAgendamento.ResgatarTiposAgendamento(idcart);

                return Request.CreateResponse(HttpStatusCode.OK, Agendamentos);
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
