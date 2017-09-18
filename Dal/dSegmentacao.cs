using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class dSegmentacao
    {
        /// <summary>
        /// Insere segmentação
        /// </summary>
        /// <param name="descricao"></param>
        public static void InserirSegmentacao(oSegmentacao Segmentacao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_descricao", Segmentacao.descricao);

                MySQLHelper.ExecuteDataTable("proc_ins_segmentacao", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgatar todas as segmentações registradas em sistema
        /// </summary>
        /// <returns></returns>
        public static DataTable ResgatarTodasSegmentacoes()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_todassegmentacoes");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgatar todas as segmentações registradas em sistema ativas
        /// </summary>
        /// <returns></returns>
        public static DataTable ResgatarSegmentacoes()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_segmentacoes");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita a segmentação
        /// </summary>
        /// <param name="idseg"></param>
        /// <param name="descricao"></param>
        /// <param name="ativo"></param>
        public static void EditarSegmentacao(oSegmentacao Segmentacao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idseg", Segmentacao.idseg.ToString());
                parameters.Add("p_descricao", Segmentacao.descricao);
                parameters.Add("p_ativo", Convert.ToInt32(Segmentacao.ativo).ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_segmentacao", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
