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
    public class oPagina
    {
        [DataMember]
        public int idpagina { get; set; }
        [DataMember]
        public string descricao { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string icone { get; set; }
        [DataMember]
        public int ordenacao { get; set; }

        public oPagina() { }

        public oPagina(DataRow row)
        {
            idpagina = (int)row["idpagina"];
            descricao = row["descricao"].ToString();
            url = row["url"].ToString();
            icone = row["icone"].ToString();
            ordenacao = (int)row["ordenacao"];
        }
    }
}
