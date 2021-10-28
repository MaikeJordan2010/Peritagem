using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Peca_Dados : EntidadeDominio
    {
        private string _NumDentes;
        private string _AnguloHelice;
        private string _AnguloPressao;
        private string _Modulo;
        private string _Externo;
        private string _LarguraDente;
        private int _ID_Peca;
        private string _Medida_W;

        public string NumDentes { get => _NumDentes; set => _NumDentes = value; }
        public string AnguloHelice { get => _AnguloHelice; set => _AnguloHelice = value; }
        public string AnguloPressao { get => _AnguloPressao; set => _AnguloPressao = value; }
        public string Modulo { get => _Modulo; set => _Modulo = value; }
        public string Externo { get => _Externo; set => _Externo = value; }
        public string LarguraDente { get => _LarguraDente; set => _LarguraDente = value; }
        public int ID_Peca { get => _ID_Peca; set => _ID_Peca = value; }
        public string Medida_W { get => _Medida_W; set => _Medida_W = value; }
    }
}
