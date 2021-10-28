using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Modelo.Util;
using Negocio;
using ProjetoPeritagem.ViewHelper;

namespace ProjetoPeritagem.Controllers
{
    
    [ApiController]
    public class ItemDiversoAPIController : ControllerBase
    {

        [Route("api/ItemDiversoAPI/ListarItem")]
        [HttpPost]
        public List<ItemDiverso> ListarItem([FromForm] int ID_Peritagem)
        {
            ItemDiversoNegocio itemNeg = new ItemDiversoNegocio();
            ItemDiverso item = new ItemDiverso();
            item.ID_Peritagem = ID_Peritagem;
            List<ItemDiverso> listItemDiverso = new List<ItemDiverso>();
            listItemDiverso = itemNeg.ConsultarTodos(item);

            return listItemDiverso;
        }



        [Route("api/ItemDiversoAPI/InserirItem")]
        [HttpPost]
        public string InserirItem([FromForm] int ID_Peritagem, [FromForm] int Tipo_Item, [FromForm] string Descricao, [FromForm] int ID_Disposicao, [FromForm] int ID_Material, [FromForm] string Dureza,
                                           [FromForm] string Tratamento_Termico, [FromForm] string Peso, [FromForm] string Situacao, [FromForm] int Quantidade, [FromForm] string Rosca, [FromForm] string Modelo,
                                           [FromForm] int ID_Norma, [FromForm] string Local_Aplicado, [FromForm] string Passo, [FromForm] string Comprimento, [FromForm] int ID_Classe, [FromForm] bool Ruela_Pressao_Din12,
                                           [FromForm] string Dimensao, [FromForm] string Codigo, [FromForm] string Fabricante, [FromForm] string Observacao, [FromForm] string Labio, [FromForm]  string Borracha,
                                           [FromForm] string L1, [FromForm] string L2, [FromForm] string L3, [FromForm] string Altura, [FromForm] string Largura, [FromForm] string Produto, [FromForm] string Marca,
                                           [FromForm] string Medidas, int Usuario_Criador, [FromForm] string Classe)
        {

            ItemDiverso item = null;
            Disposicao dis = null;
            Material mat = null;
            TipoItem tipo = null;
            Usuario user = null;
            Norma nor = null;
            ItemDiversoNegocio itemNeg = null;
            ConverterGeral conGeral = null;

            bool resp = false;

            try
            {

                item = new ItemDiverso();
                dis = new Disposicao();
                mat = new Material();
                tipo = new TipoItem();
                user = new Usuario();
                nor = new Norma();
                itemNeg = new ItemDiversoNegocio();
                conGeral = new ConverterGeral();

                item.ID_Peritagem = ID_Peritagem;
                item.Altura = Altura == null ? "" : Altura;
                item.Largura = Largura == null ? "" : Largura;
                item.Comprimento = Comprimento == null ? "" : Comprimento;
                item.L1 = L1 == null ? "" : L1;
                item.L2 = L2 == null ? "" : L2;
                item.L3 = L3 == null ? "" : L3;

                item.Borracha = Borracha == null ? "" : Borracha;
                item.Codigo = Codigo == null ? "" : Codigo;
                item.Descricao = Descricao == null ? "" : Descricao;
                item.Modelo = Modelo == null ? "" : Modelo;
                item.Observacao = Observacao == null ? "" : Observacao;
                item.Passo = Passo == null ? "" : Passo;
                item.Quantidade = Quantidade;
                item.Rosca = Rosca == null ? "" : Rosca;
                item.RuelaDePressaDin12 = Convert.ToBoolean(Ruela_Pressao_Din12);
                item.Fabricante = Fabricante == null ? "" : Fabricante;
                item.Dureza = Dureza == null ? "" : Dureza;
                item.Labio = Labio == null ? "" : Labio;
                item.Dimensao = Dimensao == null ? "" : Dimensao;
                item.LocalAplicado = Local_Aplicado == null ? "" : Local_Aplicado;
                item.Produto = Produto == null ? "" : Produto;
                item.Marca = Marca == null ? "" : Marca;
                item.Medidas = Medidas == null ? "" : Medidas;
                item.Peso = Peso == null ? "" : Peso;
                item.Classe = Classe == null ? "" : Classe;

                dis.ID_Disposicao = ID_Disposicao;
                item.Disposicao = dis;

                mat.Id = ID_Material;
                item.Material = mat;

                nor.Id = ID_Norma;
                item.Norma = nor;

                tipo.Id = Tipo_Item;
                item.TipoItem = tipo;

                user.Id = Usuario_Criador;

                item.UsuarioCriador = user;

                if (itemNeg.InserirItem(item))
                {
                    return "Inserido!";
                }
                

            }
            catch (Exception ex)
            {
                return  ex.ToString();
            }

            return "Não foi possivel inserir";
        }

