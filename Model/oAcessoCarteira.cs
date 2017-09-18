using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oAcessoCarteira
    {
        public int idcart { get; set; }
        public int idseg { get; set; }

        public oAcessoCarteira() { }

        public oAcessoCarteira(DataRow row)
        {
            idcart = Convert.ToInt32(row["idcart"]);
            idseg = Convert.ToInt32(row["idseg"]);
        }
    }
}
