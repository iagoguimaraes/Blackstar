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
    public class oUsuario
    {
        [DataMember]
        public int idusuario { get; set; }
        [DataMember]
        public string login { get; set; }
        public string senha { get; set; }
        public bool ativo { get; set; }
        public DateTime dtcad { get; set; }
        [DataMember]
        public int idnivel { get; set; }
        [DataMember]
        public int idseg { get; set; }
        [DataMember]
        public string nome { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string nivel { get; set; }
        [DataMember]
        public string segmentacao { get; set; }
        [DataMember]
        public string fativo { get { return ativo ? "Ativo" : "Inativo"; } }
        [DataMember]
        public string fdtcad { get { return dtcad.ToString("dd/MM/yyyy HH:mm:ss"); } }

        public oUsuario()
        {

        }

        public oUsuario(DataRow row)
        {
            idusuario = (int)row["idusuario"];
            login = row["login"].ToString();
            senha = row["senha"].ToString();
            ativo = Convert.ToBoolean(Convert.ToInt32(row["ativo"]));
            dtcad = (DateTime)row["dtcad"];
            idnivel = (int)row["idnivel"];
            idseg = (int)row["idseg"];
            nome = row["nome"].ToString();
            email = row["email"].ToString();
            nivel = row["nivel"].ToString();
            segmentacao = row["segmentacao"].ToString();
        }

    }
}
