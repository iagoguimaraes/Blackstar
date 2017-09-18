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
    [RoutePrefix("carteira")]
    public class CarteiraController : ApiController
    {


        [HttpPost]
        [Route("inserir")]
        public HttpResponseMessage InserirCarteira(oCarteira carteira)
        {
            try
            {
                bSessao.Validar();

                bCarteira.InserirCarteira(carteira);

                return Request.CreateResponse(HttpStatusCode.Created, "Carteira criada com sucesso.");
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
        public HttpResponseMessage ResgatarTodasCarteiras()
        {
            try
            {
                bSessao.Validar();

                List<oCarteira> Carteiras = bCarteira.ResgatarTodasCarteiras();

                return Request.CreateResponse(HttpStatusCode.OK, Carteiras);
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
        public HttpResponseMessage ResgatarCarteirasAtivas()
        {
            try
            {
                bSessao.Validar();

                List<oCarteira> Carteiras = bCarteira.ResgatarCarteiras();

                return Request.CreateResponse(HttpStatusCode.OK, Carteiras);
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
        [Route("resgatarminhas")]
        public HttpResponseMessage ResgatarMinhasCarteiras()
        {
            try
            {
                bSessao.Validar();

                // resgata a sessão para passar o usuário por parâmetro
                oSessao Sessao = bSessao.ResgatarSessao();

                List<oCarteira> Carteiras = bCarteira.ResgatarMinhasCarteiras(Sessao.usuario);

                return Request.CreateResponse(HttpStatusCode.OK, Carteiras);
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
        public HttpResponseMessage EditarCarteira(oCarteira carteira)
        {
            try
            {
                bSessao.Validar();

                bCarteira.EditarCarteira(carteira);

                return Request.CreateResponse(HttpStatusCode.OK, "Carteira alterado com sucesso.");
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
