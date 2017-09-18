using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oContrato
    {

        public int idcontrato { get; set; }
        public long cpf { get; set; }
        public string numero { get; set; }
        public int sq { get; set; }
        public int idcart { get; set; }
        public string nome { get; set; }
        public DateTime dtnasc { get; set; }
        public string sexo { get; set; }
        public string tipopessoa { get; set; }
        public DateTime dtcad { get; set; }
        public DateTime dtdev { get; set; }
        public string obs { get; set; }
        public bool ativo { get; set; }
        public bool preferencial { get; set; }

        public string carteira { get; set; }


        public string fcpf
        {
            get
            {
                if (tipopessoa == "PF")
                    return cpf.ToString(@"000\.000\.000\-00");
                else if (tipopessoa == "PJ")
                    return cpf.ToString(@"00\.000\.000\/0000\-00");
                else
                    return cpf.ToString();
            }
        }

        public string fdtnasc { get { return dtnasc.ToString("dd/MM/yyyy"); } }
        public string fdtcad { get { return dtcad.ToString("dd/MM/yyyy HH:mm"); } }
        public string fdtdev { get { return dtdev.ToString("dd/MM/yyyy HH:mm"); } }
        public string fativo { get { return ativo ? "Ativo" : "Inativo"; } }
        public string fpreferencial { get { return preferencial ? "Sim" : "Não"; } }

        public oContrato()
        {

        }
        public oContrato(DataRow row)
        {
            idcontrato = (int)row["idcontrato"];
            cpf = Convert.ToInt64(row["cpf"]);
            numero = row["numero"].ToString();
            sq = Convert.ToInt32(row["sq"]);
            idcart = (int)row["idcart"];
            nome = row["nome"].ToString();
            dtnasc = Convert.ToDateTime(row["dtnasc"]);
            sexo = row["sexo"].ToString();
            tipopessoa = row["tipopessoa"].ToString();
            dtcad = Convert.ToDateTime(row["dtcad"]);

            DateTime _dtdev;
            DateTime.TryParse(row["dtdev"].ToString(), out _dtdev);
            dtdev = _dtdev;

            obs = row["obs"].ToString();
            ativo = Convert.ToInt32(row["ativo"]) == 1 ? true : false;
            preferencial = Convert.ToInt32(row["preferencial"]) == 1 ? true : false;

            carteira = row["carteira"].ToString();
        }



    }
}
