using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oAcessoPagina
    {
        public int idpagina { get; set; }
        public int idnivel { get; set; }

        public oAcessoPagina() { }

        public oAcessoPagina(DataRow row)
        {
            idpagina = Convert.ToInt32(row["idpagina"]);
            idnivel = Convert.ToInt32(row["idnivel"]);
        }
    }
}
