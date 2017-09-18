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
    public static class bFuncao
    {
        /// <summary>
        /// resgata todas as funções registradas no banco
        /// </summary>
        /// <returns></returns>
        public static List<oFuncao> ResgatarTodasFuncoes()
        {
            try
            {
                DataTable dtFuncao = dFuncao.ResgatarTodasFuncoes();

                List<oFuncao> Funcoes = new List<oFuncao>();

                foreach (DataRow row in dtFuncao.Rows)
                    Funcoes.Add(new oFuncao(row));

                return Funcoes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
