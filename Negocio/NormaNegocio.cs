using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocio
{
    public class NormaNegocio
    {
        public List<Norma> ListarNorma()
        {
            NormaDAO matDao = new NormaDAO();
            return matDao.ListarNorma();
        }

        public Norma ConsultarUm(int ID_Norma)
        {
            NormaDAO matDao = new NormaDAO();
            return matDao.ConsultarUm(ID_Norma);
        }

        public bool InserirNorma(Norma nor)
        {
            NormaDAO matDao = new NormaDAO();
            return matDao.InserirNorma(nor);
        }

        public bool AlterarNorma(Norma nor)
        {
            NormaDAO matDao = new NormaDAO();
            return matDao.AlterarNorma(nor);
        }
        public bool ExcluirNorma(Norma nor)
        {
            NormaDAO matDao = new NormaDAO();
            return matDao.ExcluirNorma(nor);
        }


    }
}
