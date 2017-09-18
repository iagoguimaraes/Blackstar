using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oTabulacao
    {

        public int idtab { get; set; }
        public int idusuario { get; set; }
        public int idsessao { get; set; }
        public int idcontrato { get; set; }
        public int idocor { get; set; }
        public DateTime dtcad { get; set; }
        public DateTime dtagend { get; set; }
        public string obs { get; set; }
        public int idtel { get; set; }
        public int idend { get; set; }
        public int idmail { get; set; }

        public string nome { get; set; }
        public string descricao { get; set; }
        public string classificacao { get; set; }
        public string logradouro { get; set; }
        public string email { get; set; }

        public string fdtcad { get { return dtcad.ToString("dd/MM/yyyy HH:mm"); } }
        public string fdtagend { get { return dtagend.ToString("dd/MM/yyyy HH:mm"); } }
        public string ftelefone { get; set; }
        public string cdtagend { get; set; }

        public oTabulacao() { }

        public oTabulacao(DataRow row)
        {
            idtab = Convert.ToInt32(row["idtab"]);
            idusuario = Convert.ToInt32(row["idusuario"]);
            idsessao = Convert.ToInt32(row["idsessao"]);
            idcontrato = Convert.ToInt32(row["idcontrato"]);
            idocor = Convert.ToInt32(row["idocor"]);
            dtcad = Convert.ToDateTime(row["dtcad"]);
            dtagend = Convert.ToDateTime(row["dtagend"]);
            obs = row["obs"].ToString();

            nome = row["nome"].ToString();
            descricao = row["descricao"].ToString();
            classificacao = row["classificacao"].ToString();
            logradouro = row["logradouro"].ToString();
            email = row["email"].ToString();

            int ddd, numero;
            int.TryParse(row["ddd"].ToString(),out ddd);
            int.TryParse(row["numero"].ToString(),out numero);

            if(ddd > 0 && numero > 0)
                ftelefone = string.Concat("(", ddd, ") ", numero.ToString(@"00000\-0000"));
        }

    }
}
