using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Modelo;
using ProjetoPeritagem.ViewHelper;
using Microsoft.AspNetCore.Http;
using Modelo.Util;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoPeritagem.Controllers
{
    [Authorize]
    public class PecaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InserirPeca(int ID_Peritagem)
        {
            Modelo.Peritagem per = new Modelo.Peritagem();
            PeritagemNegocio PerNeg = new PeritagemNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            MaterialNegocio matNeg = new MaterialNegocio();
            DisposicaoNegocio disNeg = new DisposicaoNegocio();
            TipoPecaNegocio tipoNeg = new TipoPecaNegocio();


            if(ID_Peritagem != 0)
            {
                per.Id = ID_Peritagem;
                vwPer.peritagem = PerNeg.ConsultaUM(ID_Peritagem);
                vwPer.listDisposicao = disNeg.ListaDisposicao();
                vwPer.listMaterial = matNeg.ListarMaterial();
                vwPer.listTipoPeca = tipoNeg.ListarTipoPeca();
                vwPer.ID_Peritagem = ID_Peritagem;
                vwPer.usuario = UsuarioLogado();
            }

            return View(vwPer);
        }

        [HttpPost]
        public IActionResult CadastrarPeca(Peca peca, int ID_Material,int ID_Disposicao, int ID_TipoPeca, int ID_Peritagem, int[] W, string[] Valor_W, 
            string[] AnguloHelice, string[] AnguloPressao, string[] Modulo, string[] NumDentes, string[] Externo, string[] LarguraDente, string[] Medida_W, IFormFile[] Documento)
        {

            Disposicao dis = new Disposicao();
            Material mat = new Material();
            TipoPeca tipo = new TipoPeca();
            Peca_Dados peca_dados = null;
            PecaNegocio pecaNeg = new PecaNegocio();
            ConverterGeral cGer = new ConverterGeral();

            DocumentoNegocio docNeg = new DocumentoNegocio();
            Documento doc = null;
            PeritagemNegocio perNeg = new PeritagemNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            TratarDocumento tDoc = new TratarDocumento();

            int ID_Ultima = 0;


            dis.ID_Disposicao = ID_Disposicao;
            mat.Id = ID_Material;
            tipo.Id = ID_TipoPeca;

            peca.Disposicao = dis;
            peca.Material = mat;
            peca.TipoPeca = tipo;

            peca.ID_Peritagem = ID_Peritagem;
            peca.Descricao = peca.Descricao == null ? "" : peca.Descricao;
            peca.DescricaoRetrabalho = peca.DescricaoRetrabalho == null ? "" : peca.DescricaoRetrabalho;
            peca.Especial = peca.Especial == null ? "" : peca.Especial;
            peca.Altura = peca.Altura == null ? "" : peca.Altura;
            peca.Largura = peca.Largura == null ? "" : peca.Largura;
            peca.TratamentoTermico = peca.TratamentoTermico == null ? "" : peca.TratamentoTermico;
            peca.Produto = peca.Produto == null ? "" : peca.Produto;
            peca.MetodoFabricacao = peca.MetodoFabricacao == null ? "" : peca.MetodoFabricacao;
            peca.Desenho = peca.Desenho == null ? "" : peca.Desenho;
            peca.ValorK = peca.ValorK == null ? "" : peca.ValorK;
            peca.Peso = peca.Peso == null ? "" : peca.Peso;
            peca.Furo = peca.Furo == null ? "" : peca.Furo;
            peca.Dureza = peca.Dureza == null ? "" : peca.Dureza;
            peca.Dt_Cadastro = DateTime.Now;

            if (pecaNeg.Inserir(peca))
            {
                ID_Ultima = pecaNeg.ConsultaUltima(peca);

                for (int i = 0; i < Documento.Length; i++)
                {
                    doc = new Documento();
                    doc.Caminho = tDoc.GravarDocumento(Documento[i], per.Cliente.Nome, ID_Ultima, per.Nfe);
                    doc.ID_Peca = ID_Ultima;
                    doc.ID_Peritagem = ID_Peritagem;

                    docNeg.InserirDocumento(doc);
                }

             

                for (int i = 0; i < NumDentes.Length; i++)
                {
                    peca_dados = new Peca_Dados();

                    peca_dados.NumDentes = NumDentes[i] == null ? "" : NumDentes[i];
                    peca_dados.AnguloHelice = AnguloHelice[i] == null ? "" : AnguloHelice[i];
                    peca_dados.AnguloPressao = AnguloPressao[i] == null ? "" : AnguloPressao[i];
                    peca_dados.Modulo = Modulo[i] == null ? "" : Modulo[i];
                    peca_dados.Externo = Externo[i] == null ? "" : Externo[i];
                    peca_dados.LarguraDente = LarguraDente[i] == null ? "" : LarguraDente[i];
                    peca_dados.Medida_W = Medida_W[i] == null ? "" : Medida_W[i];
                    peca_dados.ID_Peca = ID_Ultima;

                    pecaNeg.InserirPecaDados(peca_dados);
                }

                return RedirectToAction("ListarPeca", new { ID_Peritagem = peca.ID_Peritagem });
            }

            return RedirectToAction("InserirPeca",new { ID_Peritagem = peca.ID_Peritagem });
        }

        [HttpGet]
        public IActionResult ListarPeca(int ID_Peritagem)
        {
            Modelo.Peritagem per = new Modelo.Peritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            PecaNegocio pecNeg = new PecaNegocio();

            per.Id = ID_Peritagem;
            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);
            vwPer.listPeca = pecNeg.Listar(per);
            vwPer.usuario = UsuarioLogado();

            return View(vwPer);
        }

        [HttpGet]
        public IActionResult ExcluirPeca(int ID_Peritagem, int ID_Peca)
        {
            PecaNegocio pecNeg = new PecaNegocio();
            Peca pec = new Peca();

            pec.Id = ID_Peca;

            pecNeg.ExcluirPeca(pec);

            return RedirectToAction("ListarPeca", new { ID_Peritagem = ID_Peritagem });
        }

        [HttpGet]
        public IActionResult AlterarPeca(int ID_Peca, int ID_Peritagem)
        {
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            PecaNegocio pecNeg = new PecaNegocio();
            DisposicaoNegocio disNeg = new DisposicaoNegocio();
            TipoPecaNegocio tipoNeg = new TipoPecaNegocio();
            MaterialNegocio matNeg = new MaterialNegocio();
            PeritagemNegocio perNeg = new PeritagemNegocio();



            Peca peca = new Peca();

            peca.Id = ID_Peca;

            vwPer.peca = pecNeg.ConsultaUM(peca);
            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.listTipoPeca = tipoNeg.ListarTipoPeca();
            vwPer.listDisposicao = disNeg.ListaDisposicao();
            vwPer.listMaterial = matNeg.ListarMaterial();
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);
            vwPer.usuario = UsuarioLogado();



            if (vwPer.peca != null)
            {
                return View(vwPer);
            }
            return RedirectToAction("ListarPeca", new { ID_Peritagem = ID_Peritagem });
        }


        [HttpGet]
        public IActionResult ExcluirValorW(int ID, int ID_Peca, int ID_Peritagem)
        {

            PecaNegocio pecNeg = new PecaNegocio();

            Peca_W w = new Peca_W();


                if (ID != 0)
                {
                    w.Id = ID;

                    pecNeg.ExcluirValoresW(w);
                }
            return RedirectToAction("AlterarPeca", new { ID_Peca = ID_Peca, ID_Peritagem = ID_Peritagem });
        }


        [HttpGet]
        public IActionResult ExcluirDocumento(int ID, int ID_Peca, int ID_Peritagem)
        {

            DocumentoNegocio docNeg = new DocumentoNegocio();

            Documento doc = new Documento();


            if (ID != 0)
            {
                doc.Id = ID;

                docNeg.ExcluirDocumento(doc);
            }
            return RedirectToAction("AlterarPeca", new { ID_Peca = ID_Peca, ID_Peritagem = ID_Peritagem });
        }





        [HttpPost]
        public IActionResult GravarAlteracao(int[] ID_Valor_W, int[] W, string[] Valor_W, Peca peca, int ID_Material, int ID_Disposicao, int ID_TipoPeca, int ID_Peritagem, int ID_Peca,
            string[] AnguloHelice, string[] AnguloPressao, string[] Modulo, string[] NumDentes, string[] Externo, string[] LarguraDente, int[] ID_Peca_Dados, string[] Medida_W, IFormFile[] Documento)
        {
            Disposicao dis = new Disposicao();
            Material mat = new Material();
            TipoPeca tipo = new TipoPeca();
            PecaNegocio pecaNeg = new PecaNegocio();
            ConverterGeral cGer = new ConverterGeral();
            DocumentoNegocio docNeg = new DocumentoNegocio();
            Documento doc = null;
            PeritagemNegocio perNeg = new PeritagemNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            TratarDocumento tDoc = new TratarDocumento();


            dis.ID_Disposicao = ID_Disposicao;
            mat.Id = ID_Material;
            tipo.Id = ID_TipoPeca;
            Peca_W peca_w = null;
            Peca_Dados peca_dados = null;

            peca.Disposicao = dis;
            peca.Material = mat;
            peca.TipoPeca = tipo;

            peca.Id = ID_Peca;
            peca.ID_Peritagem = ID_Peritagem;
            peca.Descricao = peca.Descricao == null ? "" : peca.Descricao;
            peca.DescricaoRetrabalho = peca.DescricaoRetrabalho == null ? "" : peca.DescricaoRetrabalho;
            peca.Especial = peca.Especial == null ? "" : peca.Especial;
            peca.Altura = peca.Altura == null ? "" : peca.Altura;
            peca.Largura = peca.Largura == null ? "" : peca.Largura;
            peca.Nome = peca.Nome == null ? "" : peca.Nome;
            peca.TratamentoTermico = peca.TratamentoTermico == null ? "" : peca.TratamentoTermico;
            peca.Sentido = peca.Sentido == null ? "" : peca.Sentido;
            peca.Produto = peca.Produto == null ? "" : peca.Produto;
            peca.MetodoFabricacao = peca.MetodoFabricacao == null ? "" : peca.MetodoFabricacao;
            peca.Desenho = peca.Desenho == null ? "" : peca.Desenho;
            peca.ValorK = peca.ValorK == null ? "" : peca.ValorK;
            peca.Peso = peca.Peso == null ? "" : peca.Peso;
            peca.Furo = peca.Furo == null ? "" : peca.Furo;
            peca.Dureza = peca.Dureza == null ? "" : peca.Dureza;
            //tDoc.GravarDocumento(Documento[0], per.Cliente.Nome, ID_Peca, per.Nfe);

            per = perNeg.ConsultaUM(ID_Peritagem);


            if (pecaNeg.AlterarPeca(peca))
            {

                for(int i = 0; i < Documento.Length; i++)
                {
                    doc = new Documento();
                    doc.Caminho = tDoc.GravarDocumento(Documento[i], per.Cliente.Nome, ID_Peca, per.Nfe);
                    doc.ID_Peca = ID_Peca;
                    doc.ID_Peritagem = ID_Peritagem;
                    doc.Nome = Documento[i].FileName;

                    docNeg.InserirDocumento(doc);
                }


                for (int i = 0; i < NumDentes.Length; i++)
                {
                    peca_dados = new Peca_Dados();

                    peca_dados.NumDentes = NumDentes[i] == null ? "" : NumDentes[i];
                    peca_dados.AnguloHelice = AnguloHelice[i] == null ? "" : AnguloHelice[i];
                    peca_dados.AnguloPressao = AnguloPressao[i] == null ? "" : AnguloPressao[i];
                    peca_dados.Modulo = Modulo[i] == null ? "" : Modulo[i];
                    peca_dados.Externo = Externo[i] == null ? "" : Externo[i];
                    peca_dados.LarguraDente = LarguraDente[i] == null ? "" : LarguraDente[i];
                    peca_dados.Medida_W = Medida_W[i] == null ? "" : Medida_W[i];
                    peca_dados.Id = ID_Peca_Dados[i];
                    peca_dados.ID_Peca = ID_Peca;

                    if(peca_dados.Id == 0)
                    {
                        if(NumDentes[i] !="" && NumDentes[i]  != null || Modulo[i] != null && Modulo[i] != "" || AnguloPressao[i] != null && AnguloPressao[i] != "")
                        {
                            pecaNeg.InserirPecaDados(peca_dados);
                        }
                    }
                    else
                    {
                        pecaNeg.AlterarPecaDados(peca_dados);
                    }

                }

                return RedirectToAction("ListarPeca", new { ID_Peritagem = ID_Peritagem, ID_Peca = peca.Id});
            }

            return RedirectToAction("AlterarPeca", new { ID_Peritagem = ID_Peritagem, ID_Peca = peca.Id});
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