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
    [RoutePrefix("endereco")]
    public class EnderecoController : ApiController
    {

        [HttpPost]
        [Route("inserir")]
        public HttpResponseMessage InserirEndereco(oEndereco endereco)
        {
            try
            {
                bSessao.Validar();

                oEndereco endcriado = bEndereco.InserirEndereco(endereco);

                return Request.CreateResponse(HttpStatusCode.Created, endcriado);
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
        [Route("resgatarenderecoscpf")]
        public HttpResponseMessage ResgatarEnderecosCPF([FromBody]long cpf)
        {
            try
            {
                bSessao.Validar();

                List<oEndereco> Enderecos = bEndereco.ResgatarEnderecosCPF(cpf);

                return Request.CreateResponse(HttpStatusCode.OK, Enderecos);
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
        public HttpResponseMessage InativarEndereco([FromBody]int idend)
        {
            try
            {
                bSessao.Validar();

                bEndereco.Inativar(idend);

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
        public HttpResponseMessage ReativarEndereco([FromBody]int idend)
        {
            try
            {
                bSessao.Validar();

                bEndereco.Reativar(idend);

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
        public HttpResponseMessage EnderecoPreferencial([FromBody]int idend)
        {
            try
            {
                bSessao.Validar();

                bEndereco.EnderecoPreferencial(idend);

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
        public HttpResponseMessage EnderecoNaoPreferencial([FromBody]int idend)
        {
            try
            {
                bSessao.Validar();

                bEndereco.EnderecoNaoPreferencial(idend);

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
