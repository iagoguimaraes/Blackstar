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
    [RoutePrefix("contrato")]
    public class ContratoController : ApiController
    {

        [HttpPost]
        [Route("buscar")]
        public HttpResponseMessage BuscarContratos(oAcionamento acionamento)
        {
            try
            {
                bSessao.Validar();

                List<oContrato> Contratos = bContrato.Buscar(acionamento);

                return Request.CreateResponse(HttpStatusCode.OK, Contratos);
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
        [Route("ficha")]
        public HttpResponseMessage ResgatarFicha([FromBody]int idcontrato)
        {
            try
            {
                bSessao.Validar();

                oFicha Ficha = bContrato.ResgatarFicha(idcontrato);

                return Request.CreateResponse(HttpStatusCode.OK, Ficha);
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
        [Route("inserir")]
        public HttpResponseMessage InserirContrato(oContrato contrato)
        {
            try
            {
                bSessao.Validar();

                int idcontrato = bContrato.InserirContrato(contrato);

                return Request.CreateResponse(HttpStatusCode.OK, idcontrato);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            finally
            {
                //bSessao.RegistrarRequisicao();
            }
        }


    }
}
