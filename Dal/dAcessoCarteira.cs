using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class dAcessoCarteira
    {
        /// <summary>
        /// Insere acesso para alguma segmentação de determinada carteira
        /// </summary>
        public static void InserirAcessoCarteira(oAcessoCarteira AcessoCarteira)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idcart", AcessoCarteira.idcart.ToString());
                parameters.Add("p_idseg", AcessoCarteira.idseg.ToString());

                MySQLHelper.ExecuteDataTable("proc_ins_acessocarteira", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Resgatar todos os acessos de carteira registradas em sistema
        /// </summary>
        public static DataTable ResgatarTodosAcessoCarteira()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_todosacessocarteira");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Resgatar todos os acessos de carteira registradas em sistema de determinada segmentação
        /// </summary>
        public static DataTable ResgatarAcessoCarteira(int idseg)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idseg", idseg.ToString());

                return MySQLHelper.ExecuteDataTable("proc_sel_acessocarteira_byseg", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove o acesso de determinada carteira de alguma segmentação
        /// </summary>
        public static void RemoverAcessoCarteira(oAcessoCarteira AcessoCarteira)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idcart", AcessoCarteira.idcart.ToString());
                parameters.Add("p_idseg", AcessoCarteira.idseg.ToString());

                MySQLHelper.ExecuteDataTable("proc_del_acessocarteira", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
