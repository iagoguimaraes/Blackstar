using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class dAgendamento
    {
        /// <summary>
        /// inserir agendamento no bd
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        public static DataTable InserirAgendamento(oAgendamento agendamento, oSessao sessao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idusuario", sessao.idusuario.ToString());
                parameters.Add("p_idsessao", sessao.idsessao.ToString());
                parameters.Add("p_idcontrato", agendamento.idcontrato.ToString());
                parameters.Add("p_idtipoagendamento", agendamento.idtipoagendamento.ToString());
                parameters.Add("p_idlocal", agendamento.idlocal.ToString());
                parameters.Add("p_dtini", agendamento.dtini.ToString("yyyy-MM-dd HH:mm:ss"));
                parameters.Add("p_dtfim", agendamento.dtfim.ToString("yyyy-MM-dd HH:mm:ss"));
                parameters.Add("p_obs", agendamento.obs);

                return MySQLHelper.ExecuteDataTable("proc_insr_agendamento", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// modificar informações de um agendamento
        /// </summary>
        /// <param name="agendamento"></param>
        public static void EditarAgendamento(oAgendamento agendamento)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idagendamento", agendamento.idagendamento.ToString());
                parameters.Add("p_idtipoagendamento", agendamento.idtipoagendamento.ToString());
                parameters.Add("p_idlocal", agendamento.idlocal.ToString());
                parameters.Add("p_dtini", agendamento.dtini.ToString("yyyy-MM-dd HH:mm:ss"));
                parameters.Add("p_dtfim", agendamento.dtfim.ToString("yyyy-MM-dd HH:mm:ss"));
                parameters.Add("p_obs", agendamento.obs);
                parameters.Add("p_ativo", Convert.ToInt16(agendamento.ativo).ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_agendamento", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// verificar se existe agendamento no horário passado por parâmetro para a carteira deste contrato
        /// </summary>
        /// <param name="dtini"></param>
        /// <param name="dtfim"></param>
        /// <param name="idcontrato"></param>
        /// <returns></returns>
        public static DataTable ExisteAgendamento(DateTime dtini, DateTime dtfim, int idcontrato)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                parameters.Add("p_dtini", dtini.ToString("yyyy-MM-dd HH:mm:ss"));
                parameters.Add("p_dtfim", dtfim.ToString("yyyy-MM-dd HH:mm:ss"));
                parameters.Add("p_idcontrato", idcontrato.ToString());

                return MySQLHelper.ExecuteDataTable("proc_sel_agendamento_bydt", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgata os agendamentos de determinada carteira
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        public static DataTable ResgatarAgendamentos(int idcart)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idcart", idcart.ToString());

                return MySQLHelper.ExecuteDataTable("proc_sel_agendamento_bycart", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgata os locais de agendamentos de determinada carteira
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        public static DataTable ResgatarLocaisAgendamento(int idcart)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idcart", idcart.ToString());

                return MySQLHelper.ExecuteDataTable("proc_sel_localagendamento_bycart", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgata os tipos de agendamentos de determinada carteira
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        public static DataTable ResgatarTiposAgendamento(int idcart)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idcart", idcart.ToString());

                return MySQLHelper.ExecuteDataTable("proc_sel_tipoagendamento_bycart", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
