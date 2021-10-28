using Modelo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class TipoItemNegocio
    {
        public List<TipoItem> ListaTipoItem()
        {
            TipoItemDAO tipoItemDAO = new TipoItemDAO();
            return tipoItemDAO.ListaTipoItem();
        }
    }
}
