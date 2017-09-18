using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class dCarteira
    {
        /// <summary>
        /// Insere carteira
        /// </summary>
        /// <param name="descricao"></param>
        public static void InserirCarteira(oCarteira Carteira)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_descricao", Carteira.descricao);

                MySQLHelper.ExecuteDataTable("proc_ins_carteira", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgatar todos as carteiras registradas em sistema
        /// </summary>
        /// <returns></returns>
        public static DataTable ResgatarTodasCarteiras()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_todascarteiras");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgatar todos as carteiras registradas em sistema ativas
        /// </summary>
        /// <returns></returns>
        public static DataTable ResgatarCarteiras()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_carteiras");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita a carteira
        /// </summary>
        /// <param name="idcart"></param>
        /// <param name="descricao"></param>
        /// <param name="ativo"></param>
        public static void EditarCarteira(oCarteira Carteira)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idcart", Carteira.idcart.ToString());
                parameters.Add("p_descricao", Carteira.descricao);
                parameters.Add("p_ativo", Convert.ToInt32(Carteira.ativo).ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_carteira", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgata as carteiras do usuário que fez a requisição tem acesso
        /// </summary>
        /// <returns></returns>
        public static DataTable ResgatarMinhasCarteiras(int idseg)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idseg", idseg.ToString());
                return MySQLHelper.ExecuteDataTable("proc_sel_carteira_byseg", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
