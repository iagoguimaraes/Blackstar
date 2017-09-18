using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oQualificacao
    {

        public int idqualificacao { get; set; }
        public string descricao { get; set; }
        public int idtel { get; set; }

        public oQualificacao() { }

        public oQualificacao(DataRow row)
        {
            idqualificacao = Convert.ToInt32(row["idqualificacao"]);
            descricao = row["descricao"].ToString();
            if (row.Table.Columns.Contains("idtel"))
                idtel = Convert.ToInt32(row["idtel"]);
        }



    }
}
