using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oTipoAgendamento
    {

        public int idtipoagendamento { get; set; }
        public string descricao { get; set; }
        public int idcart { get; set; }

        public oTipoAgendamento() { }

        public oTipoAgendamento(DataRow row)
        {
            idtipoagendamento = Convert.ToInt32(row["idtipoagendamento"]);
            descricao = row["descricao"].ToString();
            idcart = Convert.ToInt32(row["idcart"]);
        }

    }
}
