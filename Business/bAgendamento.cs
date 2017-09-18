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
    public static class bAgendamento
    {
        /// <summary>
        /// inserir uma agendamento na base
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        public static oAgendamento InserirAgendamento(oAgendamento agendamento)
        {
            try
            {
                // validação se a data fim > do que a data ini
                if (agendamento.dtfim < agendamento.dtini)
                    throw new Exception("A data final deve ser posterior a data início");

                // validação se já tem algum agendamento nesta mesma data
                if (ExisteAgendamento(agendamento.dtini, agendamento.dtfim, agendamento.idcontrato))
                    throw new Exception("Já existe um agendamento para este mesmo horário");

                DataTable dtAgendamento = dAgendamento.InserirAgendamento(agendamento, bSessao.ResgatarSessao());
                return new oAgendamento(dtAgendamento.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir agendamento: " + ex.Message);
            }
        }

        /// <summary>
        /// modifica informações de um agendamento
        /// </summary>
        /// <param name="agendamento"></param>
        public static void EditarAgendamento(oAgendamento agendamento)
        {
            try
            {
                dAgendamento.EditarAgendamento(agendamento);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar agendamento: " + ex.Message);
            }
        }

        /// <summary>
        /// verificar se há agendamentos neste período para a carteira deste contrato
        /// </summary>
        /// <param name="dtini"></param>
        /// <param name="dtfim"></param>
        public static bool ExisteAgendamento(DateTime dtini, DateTime dtfim, int idcontrato)
        {
            try
            {
                DataTable dtagend = dAgendamento.ExisteAgendamento(dtini, dtfim, idcontrato);

                if (dtagend.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// resgata os agendamentos de determinada carteira
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        public static List<oAgendamento> ResgatarAgendamentos(int idcart)
        {
            try
            {
                DataTable dtAgendamentos = dAgendamento.ResgatarAgendamentos(idcart);

                List<oAgendamento> Agendamentos = new List<oAgendamento>();

                foreach (DataRow row in dtAgendamentos.Rows)
                    Agendamentos.Add(new oAgendamento(row));

                return Agendamentos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar agendamentos: " + ex.Message);
            }
        }

        /// <summary>
        /// resgata os locais de agendamentos de determinada carteira
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        public static List<oLocalAgendamento> ResgatarLocaisAgendamento(int idcart)
        {
            try
            {
                DataTable dtLocaisAgendamento = dAgendamento.ResgatarLocaisAgendamento(idcart);

                List<oLocalAgendamento> LocaisAgendamento = new List<oLocalAgendamento>();

                foreach (DataRow row in dtLocaisAgendamento.Rows)
                    LocaisAgendamento.Add(new oLocalAgendamento(row));

                return LocaisAgendamento;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar locais de agendamentos: " + ex.Message);
            }
        }

        /// <summary>
        /// resgata os tipos agendamentos de determinada carteira
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        public static List<oTipoAgendamento> ResgatarTiposAgendamento(int idcart)
        {
            try
            {
                DataTable dtTipoAgendamento = dAgendamento.ResgatarTiposAgendamento(idcart);

                List<oTipoAgendamento> TiposAgendamento = new List<oTipoAgendamento>();

                foreach (DataRow row in dtTipoAgendamento.Rows)
                    TiposAgendamento.Add(new oTipoAgendamento(row));

                return TiposAgendamento;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar tipos de agendamentos: " + ex.Message);
            }
        }

    }
}
