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
    [RoutePrefix("acessofuncao")]
    public class AcessoFuncaoController : ApiController
    {

        [HttpPost]
        [Route("inserir")]
        public HttpResponseMessage InserirAcesso(oAcessoFuncao acesso)
        {
            try
            {
                bSessao.Validar();

                bAcessoFuncao.InserirAcessoFuncao(acesso);

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
        [Route("resgatartodas")]
        public HttpResponseMessage ResgatarTodosAcessos()
        {
            try
            {
                bSessao.Validar();

                List<oAcessoFuncao> Acessos = bAcessoFuncao.ResgatarTodosAcessoFuncoes();

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
        public HttpResponseMessage ResgatarAcessos([FromBody]int idnivel)
        {
            try
            {
                bSessao.Validar();

                List<oAcessoFuncao> Acessos = bAcessoFuncao.ResgatarAcessoFuncoes(idnivel);

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
        public HttpResponseMessage RemoverAcesso(oAcessoFuncao acesso)
        {
            try
            {
                bSessao.Validar();

                bAcessoFuncao.RemoverAcessoFuncao(acesso);

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
