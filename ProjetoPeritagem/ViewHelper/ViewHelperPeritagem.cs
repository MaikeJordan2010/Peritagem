using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo;

namespace ProjetoPeritagem.ViewHelper
{
    public class ViewHelperPeritagem
    {
        public List<Modelo.Peritagem> listPeritagem;
        public int quantidade;
        public int page;
        public int pages;
        public Modelo.Peritagem peritagem;
        public Redutor Redutor;
        public List<Disposicao> listDisposicao;
        public List<Redutor> listRedutor;
        public List<Carcaca> listCarcaca;
        public List<Cliente> listCliente;
        public List<Peca> listPeca;
        public int ID_Carcaca;
        public int ID_Peritagem;
        public int ID_Peca;
        public int ID_Redutor;
        public int ID_Acionamento;
        public int ID_ItemDiverso;
        public List<TipoItem> listTipoItem;
        public List<ItemDiverso> listItemDiverso;
        public List<Material> listMaterial;
        public List<Norma> listNorma;
        public List<Imagem> listImagem;
        public List<TipoPeca> listTipoPeca;
        public Acionamento acionamento;
        public Carcaca carcaca;
        public Peca peca;
        public Usuario usuario;
        public ItemDiverso item;
        public List<Croqui> listCroqui;
        public Norma norma;
        public Material material;
        public List<Configuracao> listConfiguracao;
        public Configuracao configuracao;
        public List<Situacao> listSituacao;
        public Situacao situacao;
    }
}
