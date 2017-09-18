using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class dSessao
    {
        /// <summary>
        /// insere na tabela sessão informações sobre o usuário (login)
        /// </summary>
        /// <param name="idusuario"></param>
        /// <param name="oUserInfo"></param>
        /// <returns></returns>
        public static DataTable InserirSessao(oSessao Sessao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idusuario", Sessao.idusuario.ToString());
                parameters.Add("p_ip", Sessao.ip);
                parameters.Add("p_browser", Sessao.browser);
                parameters.Add("p_platform", Sessao.platform);
                parameters.Add("p_ismobile", Convert.ToInt32(Sessao.ismobile).ToString());
                parameters.Add("p_device", Sessao.device);

                return MySQLHelper.ExecuteDataTable("proc_insr_sessao", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Resgata informações da sessão
        /// </summary>
        /// <param name="idsessao"></param>
        /// <returns></returns>
        public static DataSet ResgatarSessao(int idsessao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idsessao", idsessao.ToString());

                return MySQLHelper.ExecuteDataSet("proc_sel_sessao", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Registra requisição feita à API
        /// </summary>
        /// <param name="idsessao"></param>
        /// <param name="path"></param>
        /// <param name="querystring"></param>
        /// <param name="tempo"></param>
        public static void RegistrarRequisicao(oRequisicao Requisicao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idsessao", Requisicao.idsessao.ToString());
                parameters.Add("p_path", Requisicao.path);
                parameters.Add("p_querystring", Requisicao.querystring);
                parameters.Add("p_tempo", Requisicao.tempo.ToString().Replace(",", "."));
                parameters.Add("p_dtreq", Requisicao.dtreq.ToString("yyyy-MM-dd HH:mm:ss"));

                MySQLHelper.ExecuteDataSet("proc_ins_requisicao", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
