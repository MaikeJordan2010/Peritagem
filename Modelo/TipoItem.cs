using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class TipoItem : EntidadeDominio
    {
        private Boolean _Especifico;

        public bool Especifico { get => _Especifico; set => _Especifico = value; }
    }
}
