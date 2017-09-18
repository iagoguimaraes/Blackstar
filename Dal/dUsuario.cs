using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class dUsuario
    {
        /// <summary>
        /// Resgata informações do usuário pelo login e senha
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static DataTable ResgatarUsuario(string login, string senha)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_login", login);
                parameters.Add("p_senha", senha);

                return MySQLHelper.ExecuteDataTable("proc_sel_usuario_bylogin", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgata todos usuários do sistema
        /// </summary>
        /// <returns></returns>
        public static DataTable ResgatarTodosUsuarios()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_todosusuarios");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgata todos usuários do sistema ativos
        /// </summary>
        /// <returns></returns>
        public static DataTable ResgatarUsuarios()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_usuarios");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// insere um usuario na base
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <param name="idacesso"></param>
        /// <param name="idseg"></param>
        /// <param name="nome"></param>
        /// <param name="email"></param>
        public static void InserirUsuario(oUsuario Usuario)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_login", Usuario.login);
                parameters.Add("p_senha", Usuario.senha);
                parameters.Add("p_idnivel", Usuario.idnivel.ToString());
                parameters.Add("p_idseg", Usuario.idseg.ToString());
                parameters.Add("p_nome", Usuario.nome);
                parameters.Add("p_email", Usuario.email);

                MySQLHelper.ExecuteDataTable("proc_ins_usuario", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// edita um usuário da base
        /// </summary>
        /// <param name="idusuario"></param>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <param name="idacesso"></param>
        /// <param name="idseg"></param>
        /// <param name="nome"></param>
        /// <param name="email"></param>
        public static void EditarUsuario(oUsuario Usuario)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idusuario", Usuario.idusuario.ToString());
                parameters.Add("p_login", Usuario.login);
                parameters.Add("p_idnivel", Usuario.idnivel.ToString());
                parameters.Add("p_idseg", Usuario.idseg.ToString());
                parameters.Add("p_nome", Usuario.nome);
                parameters.Add("p_email", Usuario.email);
                parameters.Add("p_ativo", Convert.ToInt32(Usuario.ativo).ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_usuario", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// muda a senha do usuário
        /// </summary>
        /// <param name="idusuario"></param>
        /// <param name="senha"></param>
        public static void MudarSenha(int idusuario, string senha)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idusuario", idusuario.ToString());
                parameters.Add("p_senha", senha);
                MySQLHelper.ExecuteDataTable("proc_upd_senha", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
