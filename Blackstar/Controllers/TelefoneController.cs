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
    [RoutePrefix("telefone")]
    public class TelefoneController : ApiController
    {


        [HttpPost]
        [Route("inserir")]
        public HttpResponseMessage InserirTelefone(oTelefone telefone)
        {
            try
            {
                bSessao.Validar();

                oTelefone telcriado = bTelefone.InserirTelefone(telefone);

                return Request.CreateResponse(HttpStatusCode.Created, telcriado);
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
        [Route("resgatartelefonescpf")]
        public HttpResponseMessage ResgatarTelefonesCPF([FromBody]long cpf)
        {
            try
            {
                bSessao.Validar();

                List<oTelefone> Telefones = bTelefone.ResgatarTelefonesCPF(cpf);

                return Request.CreateResponse(HttpStatusCode.OK, Telefones);
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
        public HttpResponseMessage InativarTelefone([FromBody]int idtel)
        {
            try
            {
                bSessao.Validar();

                bTelefone.Inativar(idtel);

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
        public HttpResponseMessage ReativarTelefone([FromBody]int idtel)
        {
            try
            {
                bSessao.Validar();

                bTelefone.Reativar(idtel);

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
        public HttpResponseMessage TelefonePreferencial([FromBody]int idtel)
        {
            try
            {
                bSessao.Validar();

                bTelefone.TelefonePreferencial(idtel);

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
        public HttpResponseMessage TelefoneNaoPreferencial([FromBody]int idtel)
        {
            try
            {
                bSessao.Validar();

                bTelefone.TelefoneNaoPreferencial(idtel);

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
        [Route("qualificar")]
        public HttpResponseMessage QualificarTelefone(oQualificacao Qualificacao)
        {
            try
            {
                bSessao.Validar();

                bTelefone.QualificarTelefone(Qualificacao);

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
        [Route("resgatarqualificacoes")]
        public HttpResponseMessage ResgatarQualificacoes()
        {
            try
            {
                bSessao.Validar();

                List<oQualificacao> Qualificacoes = bTelefone.ResgatarQualificacoes();

                return Request.CreateResponse(HttpStatusCode.OK, Qualificacoes);
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
