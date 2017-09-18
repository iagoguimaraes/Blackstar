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
    public class oSegmentacao
    {
        [DataMember]
        public int idseg { get; set; }
        [DataMember]
        public string descricao { get; set; }
        public DateTime dtcad { get; set; }
        public bool ativo { get; set; }

        [DataMember]
        public string fdtcad { get { return dtcad.ToString("dd/MM/yyyy HH:mm:ss"); } }
        [DataMember]
        public string fativo { get { return ativo ? "Ativa" : "Inativa"; } }

        public oSegmentacao()
        {

        }

        public oSegmentacao(DataRow row)
        {
            idseg = (int)row["idseg"];
            descricao = row["descricao"].ToString();
            dtcad = Convert.ToDateTime(row["dtcad"]);
            ativo = Convert.ToBoolean(Convert.ToInt16(row["ativo"]));
        }


    }
}
