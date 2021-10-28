using System;
using System.Collections.Generic;
using System.Text;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class ImagemNegocio
    {
        public bool InserirImagem(Imagem imagem)
        {
            ImagemDAO imgDAO = new ImagemDAO();
            return imgDAO.Inserir(imagem);
        }

        public List<Imagem> ListarImagem(Imagem imagem)
        {
            ImagemDAO imgDAO = new ImagemDAO();
            return imgDAO.ListarImagem(imagem);
        }
    }
}
