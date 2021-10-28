using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo
{
    public class Peca: EntidadeDominio
    {
        private int _ID_Peritagem;
        private string _Descricao;
        private List<Imagem> _Album;
        private Disposicao _Disposicao;
        private string _Dureza;
        private string _TratamentoTermico;
        private string _Peso;
        private List<Peca_W> _ListValorW;
        private string _Especial;
        private string _DescricaoRetrabalho;
        private string _Desenho;
        private string _Produto;
        private string _ValorK;
        private string _MetodoFabricacao;
        private DateTime _Dt_Cadastro;
        private TipoPeca _TipoPeca;
        private Material _Material;
        private string _Furo;
        private string _Altura;
        private string _Largura;
        private bool _Helicoidal;
        private string _Sentido;
        private string _Capa;
        private List<Croqui> _Croqui;
        private List<Peca_Dados> _DadosPeca;
        private List<Documento> _ListDocumentos;

        public List<Imagem> Album { get => _Album; set => _Album = value; }
        public string MetodoFabricacao { get => _MetodoFabricacao; set => _MetodoFabricacao = value; }
        public string ValorK { get => _ValorK; set => _ValorK = value; }
        public string Produto { get => _Produto; set => _Produto = value; }
        public string Desenho { get => _Desenho; set => _Desenho = value; }
        public string DescricaoRetrabalho { get => _DescricaoRetrabalho; set => _DescricaoRetrabalho = value; }
        public string Especial { get => _Especial; set => _Especial = value; }
        public string Peso { get => _Peso; set => _Peso = value; }
        public string TratamentoTermico { get => _TratamentoTermico; set => _TratamentoTermico = value; }
        public string Dureza { get => _Dureza; set => _Dureza = value; }
        public Disposicao Disposicao { get => _Disposicao; set => _Disposicao = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public DateTime Dt_Cadastro { get => _Dt_Cadastro; set => _Dt_Cadastro = value; }
        public TipoPeca TipoPeca { get => _TipoPeca; set => _TipoPeca = value; }
        public Material Material { get => _Material; set => _Material = value; }
        public int ID_Peritagem { get => _ID_Peritagem; set => _ID_Peritagem = value; }
        public string Furo { get => _Furo; set => _Furo = value; }
        public bool Helicoidal { get => _Helicoidal; set => _Helicoidal = value; }
        public string Capa { get => _Capa; set => _Capa = value; }
        public List<Peca_W> ListValorW { get => _ListValorW; set => _ListValorW = value; }
        public List<Croqui> Croqui { get => _Croqui; set => _Croqui = value; }
        public string Altura { get => _Altura; set => _Altura = value; }
        public string Largura { get => _Largura; set => _Largura = value; }
        public List<Peca_Dados> DadosPeca { get => _DadosPeca; set => _DadosPeca = value; }
        public string Sentido { get => _Sentido; set => _Sentido = value; }
        public List<Documento> ListDocumentos { get => _ListDocumentos; set => _ListDocumentos = value; }
    }
}
