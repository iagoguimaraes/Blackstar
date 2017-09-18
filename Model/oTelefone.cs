using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oTelefone
    {
        public int idtel { get; set; }
        public int ddd { get; set; }
        public int numero { get; set; }
        public string tipo { get; set; }
        public bool ativo { get; set; }
        public bool preferencial { get; set; }
        public DateTime dtcad { get; set; }
        public int idqualificacao { get; set; }
        public int idcontrato { get; set; }

        public string fdtcad { get { return dtcad.ToString("dd/MM/yyyy HH:mm"); } }
        public string fativo { get { return ativo ? "Ativo" : "Inativo"; } }
        public string fpreferencial { get { return preferencial ? "Sim" : "Não"; } }
        public string ftelefone { get { return string.Concat("(",ddd,") ",numero.ToString(@"00000\-0000")); } }

        public oTelefone()
        {

        }

        public oTelefone(DataRow row)
        {
            idtel = Convert.ToInt32(row["idtel"]);
            ddd = Convert.ToInt32(row["ddd"]);
            numero = Convert.ToInt32(row["numero"]);
            tipo = row["tipo"].ToString();
            ativo = Convert.ToInt32(row["ativo"]) == 1 ? true : false;
            preferencial = Convert.ToInt32(row["preferencial"]) == 1 ? true : false;
            dtcad = Convert.ToDateTime(row["dtcad"]);
            idqualificacao = Convert.ToInt32(row["idqualificacao"]);
            idcontrato = Convert.ToInt32(row["idcontrato"]);
        }



    }
}
