using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class dAcessoPagina
    {
        /// <summary>
        /// Insere acesso para algum nível de determinada página
        /// </summary>
        public static void InserirAcessoPagina(oAcessoPagina AcessoPagina)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idpagina", AcessoPagina.idpagina.ToString());
                parameters.Add("p_idnivel", AcessoPagina.idnivel.ToString());

                MySQLHelper.ExecuteDataTable("proc_ins_acessopagina", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Resgatar todos os acessos de página registradas em sistema
        /// </summary>
        public static DataTable ResgatarTodosAcessoPaginas()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_todosacessopaginas");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Resgatar todos os acessos de páginas registradas em sistema de determinado nível
        /// </summary>
        public static DataTable ResgatarAcessoPaginas(int idnivel)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idnivel", idnivel.ToString());

                return MySQLHelper.ExecuteDataTable("proc_sel_acessopagina_bynivel", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove o acesso de determinada página de algum nível
        /// </summary>
        public static void RemoverAcessoPagina(oAcessoPagina AcessoPagina)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idpagina", AcessoPagina.idpagina.ToString());
                parameters.Add("p_idnivel", AcessoPagina.idnivel.ToString());

                MySQLHelper.ExecuteDataTable("proc_del_acessopagina", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
