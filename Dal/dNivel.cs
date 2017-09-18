using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class dNivel
    {
        /// <summary>
        /// Insere nível
        /// </summary>
        /// <param name="descricao"></param>
        public static void InserirNivel(oNivel Nivel)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_descricao", Nivel.descricao);

                MySQLHelper.ExecuteDataTable("proc_ins_nivel", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgatar todos os níveis registradas em sistema
        /// </summary>
        /// <returns></returns>
        public static DataTable ResgatarTodosNiveis()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_todosniveis");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgatar todos os níveis registradas em sistema ativos
        /// </summary>
        /// <returns></returns>
        public static DataTable ResgatarNiveis()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_niveis");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita o nível
        /// </summary>
        /// <param name="idseg"></param>
        /// <param name="descricao"></param>
        /// <param name="ativo"></param>
        public static void EditarNivel(oNivel Nivel)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idnivel", Nivel.idnivel.ToString());
                parameters.Add("p_descricao", Nivel.descricao);
                parameters.Add("p_ativo", Convert.ToInt32(Nivel.ativo).ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_nivel", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
