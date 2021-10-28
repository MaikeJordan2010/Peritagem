using System;
using System.Collections.Generic;

namespace Modelo
{
    public class Peritagem : EntidadeDominio
    {
        private DateTime _Dt_Chegada;
        private DateTime _Dt_Cadastro;
        private DateTime _Dt_Previsao;
        private DateTime _Dt_Inicio;
        private DateTime _Dt_Revisao;
        private DateTime _Dt_Finalizacao;
        private Cliente _Cliente;
        private int _Nfe;
        private int _ID_Orcamento;
        private OrdemServico _OrdemServico;
        private Usuario _UsuarioCriador;
        private Redutor _Redutor;
        private string _Descricao;
        private string _Capa;
        private string _Miniatura;
        private string _Protocolo;
        private int _NumeroContrato;
        private string _Referencia;
        private string _MotivoManutencao;
        private string _Aplicacao;
        private string _Observacao;
        private string _CaminhoDocumento;
        private List<Documento> _ListDoc;
        private List<Carcaca> _ListCarcaca;
        private Acionamento _Acionamento;
        private List<ItemDiverso> _ListItemDiverso;
        private List<Peca> _ListPeca;
        private Situacao _Situacao;

        public string Miniatura { get => _Miniatura; set => _Miniatura = value; }
        public string Capa { get => _Capa; set => _Capa = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public Redutor Redutor { get => _Redutor; set => _Redutor = value; }
        public Usuario UsuarioCriador { get => _UsuarioCriador; set => _UsuarioCriador = value; }
        public OrdemServico OrdemServico { get => _OrdemServico; set => _OrdemServico = value; }
        public int ID_Orcamento { get => _ID_Orcamento; set => _ID_Orcamento = value; }
        public int Nfe { get => _Nfe; set => _Nfe = value; }
        public Cliente Cliente { get => _Cliente; set => _Cliente = value; }
        public DateTime Dt_Finalizacao { get => _Dt_Finalizacao; set => _Dt_Finalizacao = value; }
        public DateTime Dt_Revisao { get => _Dt_Revisao; set => _Dt_Revisao = value; }
        public DateTime Dt_Inicio { get => _Dt_Inicio; set => _Dt_Inicio = value; }
        public DateTime Dt_Previsao { get => _Dt_Previsao; set => _Dt_Previsao = value; }
        public DateTime Dt_Cadastro { get => _Dt_Cadastro; set => _Dt_Cadastro = value; }
        public DateTime Dt_Chegada { get => _Dt_Chegada; set => _Dt_Chegada = value; }
        public string Protocolo { get => _Protocolo; set => _Protocolo = value; }
        public int NumeroContrato { get => _NumeroContrato; set => _NumeroContrato = value; }
        public string Referencia { get => _Referencia; set => _Referencia = value; }
        public string MotivoManutencao { get => _MotivoManutencao; set => _MotivoManutencao = value; }
        public string Aplicacao { get => _Aplicacao; set => _Aplicacao = value; }
        public string Observacao { get => _Observacao; set => _Observacao = value; }
        public string CaminhoDocumento { get => _CaminhoDocumento; set => _CaminhoDocumento = value; }
        public List<Documento> ListDoc { get => _ListDoc; set => _ListDoc = value; }
        public List<Carcaca> ListCarcaca { get => _ListCarcaca; set => _ListCarcaca = value; }
        public Acionamento Acionamento { get => _Acionamento; set => _Acionamento = value; }
        public List<ItemDiverso> ListItemDiverso { get => _ListItemDiverso; set => _ListItemDiverso = value; }
        public List<Peca> ListPeca { get => _ListPeca; set => _ListPeca = value; }
        public Situacao Situacao { get => _Situacao; set => _Situacao = value; }
    }

}
