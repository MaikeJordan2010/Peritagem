using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo
{
    public class Imagem
    {
        private int _ID_Carcaca;
        private int _ID_Acionamento;
        private int _ID_Peca;
        private int _ID_Peritagem;
        private int _ID_Img;
        private int _ID_Redutor;
        private int _ID_ItemDiverso;
        private string _Path_Img;
        private string _Path_Miniatura;
        private string _Img;
        private string _Descricao;
        private int _Width;
        private int _Height;
        private string _Qualidade;
        private Usuario _Usuario_Criador;
        private DateTime _DT_Cadastro;
        private string _Latitude;
        private string _Longitude;

        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string Img { get => _Img; set => _Img = value; }
        public string Path_Miniatura { get => _Path_Miniatura; set => _Path_Miniatura = value; }
        public string Path_Img { get => _Path_Img; set => _Path_Img = value; }
        public int ID_Redutor { get => _ID_Redutor; set => _ID_Redutor = value; }
        public int ID_Img { get => _ID_Img; set => _ID_Img = value; }
        public int ID_Peritagem { get => _ID_Peritagem; set => _ID_Peritagem = value; }
        public int ID_Peca { get => _ID_Peca; set => _ID_Peca = value; }
        public int Width { get => _Width; set => _Width = value; }
        public int Height { get => _Height; set => _Height = value; }
        public string Qualidade { get => _Qualidade; set => _Qualidade = value; }
        public int ID_Acionamento { get => _ID_Acionamento; set => _ID_Acionamento = value; }
        public int ID_Carcaca { get => _ID_Carcaca; set => _ID_Carcaca = value; }
        public int ID_ItemDiverso { get => _ID_ItemDiverso; set => _ID_ItemDiverso = value; }
        public Usuario Usuario_Criador { get => _Usuario_Criador; set => _Usuario_Criador = value; }
        public DateTime DT_Cadastro { get => _DT_Cadastro; set => _DT_Cadastro = value; }
        public string Latitude { get => _Latitude; set => _Latitude = value; }
        public string Longitude { get => _Longitude; set => _Longitude = value; }
    }
}
