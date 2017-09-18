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
    public class oSessao
    {
        public int idsessao { get; set; }

        [DataMember]
        public DateTime dtini { get; set; }

        [DataMember]
        public DateTime dtexp { get; set; }
        public int idusuario { get; set; }
        public string ip { get; set; }
        public string browser { get; set; }
        public string platform { get; set; }
        public bool ismobile { get; set; }
        public string device { get; set; }

        public List<oFuncao> acesso { get; set; }

        [DataMember]
        public List<oPagina> menu { get; set; }

        [DataMember]
        public oUsuario usuario { get; set; }

        [DataMember]
        public string fdtini { get { return dtini.ToString("dd/MM/yyyy HH:mm:ss"); } }
        [DataMember]
        public string fdtexp { get { return dtexp.ToString("dd/MM/yyyy HH:mm:ss"); } }

        public oSessao()
        {
        }

        public oSessao(DataTable dtSessao, DataTable dtAcesso, DataTable dtMenu, DataTable dtUsuario)
        {
            idsessao = (int)dtSessao.Rows[0]["idsessao"];
            dtini = Convert.ToDateTime(dtSessao.Rows[0]["dtini"]);
            dtexp = Convert.ToDateTime(dtSessao.Rows[0]["dtexp"]);
            idusuario = (int)dtSessao.Rows[0]["idusuario"];
            ip = dtSessao.Rows[0]["ip"].ToString();
            browser = dtSessao.Rows[0]["browser"].ToString();
            platform = dtSessao.Rows[0]["browser"].ToString();
            ismobile = Convert.ToBoolean(Convert.ToInt32(dtSessao.Rows[0]["ismobile"]));
            device = dtSessao.Rows[0]["device"].ToString();

            acesso = new List<oFuncao>();

            foreach (DataRow row in dtAcesso.Rows)
                acesso.Add(new oFuncao(row));

            menu = new List<oPagina>();

            foreach (DataRow row in dtMenu.Rows)
                menu.Add(new oPagina(row));

            usuario = new oUsuario(dtUsuario.Rows[0]);
        }


    }
}
