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
    public static class bPagina
    {
        /// <summary>
        /// resgata todas as páginas registradas no banco
        /// </summary>
        /// <returns></returns>
        public static List<oPagina> ResgatarTodasPaginas()
        {
            try
            {
                DataTable dtPagina = dPagina.ResgatarTodasPaginas();

                List<oPagina> Paginas = new List<oPagina>();

                foreach (DataRow row in dtPagina.Rows)
                    Paginas.Add(new oPagina(row));

                return Paginas;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
