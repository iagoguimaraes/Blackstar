using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class dFuncao
    {
        /// <summary>
        /// Resgata listagem de todas as funcões cadastradas no BD
        /// </summary>
        public static DataTable ResgatarTodasFuncoes()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_todasfuncoes");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
