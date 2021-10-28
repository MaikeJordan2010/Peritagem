using Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;
using Modelo;

namespace Negocio
{
    public class DisposicaoNegocio
    {

        public List<Disposicao> ListaDisposicao()
        {
            DisposicaoDAO disDao = new DisposicaoDAO();
            return disDao.ListaDisposicao();
        }
    }
}
