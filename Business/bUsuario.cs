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
    public class bUsuario
    {
        /// <summary>
        /// Verifica se o usuário é valido/existente/ativo (tem como parametro sainte o id do usuario)
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        public static bool UsuarioAtivo(string login, string senha, out int idusuario)
        {
            try
            {
                DataTable dtUsuario = dUsuario.ResgatarUsuario(login, senha);

                if (dtUsuario.Rows.Count > 0)
                {
                    idusuario = (int)dtUsuario.Rows[0]["idusuario"];
                    return true;
                }
                else
                {
                    idusuario = 0;
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar existência do usuário: " + ex.Message);
            }
        }

        /// <summary>
        /// retorna listagem com todos usuários do sistema
        /// </summary>
        /// <returns></returns>
        public static List<oUsuario> ResgatarTodosUsuarios()
        {
            try
            {
                DataTable dtUsuarios = dUsuario.ResgatarTodosUsuarios();

                List<oUsuario> Usuarios = new List<oUsuario>();

                foreach (DataRow row in dtUsuarios.Rows)
                    Usuarios.Add(new oUsuario(row));

                return Usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de usuários: " + ex.Message);
            }
        }

        /// <summary>
        /// retorna listagem com todos usuários do sistema ativos
        /// </summary>
        /// <returns></returns>
        public static List<oUsuario> ResgatarUsuarios()
        {
            try
            {
                DataTable dtUsuarios = dUsuario.ResgatarUsuarios();

                List<oUsuario> Usuarios = new List<oUsuario>();

                foreach (DataRow row in dtUsuarios.Rows)
                    Usuarios.Add(new oUsuario(row));

                return Usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de usuários: " + ex.Message);
            }
        }

        /// <summary>
        /// insere usuario no sistema
        /// </summary>
        public static void InserirUsuario(oUsuario Usuario)
        {
            try
            {
                // verificar se o login já existe
                if (ResgatarTodosUsuarios().Exists(user => user.login == Usuario.login))
                    throw new Exception("O nível informado já existe.");

                // verifica se o nivel existe
                if (!bNivel.ResgatarNiveis().Exists(niv => niv.idnivel == Usuario.idnivel))
                    throw new Exception("O nível desse usuário é inválido ou foi inativado");

                // verifica se a segmentação existe
                if (!bSegmentacao.ResgatarSegmentacoes().Exists(seg => seg.idseg == Usuario.idseg))
                    throw new Exception("A segmentação desse usuário é inválida ou foi inativada");

                dUsuario.InserirUsuario(Usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir usuário: " + ex.Message);
            }
        }

        /// <summary>
        /// edita dados do usuário do sistema
        /// </summary>
        public static void EditarUsuario(oUsuario Usuario)
        {
            try
            {
                // verificar se o login já existe
                if (ResgatarUsuarios().Exists(user => user.login == Usuario.login && user.idusuario != Usuario.idusuario))
                    throw new Exception("O login informado já existe.");

                dUsuario.EditarUsuario(Usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar usuário: " + ex.Message);
            }
        }

        /// <summary>
        /// muda a senha do usuário
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public static void MudarSenha(int idusuario, string senha)
        {
            try
            {
                dUsuario.MudarSenha(idusuario, senha);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao mudar senha: " + ex.Message);
            }
        }
    }
}
