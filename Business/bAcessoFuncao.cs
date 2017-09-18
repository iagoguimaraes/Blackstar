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
    public static class bAcessoFuncao
    {
        /// <summary>
        /// Insere acesso a determinada função para algum nível de usuário
        /// </summary>
        public static void InserirAcessoFuncao(oAcessoFuncao AcessoFuncao)
        {
            try
            {
                // verificar se a funcao existe
                if (!bFuncao.ResgatarTodasFuncoes().Exists(fun => fun.idfuncao == AcessoFuncao.idfuncao))
                    throw new Exception("A função não existe ou foi removida.");

                // verificar se o nível existe
                if (!bNivel.ResgatarTodosNiveis().Exists(niv => niv.idnivel == AcessoFuncao.idnivel))
                    throw new Exception("A nível não existe ou foi removido.");

                dAcessoFuncao.InserirAcessoFuncao(AcessoFuncao);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir acesso a esta função: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todos os acessos de funções registrados em sistema
        /// </summary>
        public static List<oAcessoFuncao> ResgatarTodosAcessoFuncoes()
        {
            try
            {
                DataTable dtAcessos = dAcessoFuncao.ResgatarTodosAcessoFuncoes();

                List<oAcessoFuncao> Acessos = new List<oAcessoFuncao>();

                foreach (DataRow row in dtAcessos.Rows)
                    Acessos.Add(new oAcessoFuncao(row));

                return Acessos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de acessos de funções: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todos os acessos de funções registrados em sistema de determinado nível
        /// </summary>
        public static List<oAcessoFuncao> ResgatarAcessoFuncoes(int idnivel)
        {
            try
            {
                DataTable dtAcessos = dAcessoFuncao.ResgatarAcessoFuncoes(idnivel);

                List<oAcessoFuncao> Acessos = new List<oAcessoFuncao>();

                foreach (DataRow row in dtAcessos.Rows)
                    Acessos.Add(new oAcessoFuncao(row));

                return Acessos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de acessos de funções: " + ex.Message);
            }
        }

        /// <summary>
        /// Remove o acesso de determinada função para algum nível de usuário
        /// </summary>
        public static void RemoverAcessoFuncao(oAcessoFuncao AcessoFuncao)
        {
            try
            {
                dAcessoFuncao.RemoverAcessoFuncao(AcessoFuncao);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover o acesso da função: " + ex.Message);
            }
        }
    }
}
