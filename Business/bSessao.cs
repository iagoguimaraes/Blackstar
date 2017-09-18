using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class bSessao
    {

        /// <summary>
        /// Insere a sessão no banco e gera um token para o usuário acessar as funcionalidades da API
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <param name="oUserInfo"></param>
        /// <returns></returns>
        public static string Gerar(string login, string senha, oSessao Sessao)
        {
            try
            {
                int idusuario = 0;

                if (!bUsuario.UsuarioAtivo(login, senha, out idusuario))
                    throw new Exception("Usuário e/ou senha inválido(s).");

                // popula o idusuario
                Sessao.idusuario = idusuario;

                // insere sessao
                DataTable oSessao = dSessao.InserirSessao(Sessao);

                // resgata o idsessao
                string idsessao = oSessao.Rows[0]["idsessao"].ToString();

                // cryptografa
                string token = EncryptHelper.Encrypt(idsessao);

                return token;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar token: " + ex.Message);
            }
        }

        /// <summary>
        /// Verifica se o token é valido
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void Validar()
        {
            try
            {
                oSessao Sessao = ResgatarSessao();

                if (Sessao.dtexp < DateTime.Now)
                    throw new Exception("Sessão expirada");

                if (Sessao.ip != RequestHelper.getIP())
                    throw new Exception("IP inválido.");

                if (!Sessao.acesso.Any(metodo => metodo.caminho == RequestHelper.getMetodo()))
                    throw new Exception("Você não possui permissão para esta ação: " + RequestHelper.getMetodo());
            }
            catch (Exception ex)
            {
                throw new Exception("Acesso negado: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata a sessão do usuário
        /// </summary>
        public static oSessao ResgatarSessao()
        {
            try
            {
                int idsessao = ResgatarIDSessao();

                DataSet dsSessao = dSessao.ResgatarSessao(idsessao);
                DataTable dtSessao = dsSessao.Tables[0];
                DataTable dtAcesso = dsSessao.Tables[1];
                DataTable dtMenu = dsSessao.Tables[2];
                DataTable dtUsuario = dsSessao.Tables[3];

                if (dtSessao.Rows.Count == 0)
                    throw new Exception("Token inválido.");

                oSessao Sessao = new oSessao(dtSessao, dtAcesso, dtMenu, dtUsuario);

                return Sessao;
            }
            catch (Exception ex)
            {
                throw new Exception("Token inválido: " + ex.Message);
            }
        }

        /// <summary>
        /// registra requisição feita a API
        /// </summary>
        public static void RegistrarRequisicao()
        {
            try
            {
                oRequisicao Requisicao = new oRequisicao();
                dSessao.RegistrarRequisicao(Requisicao);
            }
            catch{}
        }

        /// <summary>
        /// descriptografa o token e retorna o id da sessao
        /// </summary>
        /// <returns></returns>
        public static int ResgatarIDSessao()
        {
            try
            {
                return Convert.ToInt32(EncryptHelper.Decrypt(RequestHelper.getToken()));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar id da sessão: " + ex.Message);
            }
        }


    }
}
