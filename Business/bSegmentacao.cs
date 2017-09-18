using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class bSegmentacao
    {
        /// <summary>
        /// Insere nova segmentação
        /// </summary>
        /// <param name="descricao"></param>
        public static void InserirSegmentacao(oSegmentacao Segmentacao)
        {
            try
            {
                dSegmentacao.InserirSegmentacao(Segmentacao);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir segmentação: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todas as segmentações registradas em sistema
        /// </summary>
        /// <returns></returns>
        public static List<oSegmentacao> ResgatarTodasSegmentacoes()
        {
            try
            {
                DataTable dtSegmentacoes = dSegmentacao.ResgatarTodasSegmentacoes();

                List<oSegmentacao> Segmentacoes = new List<oSegmentacao>();

                foreach (DataRow row in dtSegmentacoes.Rows)
                    Segmentacoes.Add(new oSegmentacao(row));

                return Segmentacoes;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de segmentações: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todas as segmentações registradas em sistema ativas
        /// </summary>
        /// <returns></returns>
        public static List<oSegmentacao> ResgatarSegmentacoes()
        {
            try
            {
                DataTable dtSegmentacoes = dSegmentacao.ResgatarSegmentacoes();

                List<oSegmentacao> Segmentacoes = new List<oSegmentacao>();

                foreach (DataRow row in dtSegmentacoes.Rows)
                    Segmentacoes.Add(new oSegmentacao(row));

                return Segmentacoes;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de segmentações: " + ex.Message);
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
                dSegmentacao.EditarSegmentacao(Segmentacao);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar a segmentação: " + ex.Message);
            }
        }
    }
}
