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
    [RoutePrefix("acessocarteira")]
    public class AcessoCarteiraController : ApiController
    {

        [HttpPost]
        [Route("inserir")]
        public HttpResponseMessage InserirAcesso(oAcessoCarteira acesso)
        {
            try
            {
                bSessao.Validar();

                bAcessoCarteira.InserirAcessoCarteira(acesso);

                return Request.CreateResponse(HttpStatusCode.Created, "Acesso criado com sucesso.");
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
        public HttpResponseMessage ResgatarTodosAcessos()
        {
            try
            {
                bSessao.Validar();

                List<oAcessoCarteira> Acessos = bAcessoCarteira.ResgatarTodosAcessoCarteira();

                return Request.CreateResponse(HttpStatusCode.OK, Acessos);
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
        public HttpResponseMessage ResgatarAcessos([FromBody]int idseg)
        {
            try
            {
                bSessao.Validar();

                List<oAcessoCarteira> Acessos = bAcessoCarteira.ResgatarAcessoCarteira(idseg);

                return Request.CreateResponse(HttpStatusCode.OK, Acessos);
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
        [Route("remover")]
        public HttpResponseMessage RemoverAcesso(oAcessoCarteira acesso)
        {
            try
            {
                bSessao.Validar();

                bAcessoCarteira.RemoverAcessoCarteira(acesso);

                return Request.CreateResponse(HttpStatusCode.OK, "Acesso removido com sucesso.");
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
