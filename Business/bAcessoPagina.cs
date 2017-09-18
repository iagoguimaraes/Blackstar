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
    public static class bAcessoPagina
    {
        /// <summary>
        /// Insere acesso a determinada página para algum nível de usuário
        /// </summary>
        public static void InserirAcessoPagina(oAcessoPagina AcessoPagina)
        {
            try
            {
                // verificar se a pagina existe
                if (!bPagina.ResgatarTodasPaginas().Exists(pag => pag.idpagina == AcessoPagina.idpagina))
                    throw new Exception("A página não existe ou foi removida.");

                // verificar se o nível existe
                if (!bNivel.ResgatarTodosNiveis().Exists(niv => niv.idnivel == AcessoPagina.idnivel))
                    throw new Exception("A nível não existe ou foi removido.");

                dAcessoPagina.InserirAcessoPagina(AcessoPagina);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir acesso a esta página: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todos os acessos de páginas registrados em sistema
        /// </summary>
        public static List<oAcessoPagina> ResgatarTodosAcessoPaginas()
        {
            try
            {
                DataTable dtAcessos = dAcessoPagina.ResgatarTodosAcessoPaginas();

                List<oAcessoPagina> Acessos = new List<oAcessoPagina>();

                foreach (DataRow row in dtAcessos.Rows)
                    Acessos.Add(new oAcessoPagina(row));

                return Acessos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de acessos de páginas: " + ex.Message);
            }
        }

        /// <summary>
        /// Resgata todos os acessos de páginas registrados em sistema de determinado nível
        /// </summary>
        public static List<oAcessoPagina> ResgatarAcessoPaginas(int idnivel)
        {
            try
            {
                DataTable dtAcessos = dAcessoPagina.ResgatarAcessoPaginas(idnivel);

                List<oAcessoPagina> Acessos = new List<oAcessoPagina>();

                foreach (DataRow row in dtAcessos.Rows)
                    Acessos.Add(new oAcessoPagina(row));

                return Acessos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao resgatar listagem de acessos de páginas: " + ex.Message);
            }
        }

        /// <summary>
        /// Remove o acesso de determinada página para algum nível de usuário
        /// </summary>
        public static void RemoverAcessoPagina(oAcessoPagina AcessoPagina)
        {
            try
            {
                dAcessoPagina.RemoverAcessoPagina(AcessoPagina);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover o acesso da página: " + ex.Message);
            }
        }
    }
}
