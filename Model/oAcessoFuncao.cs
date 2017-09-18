using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oAcessoFuncao
    {
        public int idfuncao { get; set; }
        public int idnivel { get; set; }

        public oAcessoFuncao() { }

        public oAcessoFuncao(DataRow row)
        {
            idfuncao = Convert.ToInt32(row["idfuncao"]);
            idnivel = Convert.ToInt32(row["idnivel"]);
        }
    }
}
