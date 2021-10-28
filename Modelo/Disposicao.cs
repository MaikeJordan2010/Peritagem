using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Disposicao
    {
        private string _Nome;
        private int _ID_Disposicao;

        public int ID_Disposicao { get => _ID_Disposicao; set => _ID_Disposicao = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
    }
       
}
