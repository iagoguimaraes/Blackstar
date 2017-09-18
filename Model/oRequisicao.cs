using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oRequisicao
    {
        public int idsessao { get; set; }
        public string path { get; set; }
        public string querystring { get; set; }
        public double tempo { get; set; }
        public DateTime dtreq { get; set; }

        public oRequisicao()
        {
            string token = RequestHelper.getToken();
            idsessao = Convert.ToInt32(EncryptHelper.Decrypt(token));
            path = RequestHelper.getMetodo();
            querystring = RequestHelper.getQueryString();
            tempo = RequestHelper.getTempoDecorrido();
            dtreq = DateTime.Now;
        }


    }
}
