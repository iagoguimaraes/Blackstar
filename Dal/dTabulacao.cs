using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class dTabulacao
    {
        /// <summary>
        /// inserir tabulação no bd
        /// </summary>
        /// <param name="tabulacao"></param>
        /// <returns></returns>
        public static DataTable InserirTabulacao(oTabulacao tabulacao, oSessao sessao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idusuario", sessao.idusuario.ToString());
                parameters.Add("p_idsessao", sessao.idsessao.ToString());
                parameters.Add("p_idcontrato", tabulacao.idcontrato.ToString());
                parameters.Add("p_idocor", tabulacao.idocor.ToString());
                parameters.Add("p_dtagend", tabulacao.dtagend.ToString("yyyy-MM-dd HH:mm:ss"));
                parameters.Add("p_obs", tabulacao.obs);
                parameters.Add("p_idtel", tabulacao.idtel.ToString());
                parameters.Add("p_idend", tabulacao.idend.ToString());
                parameters.Add("p_idmail", tabulacao.idmail.ToString());

                return MySQLHelper.ExecuteDataTable("proc_insr_tabulacao", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
