using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace Model
{
    public class RequestHelper
    {
        public static string getIP()
        {
            try
            {
                string hostaddress = HttpContext.Current.Request.UserHostAddress;
                string xforwarded = HttpContext.Current.Request.ServerVariables["X_FORWARDED_FOR"];
                return xforwarded == null ? hostaddress : xforwarded;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string getToken()
        {
            try
            {
                return HttpContext.Current.Request.Headers.GetValues("token").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string getMetodo()
        {
            try
            {
                return HttpContext.Current.Request.RawUrl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string getQueryString()
        {
            try
            {
                return string.Join(";", HttpContext.Current.Request.Form);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static double getTempoDecorrido()
        {
            try
            {
                TimeSpan tempo = DateTime.Now - HttpContext.Current.Timestamp;
                return tempo.TotalSeconds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
    }
}
