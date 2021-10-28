using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Peca_W : EntidadeDominio
    {
        private int _W;
        private string _ValorW;
        private int _ID_Peca;

        public int W { get => _W; set => _W = value; }
        public string ValorW { get => _ValorW; set => _ValorW = value; }
        public int ID_Peca { get => _ID_Peca; set => _ID_Peca = value; }
    }
}
