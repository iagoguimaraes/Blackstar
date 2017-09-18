using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oEndereco
    {

        public int idend { get; set; }
        public int idcontrato { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public int cep { get; set; }
        public bool ativo { get; set; }
        public bool preferencial { get; set; }
        public DateTime dtcad { get; set; }

        public string fdtcad { get { return dtcad.ToString("dd/MM/yyyy HH:mm"); } }
        public string fativo { get { return ativo ? "Ativo" : "Inativo"; } }
        public string fpreferencial { get { return preferencial ? "Sim" : "Não"; } }
        public string fcep { get { return cep.ToString(@"00000\-000"); } }

        public oEndereco()
        {

        }

        public oEndereco(DataRow row)
        {
            idend = Convert.ToInt32(row["idend"]);
            idcontrato = Convert.ToInt32(row["idcontrato"]);
            logradouro = row["logradouro"].ToString();
            numero = Convert.ToInt32(row["numero"]);
            bairro = row["bairro"].ToString();
            cidade = row["cidade"].ToString();
            uf = row["uf"].ToString();
            cep = Convert.ToInt32(row["cep"]);
            ativo = Convert.ToInt32(row["ativo"]) == 1 ? true : false;
            preferencial = Convert.ToInt32(row["preferencial"]) == 1 ? true : false;
            dtcad = Convert.ToDateTime(row["dtcad"]);
        }


    }
}
