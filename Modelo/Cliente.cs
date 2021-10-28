using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente : EntidadeDominio
    {
        private string _Icone;

        public string Icone { get => _Icone; set => _Icone = value; }
    }
}
