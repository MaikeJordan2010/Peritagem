using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo
{
    public class EntidadeDominio
    {
        private int _Id;
        private bool _Ativo;
        private string _Nome;

        public string Nome { get => _Nome; set => _Nome = value; }
        public bool Ativo { get => _Ativo; set => _Ativo = value; }
        public int Id { get => _Id; set => _Id = value; }
    }
}
