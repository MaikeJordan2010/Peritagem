using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;
using Modelo;

namespace Negocio
{
    public class SituacaoNegocio
    {

        public List<Situacao> ListarSituacao()
        {
            SituacaoDAO sitDao = new SituacaoDAO();
            return sitDao.ListarSituacao();
        }
    }
}
