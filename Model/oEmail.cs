using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oEmail
    {

        public int idmail { get; set; }
        public int idcontrato { get; set; }
        public string email { get; set; }
        public bool ativo { get; set; }
        public bool preferencial { get; set; }
        public DateTime dtcad { get; set; }

        public string fdtcad { get { return dtcad.ToString("dd/MM/yyyy HH:mm"); } }
        public string fativo { get { return ativo ? "Ativo" : "Inativo"; } }
        public string fpreferencial { get { return preferencial ? "Sim" : "Não"; } }

        public oEmail()
        {

        }

        public oEmail(DataRow row)
        {
            idmail = Convert.ToInt32(row["idmail"]);
            idcontrato = Convert.ToInt32(row["idcontrato"]);
            email = row["email"].ToString();
            ativo = Convert.ToInt32(row["ativo"]) == 1 ? true : false;
            preferencial = Convert.ToInt32(row["preferencial"]) == 1 ? true : false;
            dtcad = Convert.ToDateTime(row["dtcad"]);
        }


    }
}
