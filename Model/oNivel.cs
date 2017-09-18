using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class oNivel
    {
        [DataMember]
        public int idnivel { get; set; }
        [DataMember]
        public string descricao { get; set; }
        public DateTime dtcad { get; set; }
        public bool ativo { get; set; }

        [DataMember]
        public string fdtcad { get { return dtcad.ToString("dd/MM/yyyy HH:mm:ss"); } }
        [DataMember]
        public string fativo { get { return ativo ? "Ativo" : "Inativo"; } }

        public oNivel()
        {

        }

        public oNivel(DataRow row)
        {
            idnivel = (int)row["idnivel"];
            descricao = row["descricao"].ToString();
            dtcad = Convert.ToDateTime(row["dtcad"]);
            ativo = Convert.ToBoolean(Convert.ToInt16(row["ativo"]));
        }
    }
}
