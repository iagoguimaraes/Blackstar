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
    public static class bCarteira
    {


        /// <summary>
        /// Insere nova carteira
        /// </summary>
        public static void InserirCarteira(oCarteira Carteira)
        {
            try
            {
                dCarteira.InserirCarteira(Carteira);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir carteira: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todas as carteiras registradas em sistema
        /// </summary>
        public static List<oCarteira> ResgatarTodasCarteiras()
        {
            try
            {
                DataTable dtCarteiras = dCarteira.ResgatarTodasCarteiras();

                List<oCarteira> Carteiras = new List<oCarteira>();

                foreach (DataRow row in dtCarteiras.Rows)
                    Carteiras.Add(new oCarteira(row));

                return Carteiras;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de carteiras: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todas as carteiras registradas em sistema ativas
        /// </summary>
        public static List<oCarteira> ResgatarCarteiras()
        {
            try
            {
                DataTable dtCarteiras = dCarteira.ResgatarCarteiras();

                List<oCarteira> Carteiras = new List<oCarteira>();

                foreach (DataRow row in dtCarteiras.Rows)
                    Carteiras.Add(new oCarteira(row));

                return Carteiras;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de carteiras: " + ex.Message);
            }
        }

        /// <summary>
        /// Edita a carteira
        /// </summary>
        public static void EditarCarteira(oCarteira Carteira)
        {
            try
            {
                dCarteira.EditarCarteira(Carteira);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar o carteira: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgatar as carteiras que o usuário que fez a resiquisição tem acesso
        /// </summary>
        /// <returns></returns>
        public static List<oCarteira> ResgatarMinhasCarteiras(oUsuario Usuario)
        {
            try
            {
                DataTable dtCarteiras = dCarteira.ResgatarMinhasCarteiras(Usuario.idseg);

                List<oCarteira> Carteiras = new List<oCarteira>();

                foreach (DataRow row in dtCarteiras.Rows)
                    Carteiras.Add(new oCarteira(row));

                return Carteiras;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de carteiras: " + ex.Message);
            }
        }
    }
}
