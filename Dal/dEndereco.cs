using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class dEndereco
    {
        /// <summary>
        /// inserir endereço no bd
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public static DataTable InserirEndereco(oEndereco endereco)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idcontrato", endereco.idcontrato.ToString());
                parameters.Add("p_logradouro", endereco.logradouro);
                parameters.Add("p_numero", endereco.numero.ToString());
                parameters.Add("p_bairro", endereco.bairro);
                parameters.Add("p_cidade", endereco.cidade);
                parameters.Add("p_uf", endereco.uf);
                parameters.Add("p_cep", endereco.cep.ToString());


                return MySQLHelper.ExecuteDataTable("proc_insr_endereco", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgatar endereços de determinado cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static DataTable ResgatarEnderecosCPF(long cpf)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_cpf", cpf.ToString());

                return MySQLHelper.ExecuteDataTable("proc_sel_endereco_bycpf", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// inativar determinado endereço
        /// </summary>
        /// <param name="idend"></param>
        public static void Inativar(int idend)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idend", idend.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_inativar_endereco", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// reativar determinado endereço
        /// </summary>
        /// <param name="idend"></param>
        public static void Reativar(int idend)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idend", idend.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_reativar_endereco", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// marcar determinado endereço como preferencial
        /// </summary>
        /// <param name="idend"></param>
        public static void EnderecoPreferencial(int idend)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idend", idend.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_endpreferencial", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// marcar determinado endereço como não preferencial
        /// </summary>
        /// <param name="idend"></param>
        public static void EnderecoNaoPreferencial(int idend)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idend", idend.ToString());

                MySQLHelper.ExecuteDataTable("proc_upd_endnaopreferencial", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
