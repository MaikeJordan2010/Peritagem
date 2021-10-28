using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo
{
    public class Redutor : EntidadeDominio
    {
        private string _Descricao;
        private int _ID_Peritagem;
        private Disposicao _Disposicao;
        private DateTime _DT_Cadastro;
        private string _TipoDados;
        private string _Fabricante;
        private string _Modelo;
        private string _RotacaoIN;
        private string _RotacaoOUT;
        private string _Reducao;
        private string _Potencia;
        private string _FatorServico;
        private string _AnoFabricacao;
        private string _Lubrificacao;
        private string _Viscosidade;
        private string _Volume;
        private string _Sentido;
        private string _Visto;
        private string _Aplicacao;
        private string _MotivoManutencao;
        private string _Peso;
        private string _Cor;
        private bool _PinturaPadraoSantana;
        private string _Outro;
        private string _Desenho;
        private string _PosicaoMontagem;
        private List<Imagem> _Album;
        private string _Capa;



        public DateTime DT_Cadastro { get => _DT_Cadastro; set => _DT_Cadastro = value; }
        public Disposicao Disposicao { get => _Disposicao; set => _Disposicao = value; }
        public int ID_Peritagem { get => _ID_Peritagem; set => _ID_Peritagem = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string PosicaoMontagem { get => _PosicaoMontagem; set => _PosicaoMontagem = value; }
        public string Desenho { get => _Desenho; set => _Desenho = value; }
        public string Outro { get => _Outro; set => _Outro = value; }
        public bool PinturaPadraoSantana { get => _PinturaPadraoSantana; set => _PinturaPadraoSantana = value; }
        public string Cor { get => _Cor; set => _Cor = value; }
        public string Peso { get => _Peso; set => _Peso = value; }
        public string MotivoManutencao { get => _MotivoManutencao; set => _MotivoManutencao = value; }
        public string Aplicacao { get => _Aplicacao; set => _Aplicacao = value; }
        public string Sentido { get => _Sentido; set => _Sentido = value; }
        public string Visto { get => _Visto; set => _Visto = value; }
        public string Volume { get => _Volume; set => _Volume = value; }
        public string Viscosidade { get => _Viscosidade; set => _Viscosidade = value; }
        public string Lubrificacao { get => _Lubrificacao; set => _Lubrificacao = value; }
        public string AnoFabricacao { get => _AnoFabricacao; set => _AnoFabricacao = value; }
        public string FatorServico { get => _FatorServico; set => _FatorServico = value; }
        public string Potencia { get => _Potencia; set => _Potencia = value; }
        public string Reducao { get => _Reducao; set => _Reducao = value; }
        public string RotacaoOUT { get => _RotacaoOUT; set => _RotacaoOUT = value; }
        public string RotacaoIN { get => _RotacaoIN; set => _RotacaoIN = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string Fabricante { get => _Fabricante; set => _Fabricante = value; }
        public string TipoDados { get => _TipoDados; set => _TipoDados = value; }
        public List<Imagem> Album { get => _Album; set => _Album = value; }
        public string Capa { get => _Capa; set => _Capa = value; }
    }
}
