using System;
using System.Collections.Generic;
using System.Text;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class PeritagemNegocio
    {

        public Boolean InserirPeritagem(Peritagem peritagem)
        {
            PeritagemDAO perDAO = new PeritagemDAO();
            return perDAO.InserirPeritagem(peritagem);
           
        }

        public Boolean ExcluirPeritagem(Peritagem peritagem)
        {
            PeritagemDAO perDAO = new PeritagemDAO();
            return perDAO.ExcluirPeritagem(peritagem);

        }

        public Boolean AlterarSituacao(Peritagem peritagem)
        {
            PeritagemDAO perDAO = new PeritagemDAO();
            return perDAO.AlterarSituacao(peritagem);

        }

        public Boolean AlterarPeritagem(Peritagem peritagem)
        {
            PeritagemDAO perDAO = new PeritagemDAO();
            return perDAO.AlterarPeritagem(peritagem);

        }

        public List<Peritagem> ConsultarTodos(int page, int qtde, int NEF, int ID_Cliente, int ID_Situacao, string NomeEquipamento)
        {
            List<Peritagem> listaPer = new List<Peritagem>();
            PeritagemDAO perDAO = new PeritagemDAO();

            return perDAO.TodasPeritagens(page, qtde, NEF, ID_Cliente, ID_Situacao, NomeEquipamento);
        }


        public Peritagem ConsultaUM(int ID_Peritagem)
        {
            PeritagemDAO perDAO = new PeritagemDAO();

            return perDAO.ConsultarUM(ID_Peritagem);
        }

        public bool AlterarCapa(int ID_Peritagem, string Capa)
        {
            PeritagemDAO perDAO = new PeritagemDAO();

            return perDAO.AlterarCapa(ID_Peritagem, Capa);
        }

        public int QuantidadePeritagem()
        {
            PeritagemDAO perDAO = new PeritagemDAO();
           return  perDAO.QuantidadePeritagem();
        }

        public bool ConsultarNota(Peritagem per)
        {
            PeritagemDAO perDAO = new PeritagemDAO();
            return perDAO.ConsultarNota(per);
        }

        public int ConsultarUltima(Peritagem per)
        {
            PeritagemDAO perDAO = new PeritagemDAO();
            return perDAO.ConsultarUltima(per);
        }


    }
}
