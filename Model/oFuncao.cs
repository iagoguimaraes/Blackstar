using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oFuncao
    {
        public int idfuncao { get; set; }
        public string descricao { get; set; }
        public string caminho { get; set; }
        public string tipo { get; set; }

        public oFuncao() { }

        public oFuncao(DataRow row)
        {
            idfuncao = (int)row["idfuncao"];
            descricao = row["descricao"].ToString();
            caminho = row["caminho"].ToString();
            tipo = row["tipo"].ToString();
        }
    }
}
