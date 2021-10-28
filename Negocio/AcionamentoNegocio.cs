using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocio
{
    public class AcionamentoNegocio
    {


        public bool InserirAcionamento(Acionamento aci)
        {
            AcionamentoDAO objDAO = new AcionamentoDAO();
            return objDAO.InserirAcionamento(aci);
        }

        public bool ExcluirAcionamento(Acionamento aci)
        {
            AcionamentoDAO objDAO = new AcionamentoDAO();
            return objDAO.ExcluirAcionamento(aci);
        }

        public bool ValidarExistencia(int ID_Peritagem)
        {
            AcionamentoDAO objDAO = new AcionamentoDAO();
            return objDAO.ValidarExistencia(ID_Peritagem);
        }


        public Acionamento ConsultarAcionamento(Peritagem per)
        {
            AcionamentoDAO objDAO = new AcionamentoDAO();
            return objDAO.ConsultarAcionamento(per);
        }

        public bool AlterarAcionamento(Acionamento aci)
        {
            AcionamentoDAO objDAO = new AcionamentoDAO();
            return objDAO.AlterarAcionamento(aci);
        }

        public bool AlterarCapa(int ID_Acionamento, string Capa)
        {
            AcionamentoDAO objDAO = new AcionamentoDAO();
            return objDAO.AlterarCapa(ID_Acionamento, Capa);
        }
    }
}
