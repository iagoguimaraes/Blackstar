using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class dContrato
    {

        /// <summary>
        /// Busca listagem de contratos pelo CPF
        /// </summary>
        public static DataTable BuscarContratosPorCPF(long cpf, oSessao sessao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_cpf", cpf.ToString());
                parameters.Add("p_idusuario", sessao.idusuario.ToString());

                return MySQLHelper.ExecuteDataTable("proc_sel_contratos_bycpf", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca listagem de contratos por nome
        /// </summary>
        public static DataTable BuscarContratosPorNome(string nome, oSessao sessao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_nome", nome);
                parameters.Add("p_idusuario", sessao.idusuario.ToString());

                return MySQLHelper.ExecuteDataTable("proc_sel_contratos_bynome", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca listagem de contratos por numero
        /// </summary>
        public static DataTable BuscarContratosPorNumero(string numero, oSessao sessao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_numero", numero);
                parameters.Add("p_idusuario", sessao.idusuario.ToString());

                return MySQLHelper.ExecuteDataTable("proc_sel_contratos_bynumero", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Consulta a ficha de determinado cliente pelo idcontrato
        /// </summary>
        /// <param name="idcontrato"></param>
        /// <returns></returns>
        public static DataSet ResgatarFicha(int idcontrato, oSessao sessao)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_idcontrato", idcontrato.ToString());
                parameters.Add("p_idusuario", sessao.idusuario.ToString());

                return MySQLHelper.ExecuteDataSet("proc_sel_ficha", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// inserir um novo contrato
        /// </summary>
        /// <param name="contrato"></param>
        public static DataTable InserirContrato(oContrato contrato)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("p_cpf", contrato.cpf.ToString());
                parameters.Add("p_numero", contrato.numero);
                parameters.Add("p_idcart", contrato.idcart.ToString());
                parameters.Add("p_nome", contrato.nome);
                parameters.Add("p_dtnasc", contrato.dtnasc.ToString("yyyy-MM-dd"));
                parameters.Add("p_sexo", contrato.sexo);
                parameters.Add("p_tipopessoa", contrato.tipopessoa);
                parameters.Add("p_obs", contrato.obs);

                return MySQLHelper.ExecuteDataTable("proc_insr_contrato", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
