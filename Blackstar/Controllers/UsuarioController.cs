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
    [RoutePrefix("usuario")]
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("inserir")]
        public HttpResponseMessage InserirUsuario(oUsuario usuario)
        {
            try
            {
                bSessao.Validar();

                bUsuario.InserirUsuario(usuario);

                return Request.CreateResponse(HttpStatusCode.Created, "Usuário criado com sucesso.");
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
        public HttpResponseMessage ResgatarTodosUsuarios()
        {
            try
            {
                bSessao.Validar();

                List<oUsuario> Usuarios = bUsuario.ResgatarTodosUsuarios();
             
                return Request.CreateResponse(HttpStatusCode.OK, Usuarios);
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
        public HttpResponseMessage EditarUsuario(oUsuario usuario)
        {
            try
            {
                bSessao.Validar();

                if (usuario.senha != null)
                    bUsuario.MudarSenha(usuario.idusuario, usuario.senha);

                bUsuario.EditarUsuario(usuario);

                return Request.CreateResponse(HttpStatusCode.OK, "Usuário alterado com sucesso.");
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
