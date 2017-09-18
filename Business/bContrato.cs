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
    public static class bContrato
    {
        /// <summary>
        /// Realiza busca dos contratos cadastrados em sistema, seja por CPF, número ou Nome.
        /// </summary>
        /// <param name="Acionamento"></param>
        /// <returns></returns>
        public static List<oContrato> Buscar(oAcionamento Acionamento)
        {
            try
            {
                if (Acionamento == null)
                    throw new Exception("Consulta inválida.");

                DataTable dtContratos;
                oSessao sessao = bSessao.ResgatarSessao();

                if (Acionamento.tipo == "CPF")
                {
                    long cpf;

                    if (!long.TryParse(Acionamento.busca, out cpf))
                        throw new Exception("CPF deve conter apenas números");

                    dtContratos = dContrato.BuscarContratosPorCPF(cpf, sessao);
                }
                else if (Acionamento.tipo == "Contrato" || Acionamento.tipo == "Número")
                    dtContratos = dContrato.BuscarContratosPorNumero(Acionamento.busca, sessao);
                else if (Acionamento.tipo == "Nome"){

                    if (Acionamento.busca.Trim().Length < 4)
                        throw new Exception("Para não sobrecarregar o servidor, a consulta por nome deve ter no mínimo 4 caracteres");

                    dtContratos = dContrato.BuscarContratosPorNome(Acionamento.busca, sessao);
                }
                else
                    throw new Exception("Não é possível buscar contratos por " + Acionamento.tipo);

                List<oContrato> Contratos = new List<oContrato>();

                foreach (DataRow row in dtContratos.Rows)
                    Contratos.Add(new oContrato(row));

                return Contratos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar contratos: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata ficha de determinado cliente pelo idcontrato
        /// </summary>
        public static oFicha ResgatarFicha(int idcontrato)
        {
            try
            {
                oSessao sessao = bSessao.ResgatarSessao();

                DataSet dtFicha = dContrato.ResgatarFicha(idcontrato, sessao);

                if (dtFicha.Tables[0].Rows.Count == 0)
                    throw new Exception("Contrato não encontrado");

                oFicha Ficha = new oFicha(dtFicha);
                return Ficha;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar ficha: " + ex.Message);
            }
        }

        /// <summary>
        /// Inserir um novo contrato
        /// </summary>
        /// <param name="contrato"></param>
        /// <returns></returns>
        public static int InserirContrato(oContrato contrato)
        {
            try
            {
                DataTable dtContrato = dContrato.InserirContrato(contrato);

                return Convert.ToInt32(dtContrato.Rows[0]["idcontrato"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir contrato: " + ex.Message);
            }
        }



    }
}
