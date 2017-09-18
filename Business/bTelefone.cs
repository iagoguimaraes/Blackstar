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
    public static class bTelefone
    {
        /// <summary>
        /// inserir um telefone na base
        /// </summary>
        /// <param name="telefone"></param>
        /// <returns></returns>
        public static oTelefone InserirTelefone(oTelefone telefone)
        {
            try
            {
                DataTable dtTelefone = dTelefone.InserirTelefone(telefone);
                return new oTelefone(dtTelefone.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir telefone: " + ex.Message);
            }
        }

        /// <summary>
        /// resgatar todos os telefones de determinado cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static List<oTelefone> ResgatarTelefonesCPF(long cpf)
        {
            try
            {
                DataTable dtTelefones = dTelefone.ResgatarTelefonesCPF(cpf);

                List<oTelefone> Telefones = new List<oTelefone>();

                foreach (DataRow row in dtTelefones.Rows)
                    Telefones.Add(new oTelefone(row));

                return Telefones;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar os telefones: " + ex.Message);
            }
        }

        /// <summary>
        /// inativar determinado telefone
        /// </summary>
        /// <param name="idtel"></param>
        public static void Inativar(int idtel)
        {
            try
            {
                dTelefone.Inativar(idtel);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inativar o telefone: " + ex.Message);
            }
        }

        /// <summary>
        /// reativar determinado telefone
        /// </summary>
        /// <param name="idtel"></param>
        public static void Reativar(int idtel)
        {
            try
            {
                dTelefone.Reativar(idtel);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao reativar o telefone: " + ex.Message);
            }
        }

        /// <summary>
        /// marcar determinado telefone como preferencial
        /// </summary>
        /// <param name="idtel"></param>
        public static void TelefonePreferencial(int idtel)
        {
            try
            {
                dTelefone.TelefonePreferencial(idtel);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar o telefone: " + ex.Message);
            }
        }

        /// <summary>
        /// marcar determinado telefone como não preferencial
        /// </summary>
        /// <param name="idtel"></param>
        public static void TelefoneNaoPreferencial(int idtel)
        {
            try
            {
                dTelefone.TelefoneNaoPreferencial(idtel);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar o telefone: " + ex.Message);
            }
        }

        /// <summary>
        /// qualificar telefone
        /// </summary>
        /// <param name="idtel"></param>
        /// <param name="idqualificacao"></param>
        public static void QualificarTelefone(oQualificacao Qualificacao)
        {
            try
            {
                dTelefone.QualificarTelefone(Qualificacao);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao qualificar o telefone: " + ex.Message);
            }
        }

        /// <summary>
        /// resgatar todas possíveis qualificações do sistema
        /// </summary>
        /// <returns></returns>
        public static List<oQualificacao> ResgatarQualificacoes()
        {
            try
            {
                DataTable dtQualificacoes = dTelefone.ResgatarQualificacoes();

                List<oQualificacao> Qualificacoes = new List<oQualificacao>();

                foreach (DataRow row in dtQualificacoes.Rows)
                    Qualificacoes.Add(new oQualificacao(row));

                return Qualificacoes;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar qualificações de telefone: " + ex.Message);
            }
        }
    }
}
