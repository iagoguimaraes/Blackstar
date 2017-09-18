using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oOcorrencia
    {

        public int idocor { get; set; }
        public string descricao { get; set; }
        public string classificacao { get; set; }
        public bool agendavel { get; set; }
        public int agnd_padrao { get; set; }
        public int agnd_max { get; set; }
        public bool ativo { get; set; }
        public DateTime dtcad { get; set; }
        public int idcart { get; set; }
        public string carteira { get; set; }


        // campos formatados
        public string fagendavel { get { return agendavel ? "S" : "N"; } }
        public string fdtcad { get { return dtcad.ToString("dd/MM/yyyy HH:mm:ss"); } }
        public string fativo { get { return ativo ? "Ativa" : "Inativa"; } }

        public oOcorrencia()
        {

        }

        public oOcorrencia(DataRow row)
        {
            idocor = (int)row["idocor"];
            descricao = row["descricao"].ToString();
            classificacao = row["classificacao"].ToString();
            agendavel = Convert.ToInt32(row["agendavel"]) == 1 ? true : false;
            agnd_padrao = Convert.ToInt32(row["agnd_padrao"]);
            agnd_max = Convert.ToInt32(row["agnd_max"]);
            ativo = Convert.ToInt32(row["ativo"]) == 1 ? true : false;
            dtcad = Convert.ToDateTime(row["dtcad"]);
            idcart = (int)row["idcart"];
            carteira = row["carteira"].ToString();
        }




    }
}
