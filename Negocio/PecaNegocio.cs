using System;
using System.Collections.Generic;
using System.Text;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class PecaNegocio
    {

        public bool Inserir(Peca peca)
        {
            PecaDAO pecDAO = new PecaDAO();

            return pecDAO.Inserir(peca);

        }

        public bool ExcluirPeca(Peca peca)
        {
            PecaDAO pecDAO = new PecaDAO();

            return pecDAO.ExcluirPeca(peca);

        }

        

        public List<Peca> Listar(Peritagem per)
        {
            PecaDAO pecaDAO = new PecaDAO();

            return pecaDAO.ConsultaTodos(per);

        }



        public Peca ConsultaUM(Peca peca)
        {
            PecaDAO pecaDAO = new PecaDAO();

            return pecaDAO.ConsultaUM(peca);
        }

        public int ConsultaUltima(Peca peca)
        {
            PecaDAO pecaDAO = new PecaDAO();

            return pecaDAO.ConsultaUltima(peca);
        }



        public bool AlterarCapa(int ID_Peca, string Capa)
        {
            PecaDAO itemDAO = new PecaDAO();
            return itemDAO.AlterarCapa(ID_Peca, Capa);
        }


        public bool AlterarPeca(Peca peca)
        {
            PecaDAO pecDao = new PecaDAO();
            return pecDao.Alterar(peca);
        }



        public bool InserirValoresW(Peca_W w)
        {
            PecaDAO pecDAO = new PecaDAO();

            return pecDAO.InserirValorW(w);

        }

        public bool AlterarValoresW(Peca_W w)
        {
            PecaDAO pecDAO = new PecaDAO();

            return pecDAO.AlterarValorW(w);

        }
        public bool ExcluirValoresW(Peca_W w)
        {
            PecaDAO pecDAO = new PecaDAO();

            return pecDAO.ExcluirValorW(w);

        }


        public List<Peca_W> ListarValorW(int ID_Peca)
        {
            PecaDAO pecaDAO = new PecaDAO();

            return pecaDAO.ConsultaValorW(ID_Peca);
        }





        public bool InserirPecaDados(Peca_Dados pd)
        {
            PecaDAO pecDAO = new PecaDAO();

            return pecDAO.InserirPecaDados(pd);

        }

        public bool AlterarPecaDados(Peca_Dados pd)
        {
            PecaDAO pecDAO = new PecaDAO();

            return pecDAO.AlterarPecaDados(pd);

        }


        public bool ExcluirPecaDados(Peca_Dados pd)
        {
            PecaDAO pecDAO = new PecaDAO();

            return pecDAO.ExcluirPecaDados(pd);

        }


        public List<Peca_Dados> ListarPecaDados(int ID_Peca)
        {
            PecaDAO pecaDAO = new PecaDAO();

            return pecaDAO.ConsultaPecaDados(ID_Peca);
        }

    }
}
