using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Situacao :EntidadeDominio
    {
        private string _Descricao;

        public string Descricao { get => _Descricao; set => _Descricao = value; }
    }
}
