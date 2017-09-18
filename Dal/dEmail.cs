using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class dEmail
    {
        /// <summary>
        /// inserir email no bd
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static DataTable InserirEmail(oEmail email)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idcontrato", email.idcontrato.ToString());
                parameters.Add("p_email", email.email);

                return MySQLHelper.ExecuteDataTable("proc_insr_email", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// inativar determinado email
        /// </summary>
        /// <param name="idmail"></param>
        public static void Inativar(int idmail)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idmail", idmail.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_inativar_email", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// reativar determinado email
        /// </summary>
        /// <param name="idmail"></param>
        public static void Reativar(int idmail)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idmail", idmail.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_reativar_email", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// marcar determinado email como preferencial
        /// </summary>
        /// <param name="idmail"></param>
        public static void EmailPreferencial(int idmail)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idmail", idmail.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_mailpreferencial", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// marcar determinado email como não preferencial
        /// </summary>
        /// <param name="idmail"></param>
        public static void EmailNaoPreferencial(int idmail)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idmail", idmail.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_mailnaopreferencial", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
