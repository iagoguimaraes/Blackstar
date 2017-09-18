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
    public static class bTabulacao
    {
        /// <summary>
        /// inserir uma tabulação na base
        /// </summary>
        /// <param name="tabulacao"></param>
        /// <returns></returns>
        public static oTabulacao InserirTabulacao(oTabulacao tabulacao)
        {
            try
            {
                // resgata ocorrencia
                oOcorrencia ocorrencia = bOcorrencia.ResgatarOcorrenciaPorID(tabulacao.idocor);

                // verifica se a ocorrência é agendável e valida, caso contrário inputa o agendamento padrão
                if (ocorrencia.agendavel)
                {
                    // se o agendamento for menor que agora, seta para agora
                    if (tabulacao.dtagend < DateTime.Now)
                        tabulacao.dtagend = DateTime.Now;
                    // se o agendamento for maior do que o máximo possível, seta pro máximo possível
                    if (tabulacao.dtagend > DateTime.Now.AddMinutes(ocorrencia.agnd_max))
                        tabulacao.dtagend = DateTime.Now.AddMinutes(ocorrencia.agnd_max);
                }
                else
                    tabulacao.dtagend = DateTime.Now.AddMinutes(ocorrencia.agnd_padrao);
                
                DataTable dtTabulacao = dTabulacao.InserirTabulacao(tabulacao, bSessao.ResgatarSessao());
                return new oTabulacao(dtTabulacao.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir tabulação: " + ex.Message);
            }
        }
    }
}
