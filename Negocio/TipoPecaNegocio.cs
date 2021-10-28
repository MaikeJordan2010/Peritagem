using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocio
{
    public class TipoPecaNegocio
    {

        public List<TipoPeca> ListarTipoPeca()
        {
            TipoPecaDAO tpDAO = new TipoPecaDAO();

            return tpDAO.ListaTipoPeca();
        }


    }
}
