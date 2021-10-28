using Modelo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;


namespace Negocio
{
    public class DocumentoNegocio
    {

        public bool InserirDocumento(Documento doc)
        {
            DocumentoDAO docDao = new DocumentoDAO();

            return docDao.InserirDocumento(doc);
        }

        public List<Documento> ListarDocumento(int ID_Peritagem, int ID_Peca)
        {
            DocumentoDAO docDao = new DocumentoDAO();
            return docDao.ConsultarDocumento(ID_Peritagem, ID_Peca);
        }

        public bool ExcluirDocumento(Documento doc)
        {
            DocumentoDAO docDao = new DocumentoDAO();

            return docDao.ExcluirDocumento(doc);
        }
    }
}
