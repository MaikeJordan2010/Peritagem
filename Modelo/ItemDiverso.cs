using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class ItemDiverso : EntidadeDominio
    {
        private string _Descricao;
        private string _Altura;
        private string _Largura;
        private string _Comprimento;
        private string _Dureza;
        private int _Quantidade;
        private string _Rosca;
        private Norma _Norma;
        private string _LocalAplicado;
        private string _Modelo;
        private string _Classe;
        private string _Passo;
        private bool _RuelaDePressaDin12;
        private string _Codigo;
        private string _Observacao;
        private string _Fabricante;
        private string _Labio;
        private string _Borracha;
        private string _L1;
        private string _L2;
        private string _L3;
        private string _Marca;
        private Disposicao _Disposicao;
        private TipoItem _TipoItem;
        private Material _Material;
        private int _ID_Peritagem;
        private string _Produto;
        private Usuario _UsuarioCriador;
        private DateTime _Dt_Cadastro;
        private string _Dimensao;
        private string _Peso;
        private string _Medidas;
        private string _Capa;

        public int ID_Peritagem { get => _ID_Peritagem; set => _ID_Peritagem = value; }
        public Material Material { get => _Material; set => _Material = value; }
        public TipoItem TipoItem { get => _TipoItem; set => _TipoItem = value; }
        public Disposicao Disposicao { get => _Disposicao; set => _Disposicao = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string L3 { get => _L3; set => _L3 = value; }
        public string L2 { get => _L2; set => _L2 = value; }
        public string L1 { get => _L1; set => _L1 = value; }
        public string Borracha { get => _Borracha; set => _Borracha = value; }
        public string Labio { get => _Labio; set => _Labio = value; }
        public string Fabricante { get => _Fabricante; set => _Fabricante = value; }
        public string Observacao { get => _Observacao; set => _Observacao = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public bool RuelaDePressaDin12 { get => _RuelaDePressaDin12; set => _RuelaDePressaDin12 = value; }
        public string Passo { get => _Passo; set => _Passo = value; }
        public string Classe { get => _Classe; set => _Classe = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string LocalAplicado { get => _LocalAplicado; set => _LocalAplicado = value; }
        public Norma Norma { get => _Norma; set => _Norma = value; }
        public string Rosca { get => _Rosca; set => _Rosca = value; }
        public int Quantidade { get => _Quantidade; set => _Quantidade = value; }
        public string Dureza { get => _Dureza; set => _Dureza = value; }
        public string Comprimento { get => _Comprimento; set => _Comprimento = value; }
        public string Largura { get => _Largura; set => _Largura = value; }
        public string Altura { get => _Altura; set => _Altura = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string Produto { get => _Produto; set => _Produto = value; }
        public Usuario UsuarioCriador { get => _UsuarioCriador; set => _UsuarioCriador = value; }
        public DateTime Dt_Cadastro { get => _Dt_Cadastro; set => _Dt_Cadastro = value; }
        public string Dimensao { get => _Dimensao; set => _Dimensao = value; }
        public string Peso { get => _Peso; set => _Peso = value; }
        public string Medidas { get => _Medidas; set => _Medidas = value; }
        public string Capa { get => _Capa; set => _Capa = value; }
    }
}
