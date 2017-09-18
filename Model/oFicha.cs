using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class oFicha
    {
        public oContrato contrato { get; set; }
        public List<oQualificacao> qualificacoes { get; set; }
        public List<oTelefone> telefones { get; set; }
        public List<oEndereco> enderecos { get; set; }
        public List<oEmail> emails { get; set; }
        public List<oTabulacao> tabulacoes { get; set; }
        public List<oOcorrencia> ocorrencias { get; set; }
        public List<oAgendamento> agendamentos { get; set; }
        public List<oTipoAgendamento> tiposagendamento { get; set; }
        public List<oLocalAgendamento> locaisagendamento { get; set; }

        public oFicha()
        {

        }

        public oFicha(DataSet dsFicha)
        {
            contrato = new oContrato(dsFicha.Tables[0].Rows[0]);
            telefones = new List<oTelefone>();
            enderecos = new List<oEndereco>();
            qualificacoes = new List<oQualificacao>();
            emails = new List<oEmail>();
            tabulacoes = new List<oTabulacao>();
            ocorrencias = new List<oOcorrencia>();
            agendamentos = new List<oAgendamento>();
            tiposagendamento = new List<oTipoAgendamento>();
            locaisagendamento = new List<oLocalAgendamento>();

            foreach (DataRow row in dsFicha.Tables[1].Rows)
                qualificacoes.Add(new oQualificacao(row));
            foreach (DataRow row in dsFicha.Tables[2].Rows)
                telefones.Add(new oTelefone(row));
            foreach (DataRow row in dsFicha.Tables[3].Rows)
                enderecos.Add(new oEndereco(row));
            foreach (DataRow row in dsFicha.Tables[4].Rows)
                emails.Add(new oEmail(row));
            foreach (DataRow row in dsFicha.Tables[5].Rows)
                tabulacoes.Add(new oTabulacao(row));
            foreach (DataRow row in dsFicha.Tables[6].Rows)
                ocorrencias.Add(new oOcorrencia(row));
            foreach (DataRow row in dsFicha.Tables[7].Rows)
                agendamentos.Add(new oAgendamento(row));
            foreach (DataRow row in dsFicha.Tables[8].Rows)
                tiposagendamento.Add(new oTipoAgendamento(row));
            foreach (DataRow row in dsFicha.Tables[9].Rows)
                locaisagendamento.Add(new oLocalAgendamento(row));
        }


    }
}
