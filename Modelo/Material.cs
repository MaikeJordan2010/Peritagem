using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Material : EntidadeDominio
    {
        private string _Descricao;

        public string Descricao { get => _Descricao; set => _Descricao = value; }
    }
}
