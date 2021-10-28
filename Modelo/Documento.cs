using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Documento : EntidadeDominio
    {
        private String _Caminho;
        private int _ID_Peritagem;
        private int _ID_Peca;

        public string Caminho { get => _Caminho; set => _Caminho = value; }
        public int ID_Peritagem { get => _ID_Peritagem; set => _ID_Peritagem = value; }
        public int ID_Peca { get => _ID_Peca; set => _ID_Peca = value; }
    }
}
