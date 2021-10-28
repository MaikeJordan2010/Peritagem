using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocio
{
    public  class RedutorNegocio
    {

        public bool inserirRedutor(Redutor redutor )
        {
            RedutorDAO redDAO = new RedutorDAO();
            return redDAO.Inserir(redutor);
        }

        public bool AlterarRedutor(Redutor redutor)
        {
            RedutorDAO redDAO = new RedutorDAO();
            return redDAO.Alterar(redutor);
        }

        public bool ExcluirRedutor(Redutor redutor)
        {
            RedutorDAO redDAO = new RedutorDAO();
            return redDAO.ExcluirRedutor(redutor);
        }

        public bool ValidarExistencia(int ID_Peritagem)
        {
            RedutorDAO redDAO = new RedutorDAO();
            return redDAO.ValidarExistencia(ID_Peritagem);
        }

        public List<Redutor> ConsultaTodos(Peritagem per)
        {
            RedutorDAO redDAO = new RedutorDAO();

            return redDAO.ConsultaTodos(per);

        }
        public Redutor ConsultaUm(Redutor red)
        {
            Redutor per = new Redutor();
            RedutorDAO redDAO = new RedutorDAO();
            per = redDAO.ConsultaUm(red);

            return per;
        }

        public bool AlterarCapa(int ID_Redutor, string Capa)
        {
            RedutorDAO redDAO = new RedutorDAO();
            return redDAO.AlterarCapa(ID_Redutor, Capa);
        }

    }
}
