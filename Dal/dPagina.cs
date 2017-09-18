using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class dPagina
    {
        /// <summary>
        /// Resgata listagem de todas as páginas cadastradas no BD
        /// </summary>
        public static DataTable ResgatarTodasPaginas()
        {
            try
            {
                return MySQLHelper.ExecuteDataTable("proc_sel_todaspaginas");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
