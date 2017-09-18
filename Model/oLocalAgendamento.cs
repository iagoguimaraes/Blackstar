using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oLocalAgendamento
    {

        
        public int idlocal { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public int idcart { get; set; }

        public oLocalAgendamento() { }

        public oLocalAgendamento(DataRow row)
        {
            idlocal = Convert.ToInt32(row["idlocal"]);
            nome = row["nome"].ToString();
            descricao = row["descricao"].ToString();
            idcart = Convert.ToInt32(row["idcart"]);
        }

    }
}
