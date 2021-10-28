using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Modelo
{
    public class Acionamento : EntidadeDominio
    {
        private string _TipoAcionamento;
        private string _Fabricante;
        private string _Modelo;
        private string _RotacaoPolos;
        private string _Potencia;
        private Disposicao _Disposicao;
        private string _Carcaca;
        private string _Descricao;
        private bool _Teste;
        private string _TipoTeste;
        private string _DescricaoTeste;
        private string _InspecaoVisual;
        private int _ID_Peritagem;
        private string _Capa;

        public string InspecaoVisual { get => _InspecaoVisual; set => _InspecaoVisual = value; }
        public string DescricaoTeste { get => _DescricaoTeste; set => _DescricaoTeste = value; }
        public string TipoTeste { get => _TipoTeste; set => _TipoTeste = value; }
        public bool Teste { get => _Teste; set => _Teste = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string Carcaca { get => _Carcaca; set => _Carcaca = value; }
        public Disposicao Disposicao { get => _Disposicao; set => _Disposicao = value; }
        public string Potencia { get => _Potencia; set => _Potencia = value; }
        public string RotacaoPolos { get => _RotacaoPolos; set => _RotacaoPolos = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string Fabricante { get => _Fabricante; set => _Fabricante = value; }
        public string TipoAcionamento { get => _TipoAcionamento; set => _TipoAcionamento = value; }
        public int ID_Peritagem { get => _ID_Peritagem; set => _ID_Peritagem = value; }
        public string Capa { get => _Capa; set => _Capa = value; }
    }
}
