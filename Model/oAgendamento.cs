using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oAgendamento
    {

         public int idagendamento { get; set; }
        public int idusuario { get; set; }
        public int idsessao { get; set; }
        public int idcontrato { get; set; }
        public int idtipoagendamento { get; set; }
        public int idlocal { get; set; }
        public DateTime dtcad { get; set; }
        public DateTime dtini { get; set; }
        public DateTime dtfim { get; set; }
        public string obs { get; set; }
        public bool ativo { get; set; }

        public string descricao { get; set; }
        public string local { get; set; }
        public string descricaolocal { get; set; }
        public string usuario { get; set; }
        public string cliente { get; set; }

        public string fdtcad { get { return dtcad.ToString("dd/MM/yyyy HH:mm"); } }
        public string fdtini { get { return dtini.ToString("dd/MM/yyyy HH:mm"); } }
        public string fdtfim { get { return dtfim.ToString("dd/MM/yyyy HH:mm"); } }

        public string fjsdtcad { get { return dtcad.ToString("yyyy/MM/dd HH:mm"); } }
        public string fjsdtini { get { return dtini.ToString("yyyy/MM/dd HH:mm"); } }
        public string fjsdtfim { get { return dtfim.ToString("yyyy/MM/dd HH:mm"); } }

        public oAgendamento() { }

        public oAgendamento(DataRow row)
        {
            idagendamento = Convert.ToInt32(row["idagendamento"]);
            idusuario = Convert.ToInt32(row["idusuario"]);
            idsessao = Convert.ToInt32(row["idsessao"]);
            idcontrato = Convert.ToInt32(row["idcontrato"]);
            idlocal = Convert.ToInt32(row["idlocal"]);
            idtipoagendamento = Convert.ToInt32(row["idtipoagendamento"]);
            dtcad = Convert.ToDateTime(row["dtcad"]);
            dtini = Convert.ToDateTime(row["dtini"]);
            dtfim = Convert.ToDateTime(row["dtfim"]);
            obs = row["obs"].ToString();
            ativo = Convert.ToBoolean(Convert.ToInt16(row["ativo"]));

            descricao = row["descricao"].ToString();
            local = row["local"].ToString();
            descricaolocal = row["descricaolocal"].ToString();
            usuario = row["usuario"].ToString();
            cliente = row["cliente"].ToString();
        }

    }
}
