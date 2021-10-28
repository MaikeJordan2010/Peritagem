using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Util;
using Negocio;
using Modelo;
using ProjetoPeritagem.ViewHelper;

namespace ProjetoPeritagem.Controllers
{
    [Authorize]
    public class ItemDiversoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InserirItem(int ID_Peritagem)
        {
            TipoItemNegocio tipoNeg = new TipoItemNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            DisposicaoNegocio disNeg = new DisposicaoNegocio();
            NormaNegocio norNeg = new NormaNegocio();
            MaterialNegocio matNeg = new MaterialNegocio();
            PeritagemNegocio perNeg = new PeritagemNegocio();


            vwPer.listMaterial = matNeg.ListarMaterial();
            vwPer.listNorma = norNeg.ListarNorma();
            vwPer.listTipoItem = tipoNeg.ListaTipoItem();
            vwPer.listDisposicao = disNeg.ListaDisposicao();
            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.usuario = UsuarioLogado();
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);
            return View(vwPer);
        }

        [HttpGet]
        public IActionResult ExcluirItem(int ID_Peritagem, int ID_ItemDiverso)
        {
            ItemDiversoNegocio itNeg = new ItemDiversoNegocio();
            ItemDiverso itDiv = new ItemDiverso();
            itDiv.Id = ID_ItemDiverso;

            itNeg.ExcluirItem(itDiv);

            return RedirectToAction("ListarItem", new { ID_Peritagem = ID_Peritagem });
        }

        [HttpPost]
        public IActionResult CadastrarItem(int ID_Peritagem, int[] Tipo_Item, string[] Descricao, int[] ID_Disposicao, int[] ID_Material, string[] Dureza,
                                           string[] Tratamento_Termico, string[] Peso, string[] Situacao, int[] Quantidade, string[] Rosca, string[] Modelo,
                                           int[] ID_Norma, string[] Local_Aplicado, string[] Passo, string[] Comprimento, int[] ID_Classe, bool[] Ruela_Pressao_Din12,
                                           string[] Dimensao, string[] Codigo, string[] Fabricante, string[] Observacao, string[] Labio, string[] Borracha,
                                           string[] L1, string[] L2, string[] L3, string[] Altura, string[] Largura, string[] Produto, string[] Marca,
                                           string[] Medidas, string[] Classe)
        {

            ItemDiverso item = null;
            Disposicao dis = null;
            Material mat = null;
            TipoItem tipo = null;
            Usuario user = null;
            Norma nor = null;
            ItemDiversoNegocio itemNeg = new ItemDiversoNegocio();
            ConverterGeral conGeral = new ConverterGeral();

            bool resp = false;

            try
            {
                for (int i = 0; i < Tipo_Item.Length; i++)
                {
                    item = new ItemDiverso();
                    dis = new Disposicao();
                    mat = new Material();
                    tipo = new TipoItem();
                    user = new Usuario();
                    nor = new Norma();
                    
                    item.ID_Peritagem = ID_Peritagem;
                    item.Altura = Altura.Length == 0 ? "" : Altura[i];
                    item.Largura = Largura.Length == 0 ? "" : Largura[i];
                    item.Comprimento = Comprimento.Length == 0 ? "" : Comprimento[i];
                    item.L1 = L1.Length == 0 ? "" : L1[i];
                    item.L2 = L2.Length == 0 ? "" : L2[i];
                    item.L3 = L3.Length == 0 ? "" : L3[i];
                    
                    item.Borracha = Borracha.Length == 0 ? "" : Borracha[i];
                    item.Codigo = Codigo.Length == 0 ? "" : Codigo[i];
                    item.Descricao = Descricao.Length == 0 ? "" : Descricao[i];
                    item.Modelo = Modelo.Length == 0 ? "" : Modelo[i];
                    item.Observacao = Observacao.Length == 0 ? "" : Observacao[i];
                    item.Passo = Passo.Length == 0 ? "" : Passo[i];
                    item.Quantidade = Quantidade.Length == 0 ? 0 : Quantidade[i];
                    item.Rosca = Rosca.Length == 0 ? "" : Rosca[i];
                    item.RuelaDePressaDin12 = Ruela_Pressao_Din12.Length == 0 ? false : Ruela_Pressao_Din12[i] ;
                    item.Fabricante = Fabricante.Length == 0 ? "" : Fabricante[i];
                    item.Dureza = Dureza.Length == 0 ? "" : Dureza[i];
                    item.Labio = Labio.Length == 0 ? "" : Labio[i];
                    item.Dimensao = Dimensao.Length == 0 ? "" : Dimensao[i];
                    item.LocalAplicado = Local_Aplicado.Length == 0 ? "" : Local_Aplicado[i];
                    item.Produto = Produto.Length == 0 ? "" : Produto[i];
                    item.Marca = Marca.Length == 0 ? "" : Marca[i];
                    item.Medidas = Medidas.Length == 0 ? "" : Medidas[i];
                    item.Peso = Peso.Length == 0 ? "" : Peso[i];
                    item.Classe = Classe.Length == 0 ? "" : Classe[i];

                    user.Id = Convert.ToInt32(HttpContext.Session.GetString("id_usuario"));
                    item.UsuarioCriador = user;

                    tipo.Id = Tipo_Item[i];
                    item.TipoItem = tipo;

                    dis.ID_Disposicao = ID_Disposicao.Length == 0 ? 0 : ID_Disposicao[i];
                    item.Disposicao = dis;

                    mat.Id = ID_Material.Length == 0 ? 0 : ID_Material[i];
                    item.Material = mat;

                    nor.Id = ID_Norma.Length == 0 ? 0 : ID_Norma[i];
                    item.Norma = nor;
                    
                    resp = itemNeg.InserirItem(item);
                   
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            if (!resp)
            {
                return RedirectToAction("InserirItem", new { ID_Peritagem = ID_Peritagem });
            }
            return RedirectToAction("ListarItem", new { ID_Peritagem = ID_Peritagem });
        }

        [HttpGet]
        public IActionResult ListarItem(int ID_Peritagem)
        {
            ItemDiversoNegocio itemNeg = new ItemDiversoNegocio();
            ItemDiverso item = new ItemDiverso();
            item.ID_Peritagem = ID_Peritagem;
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();

            vwPer.listItemDiverso = itemNeg.ConsultarTodos(item);
            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);
            vwPer.usuario = UsuarioLogado();


            return View(vwPer);
        }

        [HttpGet]
        public IActionResult AlterarItem(int ID_Item, int ID_Peritagem)
        {
            TipoItemNegocio tipoNeg = new TipoItemNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            DisposicaoNegocio disNeg = new DisposicaoNegocio();
            NormaNegocio norNeg = new NormaNegocio();
            MaterialNegocio matNeg = new MaterialNegocio();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            ItemDiversoNegocio itemNeg = new ItemDiversoNegocio();

            vwPer.listMaterial = matNeg.ListarMaterial();
            vwPer.listNorma = norNeg.ListarNorma();
            vwPer.listTipoItem = tipoNeg.ListaTipoItem();
            vwPer.listDisposicao = disNeg.ListaDisposicao();
            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.usuario = UsuarioLogado();
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);
            vwPer.item = itemNeg.ConsultarUm(ID_Item);

            return View(vwPer);
        }

        [HttpPost]
        public IActionResult GravarAlteracao(int ID_Peritagem, string Descricao, int ID_Disposicao, int ID_Material, string Dureza, int ID_Item,
                                           string Tratamento_Termico, string Peso, string Situacao, int Quantidade, string Rosca, string Modelo,
                                           int ID_Norma, string Local_Aplicado, string Passo, string Comprimento, int ID_Classe, bool Ruela_Pressao_Din12,
                                           string Dimensao, string Codigo, string Fabricante, string Observacao, string Labio, string Borracha,
                                           string L1, string L2, string L3, string Altura, string Largura, string Produto, string Marca,
                                           string Medidas, string Classe)
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
                item.RuelaDePressaDin12 = Ruela_Pressao_Din12;
                item.Fabricante = Fabricante == null ? "" : Fabricante;
                item.Dureza = Dureza == null ? "" : Dureza;
                item.Labio = Labio == null ? "" : Labio;
                item.Dimensao = Dimensao == null ? "" : Dimensao;
                item.LocalAplicado = Local_Aplicado == null ? "" : Local_Aplicado;
                item.Produto = Produto == null ? "" : Produto;
                item.Marca = Marca == null ? "" : Marca;
                item.Medidas = Medidas == null ? "" : Medidas;
                item.Peso = Peso == null ? "" : Peso;
                item.Id = ID_Item;
                item.Classe = Classe == null ? "" : Classe;

                dis.ID_Disposicao = ID_Disposicao;
                item.Disposicao = dis;

                mat.Id = ID_Material;
                item.Material = mat;

                nor.Id = ID_Norma;
                item.Norma = nor;


                if (itemNeg.AlterarItem(item))
                {
                    return RedirectToAction("ListarItem", new { ID_Peritagem = ID_Peritagem });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------" + ex.Message.ToString());
            }

            return RedirectToAction("AlterarItem", new { ID_Peritagem = ID_Peritagem, ID_Item = ID_Item });
        }


            public Usuario UsuarioLogado()
        {
            Usuario user = new Usuario();

            user.Id = Convert.ToInt32(HttpContext.Session.GetString("id"));
            user.Nome = HttpContext.Session.GetString("nome");
            user.Email = HttpContext.Session.GetString("email");

            return user;
        }
    }
}