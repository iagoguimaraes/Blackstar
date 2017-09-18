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
    public class bOcorrencia
    {

        /// <summary>
        /// Insere nova ocorrencia
        /// </summary>
        public static void InserirOcorrencia(oOcorrencia Ocorrencia)
        {
            try
            {
                // verifica se a nome não é nulo ou vazio
                if (String.IsNullOrEmpty(Ocorrencia.descricao))
                    throw new Exception("A ocorrência não pode ser vazia");

                // Verifica se a carteira existe
                if (!bCarteira.ResgatarCarteiras().Exists(ocor => ocor.idcart == Ocorrencia.idcart))
                    throw new Exception("O carteira informada não existe ou foi inativada.");

                dOcorrencia.InserirOcorrencia(Ocorrencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir ocorrencia: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todas ocorrencias registradas em sistema
        /// </summary>
        public static List<oOcorrencia> ResgatarTodasOcorrencias()
        {
            try
            {
                DataTable dtOcorrencias = dOcorrencia.ResgatarTodasOcorrencias();

                List<oOcorrencia> Ocorrencias = new List<oOcorrencia>();

                foreach (DataRow row in dtOcorrencias.Rows)
                    Ocorrencias.Add(new oOcorrencia(row));

                return Ocorrencias;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de ocorrencias: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todas ocorrencias registradas em sistema ativas
        /// </summary>
        public static List<oOcorrencia> ResgatarOcorrencias()
        {
            try
            {
                DataTable dtOcorrencias = dOcorrencia.ResgatarOcorrencias();

                List<oOcorrencia> Ocorrencias = new List<oOcorrencia>();

                foreach (DataRow row in dtOcorrencias.Rows)
                    Ocorrencias.Add(new oOcorrencia(row));

                return Ocorrencias;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de ocorrencias: " + ex.Message);
            }
        }

        /// <summary>
        /// Edita a ocorrencia
        /// </summary>
        public static void EditarOcorrencia(oOcorrencia Ocorrencia)
        {
            try
            {
                dOcorrencia.EditarOcorrencia(Ocorrencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar a ocorrencia: " + ex.Message);
            }
        }

        /// <summary>
        /// resgata determinada ocorrencia pelo ID
        /// </summary>
        /// <param name="idocor"></param>
        /// <returns></returns>
        public static oOcorrencia ResgatarOcorrenciaPorID(int idocor)
        {
                try
                {
                    return ResgatarTodasOcorrencias().Where(ocor => ocor.idocor == idocor).First();
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("Erro ao resgatar ocorrência: " +  ex.Message);
                }
        }

    }
}
