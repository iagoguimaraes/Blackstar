using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Business
{
    public class bNivel
    {
        /// <summary>
        /// Insere novo nível
        /// </summary>
        /// <param name="descricao"></param>
        public static void InserirNivel(oNivel Nivel)
        {
            try
            {
                dNivel.InserirNivel(Nivel);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir nível: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todas os níveis registrados em sistema
        /// </summary>
        /// <returns></returns>
        public static List<oNivel> ResgatarTodosNiveis()
        {
            try
            {
                DataTable dtNiveis = dNivel.ResgatarTodosNiveis();

                List<oNivel> Niveis = new List<oNivel>();

                foreach (DataRow row in dtNiveis.Rows)
                    Niveis.Add(new oNivel(row));

                return Niveis;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de níveis: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todas os níveis registrados em sistema ativos
        /// </summary>
        /// <returns></returns>
        public static List<oNivel> ResgatarNiveis()
        {
            try
            {
                DataTable dtNiveis = dNivel.ResgatarNiveis();

                List<oNivel> Niveis = new List<oNivel>();

                foreach (DataRow row in dtNiveis.Rows)
                    Niveis.Add(new oNivel(row));

                return Niveis;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de níveis: " + ex.Message);
            }
        }

        /// <summary>
        /// Edita o nível
        /// </summary>
        /// <param name="idseg"></param>
        /// <param name="descricao"></param>
        /// <param name="ativo"></param>
        public static void EditarNivel(oNivel Nivel)
        {
            try
            {
                dNivel.EditarNivel(Nivel);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar o nível: " + ex.Message);
            }
        }
    }
}
