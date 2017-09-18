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
    public static class bEndereco
    {
        /// <summary>
        /// inserir um endereço na base
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public static oEndereco InserirEndereco(oEndereco endereco)
        {
            try
            {
                DataTable dtEndereco = dEndereco.InserirEndereco(endereco);
                return new oEndereco(dtEndereco.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir endereco: " + ex.Message);
            }
        }

        /// <summary>
        /// resgatar todos endereços de determinado cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static List<oEndereco> ResgatarEnderecosCPF(long cpf)
        {
            try
            {
                DataTable dtEnderecos = dEndereco.ResgatarEnderecosCPF(cpf);

                List<oEndereco> Enderecos = new List<oEndereco>();

                foreach (DataRow row in dtEnderecos.Rows)
                    Enderecos.Add(new oEndereco(row));

                return Enderecos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar os enderecos: " + ex.Message);
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
                dEndereco.Inativar(idend);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inativar o endereco: " + ex.Message);
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
                dEndereco.Reativar(idend);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao reativar o endereco: " + ex.Message);
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
                dEndereco.EnderecoPreferencial(idend);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar o endereco: " + ex.Message);
            }
        }

        /// <summary>
        /// marcar determinado endereço como não prefencial
        /// </summary>
        /// <param name="idend"></param>
        public static void EnderecoNaoPreferencial(int idend)
        {
            try
            {
                dEndereco.EnderecoNaoPreferencial(idend);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar o endereco: " + ex.Message);
            }
        }
    }
}
