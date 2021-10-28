using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocio
{
    public class MaterialNegocio
    {
        public List<Material> ListarMaterial()
        {
            MaterialDAO matDao = new MaterialDAO();
            return matDao.ListarMaterial();
        }

        public Material ConsultarUm(int ID_Material)
        {
            MaterialDAO matDao = new MaterialDAO();
            return matDao.ConsultarUM(ID_Material);
        }

        public bool InserirMaterial(Material mat)
        {
            MaterialDAO matDao = new MaterialDAO();
            return matDao.InserirMaterial(mat);
        }

        public bool AlterarMaterial(Material mat)
        {
            MaterialDAO matDao = new MaterialDAO();
            return matDao.AlterarMaterial(mat);
        }
        public bool ExcluirMaterial(Material mat)
        {
            MaterialDAO matDao = new MaterialDAO();
            return matDao.ExcluirMaterial(mat);
        }
    }
}
