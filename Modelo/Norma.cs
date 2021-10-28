using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Norma : EntidadeDominio
    {
        private string _Descricao;

        public string Descricao { get => _Descricao; set => _Descricao = value; }
    }
}