        [Route("api/ItemDiversoAPI/GravarAlteracao")]
        [HttpPost]
        public String GravarAlteracao([FromForm] int ID_ItemDiverso, [FromForm] string Descricao, [FromForm] int ID_Disposicao, [FromForm] int ID_Material, [FromForm] string Dureza,
                                          [FromForm] string Tratamento_Termico, [FromForm] string Peso, [FromForm] string Situacao, [FromForm] int Quantidade, [FromForm] string Rosca, [FromForm] string Modelo,
                                          [FromForm] int ID_Norma, [FromForm] string Local_Aplicado, [FromForm] string Passo, [FromForm] string Comprimento, [FromForm] int ID_Classe, [FromForm] bool Ruela_Pressao_Din12,
                                          [FromForm] string Dimensao, [FromForm] string Codigo, [FromForm] string Fabricante, [FromForm] string Observacao, [FromForm]  string Labio, [FromForm] string Borracha,
                                          [FromForm] string L1, [FromForm] string L2, [FromForm] string L3, [FromForm] string Altura, [FromForm] string Largura, [FromForm] string Produto, [FromForm] string Marca,
                                          [FromForm] string Medidas, [FromForm] string Classe)
        {

            ItemDiverso item = new ItemDiverso();
            Disposicao dis = new Disposicao();
            Material mat = new Material();
            Norma nor = new Norma();
            ItemDiversoNegocio itemNeg = new ItemDiversoNegocio();
            ConverterGeral conGeral = new ConverterGeral();

            bool resp = false;

            try
            {

                item.Id = ID_ItemDiverso;
                item.Altura = Altura == null ? "" : Altura;
                item.Largura = Largura == null ? "" : Largura;
                item.Comprimento = Comprimento == null ? "" : Comprimento;
                item.L1 = L1 == null ? "" : L1;
                item.L2 = L2 == null ? "" : L2;
                item.L3 = L3 == null ? "" : L3;

                item.Borracha = Borracha == null ? "" : Borracha;
                item.Codigo = Codigo == null ? "" : Codigo;
                item.Descricao = Descricao == null ? "" : Descricao;
                item.Modelo = Modelo == null ? "" : Modelo;
                item.Observacao = Observacao == null ? "" : Observacao;
                item.Passo = Passo == null ? "" : Passo;
                item.Quantidade = Quantidade;
                item.Rosca = Rosca == null ? "" : Rosca;
                item.RuelaDePressaDin12 = Convert.ToBoolean(Ruela_Pressao_Din12);
                item.Fabricante = Fabricante == null ? "" : Fabricante;
                item.Dureza = Dureza == null ? "" : Dureza;
                item.Labio = Labio == null ? "" : Labio;
                item.Dimensao = Dimensao == null ? "" : Dimensao;
                item.LocalAplicado = Local_Aplicado == null ? "" : Local_Aplicado;
                item.Produto = Produto == null ? "" : Produto;
                item.Marca = Marca == null ? "" : Marca;
                item.Medidas = Medidas == null ? "" : Medidas;
                item.Peso = Peso == null ? "" : Peso;
                item.Classe = Classe == null ? "" : Classe;

                dis.ID_Disposicao = ID_Disposicao;
                item.Disposicao = dis;

                mat.Id = ID_Material;
                item.Material = mat;

                nor.Id = ID_Norma;
                item.Norma = nor;


                if (itemNeg.AlterarItem(item))
                {
                    return "Alterado com Sucesso!";
                }

            }
            catch (Exception ex)
            {
                return("---------------------" + ex.Message.ToString());
            }

            return "Não foi possível inserir";
        }

        [Route("api/ItemDiversoAPI/ExcluirItem")]
        [HttpPost]
        public String ExcluirItem([FromForm] int ID_ItemDiverso)
        {
            ItemDiversoNegocio itNeg = new ItemDiversoNegocio();
            ItemDiverso itDiv = new ItemDiverso();
            itDiv.Id = ID_ItemDiverso;

            if (itNeg.ExcluirItem(itDiv))
            {
                return "Excluido com sucesso!";
            }
            return "Não foi possível excluir!";
        }

    }
}