using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class bEmail
    {
        /// <summary>
        /// inserir um email na base
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static oEmail InserirEmail(oEmail email)
        {
            try
            {
                DataTable dtEmail = dEmail.InserirEmail(email);
                return new oEmail(dtEmail.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir email: " + ex.Message);
            }
        }

        /// <summary>
        /// inativar determinado email
        /// </summary>
        /// <param name="idmail"></param>
        public static void Inativar(int idmail)
        {
            try
            {
                dEmail.Inativar(idmail);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inativar o email: " + ex.Message);
            }
        }

        /// <summary>
        /// reativar determinado email
        /// </summary>
        /// <param name="idmail"></param>
        public static void Reativar(int idmail)
        {
            try
            {
                dEmail.Reativar(idmail);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao reativar o email: " + ex.Message);
            }
        }

        /// <summary>
        /// marcar determinado email como preferencial
        /// </summary>
        /// <param name="idmail"></param>
        public static void EmailPreferencial(int idmail)
        {
            try
            {
                dEmail.EmailPreferencial(idmail);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar o email: " + ex.Message);
            }
        }

        /// <summary>
        /// marcar determinado email como não prefencial
        /// </summary>
        /// <param name="idmail"></param>
        public static void EmailNaoPreferencial(int idmail)
        {
            try
            {
                dEmail.EmailNaoPreferencial(idmail);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar o email: " + ex.Message);
            }
        }
    }
}
