using Modelo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class CroquiNegocio
    {
        public bool InserirCroqui(Croqui croqui)
        {
            CroquiDAO cDao = new CroquiDAO();

            return cDao.Inserir(croqui);
        }

        public List<Croqui> ListarCroqui(Croqui croqui)
        {
            CroquiDAO cDao = new CroquiDAO();

            return cDao.ListarCroqui(croqui);
        }
    }
}
