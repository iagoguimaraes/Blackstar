using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class dTelefone
    {
        /// <summary>
        /// inserir o telefone no bd
        /// </summary>
        /// <param name="telefone"></param>
        /// <returns></returns>
        public static DataTable InserirTelefone(oTelefone telefone)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_ddd", telefone.ddd.ToString());
                parameters.Add("p_numero", telefone.numero.ToString());
                parameters.Add("p_idcontrato", telefone.idcontrato.ToString());
                parameters.Add("p_tipo", telefone.tipo);

                return MySQLHelper.ExecuteDataTable("proc_insr_telefone", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgatar os telefones de determinado cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static DataTable ResgatarTelefonesCPF(long cpf)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_cpf", cpf.ToString());

                return MySQLHelper.ExecuteDataTable("proc_sel_telefone_bycpf", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// inativar determinado telefone
        /// </summary>
        /// <param name="idtel"></param>
        public static void Inativar(int idtel)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idtel", idtel.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_inativar_telefone", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// reativar determinado telefone
        /// </summary>
        /// <param name="idtel"></param>
        public static void Reativar(int idtel)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idtel", idtel.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_reativar_telefone", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// marcar telefone como preferencial
        /// </summary>
        /// <param name="idtel"></param>
        public static void TelefonePreferencial(int idtel)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idtel", idtel.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_telpreferencial", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// marcar telefone como não preferencial
        /// </summary>
        /// <param name="idtel"></param>
        public static void TelefoneNaoPreferencial(int idtel)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idtel", idtel.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_telnaopreferencial", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// qualificar determinado telefone
        /// </summary>
        /// <param name="idtel"></param>
        /// <param name="idqualificacao"></param>
        public static void QualificarTelefone(oQualificacao Qualificacao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idtel", Qualificacao.idtel.ToString());
                parameters.Add("p_idqualificacao", Qualificacao.idqualificacao.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_qualificar_telefone", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgatar todas as qualificações existentes em sistema
        /// </summary>
        /// <returns></returns>
        public static DataTable ResgatarQualificacoes()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_qualificacoes");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
