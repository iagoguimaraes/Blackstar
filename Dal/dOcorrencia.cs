using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class dOcorrencia
    {
        /// <summary>
        /// Insere ocorrencia
        /// </summary>
        public static void InserirOcorrencia(oOcorrencia Ocorrencia)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                parameters.Add("p_descricao", Ocorrencia.descricao);
                parameters.Add("p_classificacao", Ocorrencia.classificacao);
                parameters.Add("p_agendavel", Convert.ToInt32(Ocorrencia.agendavel).ToString());
                parameters.Add("p_agnd_padrao", Ocorrencia.agnd_padrao.ToString());
                parameters.Add("p_agnd_max", Ocorrencia.agnd_max.ToString());
                parameters.Add("p_idcart", Ocorrencia.idcart.ToString());

                MySQLHelper.ExecuteDataTable("proc_ins_ocorrencia", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgatar todas ocorrencias registradas em sistema
        /// </summary>
        public static DataTable ResgatarTodasOcorrencias()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_todasocorrencias");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgatar todas ocorrencias registradas em sistema ativas
        /// </summary>
        public static DataTable ResgatarOcorrencias()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_ocorrencias");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita a ocorrencia
        /// </summary>
        public static void EditarOcorrencia(oOcorrencia Ocorrencia)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                parameters.Add("p_idocor", Ocorrencia.idocor.ToString());
                parameters.Add("p_descricao", Ocorrencia.descricao);
                parameters.Add("p_classificacao", Ocorrencia.classificacao);
                parameters.Add("p_agendavel", Convert.ToInt32(Ocorrencia.agendavel).ToString());
                parameters.Add("p_agnd_padrao", Ocorrencia.agnd_padrao.ToString());
                parameters.Add("p_agnd_max", Ocorrencia.agnd_max.ToString());
                parameters.Add("p_ativo", Convert.ToInt32(Ocorrencia.ativo).ToString());
                parameters.Add("p_idcart", Ocorrencia.idcart.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_ocorrencia", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
