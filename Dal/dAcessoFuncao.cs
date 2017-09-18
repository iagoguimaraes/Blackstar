using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class dAcessoFuncao
    {
        /// <summary>
        /// Insere acesso para algum nível de determinada função
        /// </summary>
        public static void InserirAcessoFuncao(oAcessoFuncao AcessoFuncao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idfuncao", AcessoFuncao.idfuncao.ToString());
                parameters.Add("p_idnivel", AcessoFuncao.idnivel.ToString());

                MySQLHelper.ExecuteDataTable("proc_ins_acessofuncao", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Resgatar todos os acessos de função registradas em sistema
        /// </summary>
        public static DataTable ResgatarTodosAcessoFuncoes()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_todosacessofuncoes");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Resgatar todos os acessos de função registradas em sistema de determinado nível
        /// </summary>
        public static DataTable ResgatarAcessoFuncoes(int idnivel)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idnivel", idnivel.ToString());

                return MySQLHelper.ExecuteDataTable("proc_sel_acessofuncao_bynivel", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove o acesso de determinada função de algum nível
        /// </summary>
        public static void RemoverAcessoFuncao(oAcessoFuncao AcessoFuncao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idfuncao", AcessoFuncao.idfuncao.ToString());
                parameters.Add("p_idnivel", AcessoFuncao.idnivel.ToString());

                MySQLHelper.ExecuteDataTable("proc_del_acessofuncao", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
