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
    public static class bAcessoCarteira
    {
        /// <summary>
        /// Insere acesso a determinada carteira para alguma segmentação de usuário
        /// </summary>
        public static void InserirAcessoCarteira(oAcessoCarteira AcessoCarteira)
        {
            try
            {
                // verificar se a carteira existe
                if (!bCarteira.ResgatarTodasCarteiras().Exists(cart => cart.idcart == AcessoCarteira.idcart))
                    throw new Exception("A carteira não existe ou foi removida.");

                // verificar se a segmentação existe
                if (!bSegmentacao.ResgatarTodasSegmentacoes().Exists(seg => seg.idseg == AcessoCarteira.idseg))
                    throw new Exception("A nível não existe ou foi removido.");

                dAcessoCarteira.InserirAcessoCarteira(AcessoCarteira);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir acesso a esta carteira: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todos os acessos de carteiras registrados em sistema
        /// </summary>
        public static List<oAcessoCarteira> ResgatarTodosAcessoCarteira()
        {
            try
            {
                DataTable dtAcessos = dAcessoCarteira.ResgatarTodosAcessoCarteira();

                List<oAcessoCarteira> Acessos = new List<oAcessoCarteira>();

                foreach (DataRow row in dtAcessos.Rows)
                    Acessos.Add(new oAcessoCarteira(row));

                return Acessos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de acessos de carteiras: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todos os acessos de carteiras registrados em sistema de determinada segmentação
        /// </summary>
        public static List<oAcessoCarteira> ResgatarAcessoCarteira(int idseg)
        {
            try
            {
                DataTable dtAcessos = dAcessoCarteira.ResgatarAcessoCarteira(idseg);

                List<oAcessoCarteira> Acessos = new List<oAcessoCarteira>();

                foreach (DataRow row in dtAcessos.Rows)
                    Acessos.Add(new oAcessoCarteira(row));

                return Acessos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de acesso de carteiras: " + ex.Message);
            }
        }

        /// <summary>
        /// Remove o acesso de determinada página para algum nível de usuário
        /// </summary>
        public static void RemoverAcessoCarteira(oAcessoCarteira AcessoCarteira)
        {
            try
            {
                dAcessoCarteira.RemoverAcessoCarteira(AcessoCarteira);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover o acesso da carteira: " + ex.Message);
            }
        }
    }
}
