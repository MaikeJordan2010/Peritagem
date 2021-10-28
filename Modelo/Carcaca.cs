using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Modelo
{
    public class Carcaca : EntidadeDominio
    {
        private List<CarcacaMedida> _Medicao;
        private DateTime _Dt_Cadastro;
        private bool _MedicaoAlinhamento;
        private Disposicao _Disposicao;
        private string _Largura;
        private string _Altura;
        private string _Comprimento;
        private string _Peso;
        private string _Descricao;
        private bool _Jateamento;
        private int _ID_Peritagem;
        private Usuario _Usuario_Criador;
        private string _Capa;

        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string Peso { get => _Peso; set => _Peso = value; }
        public string Comprimento { get => _Comprimento; set => _Comprimento = value; }
        public string Altura { get => _Altura; set => _Altura = value; }
        public string Largura { get => _Largura; set => _Largura = value; }
        public Disposicao Disposicao { get => _Disposicao; set => _Disposicao = value; }
        public bool MedicaoAlinhamento { get => _MedicaoAlinhamento; set => _MedicaoAlinhamento = value; }
        public DateTime Dt_Cadastro { get => _Dt_Cadastro; set => _Dt_Cadastro = value; }
        public bool Jateamento { get => _Jateamento; set => _Jateamento = value; }
        public int ID_Peritagem { get => _ID_Peritagem; set => _ID_Peritagem = value; }
        public Usuario Usuario_Criador { get => _Usuario_Criador; set => _Usuario_Criador = value; }
        public List<CarcacaMedida> Medicao { get => _Medicao; set => _Medicao = value; }
        public string Capa { get => _Capa; set => _Capa = value; }
    }
}
