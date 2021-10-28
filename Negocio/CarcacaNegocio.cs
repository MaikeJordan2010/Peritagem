using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocio
{
    public class CarcacaNegocio
    {
        public bool InserirCarcaca(Carcaca car)
        {
            CarcacaDAO carDAO = new CarcacaDAO();

            return carDAO.InserirCarcaca(car);
        }

        public bool ExcluirCarcaca(Carcaca car)
        {
            CarcacaDAO carDAO = new CarcacaDAO();

            return carDAO.ExcluirCarcaca(car);
        }

        public Carcaca ConsultarUltima(Carcaca car)
        {
            CarcacaDAO carDAO = new CarcacaDAO();

            return carDAO.ConsultaUltima(car);
        }

        public Carcaca ConsultarUm(Carcaca car)
        {
            CarcacaDAO carDAO = new CarcacaDAO();

            return carDAO.ConsultaUm(car);
        }

        public bool InserirCarcacaMedida(CarcacaMedida carMed)
        {
            CarcacaDAO carDAO = new CarcacaDAO();

            return carDAO.InserirCarcacaMedida(carMed);
        }

        public List<Carcaca> ConsultarTodos(Peritagem per)
        {
            CarcacaDAO carDAO = new CarcacaDAO();

            return carDAO.ConsultarTodos(per);
        }

        public bool AlterarCarcaca(Carcaca car)
        {
            CarcacaDAO carDAO = new CarcacaDAO();

            return carDAO.AlterarCarcaca(car);
        }

        public bool AlterarCarcacaMedida(CarcacaMedida carMed)
        {
            CarcacaDAO carDAO = new CarcacaDAO();

            return carDAO.AlterarCarcacaMedida(carMed);
        }

        public bool ExcluirCarcacaMedida(CarcacaMedida carMed)
        {
            CarcacaDAO carDAO = new CarcacaDAO();

            return carDAO.ExcluirCarcacaMedida(carMed);
        }

        public bool AlterarCapa(int ID_Carcaca, string Capa)
        {
            CarcacaDAO carDAO = new CarcacaDAO();
            return carDAO.AlterarCapa(ID_Carcaca, Capa);
        }

        public List<CarcacaMedida> ListarCarcacaMedida(Carcaca car)
        {
            CarcacaDAO carDAO = new CarcacaDAO();
            return carDAO.ConsultaCarcacaMedida(car);
        }
    }
}
