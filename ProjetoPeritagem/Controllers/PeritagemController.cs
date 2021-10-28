using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoPeritagem.Models;
using Negocio;
using Modelo;
using ProjetoPeritagem.ViewHelper;
using Microsoft.AspNetCore.Http;
using Modelo.Util;
using Microsoft.AspNetCore.Authorization;
using Rotativa.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ProjetoPeritagem.Controllers
{
    [Authorize]
    public class PeritagemController : Controller
    {

        public static IHostingEnvironment _environment;

        public PeritagemController(IHostingEnvironment environment)
        {
            _environment = environment;
        }


        public IActionResult Index()
        {
            return View();  
        }


        [HttpGet]
        public IActionResult AlterarPeritagem(int ID_Peritagem)
        {
            ClienteNegocio cliNeg = new ClienteNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            per.Id = ID_Peritagem;

            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.listCliente = cliNeg.ListaCliente();
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);
            vwPer.usuario = UsuarioLogado();
            return View(vwPer);
        }


        [HttpPost]
        public IActionResult CadastrarPeritagem(DateTime DT_Chegada, DateTime DT_Inicio, DateTime DT_Previsao, int ID_Cliente, int NumeroNota, int NumeroContrato,
            int NumeroOrcamento, string Protocolo, string Referencia, string Motivo_Manutencao, string Aplicacao, string Observacao, IFormFile[] Documento, string Descricao )
        {

            Modelo.Peritagem per = new Modelo.Peritagem();
            Cliente cli = new Cliente();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            Documento doc = new Documento();
            Usuario user = new Usuario();
            TratarDocumento tDoc = null;
            DocumentoNegocio docNeg = null;
            ClienteNegocio cliNeg = new ClienteNegocio();

            // user.Id = Convert.ToInt32(HttpContext.Session.GetString("id"));

            if (ID_Cliente != 0 && NumeroNota != 0 && DT_Chegada != null)
            {
                per.Descricao = Descricao == null ? "" : Descricao;
                cli.Id = ID_Cliente;
                per.Cliente = cli;
                per.Dt_Chegada = Convert.ToDateTime(DT_Chegada);
                per.Dt_Inicio = Convert.ToDateTime(DT_Inicio);
                per.Dt_Previsao = Convert.ToDateTime(DT_Previsao);
                per.Dt_Cadastro = DateTime.Now;
                per.Nfe = NumeroNota;
                per.NumeroContrato = NumeroContrato;
                per.ID_Orcamento = NumeroOrcamento;
                per.Protocolo = (Protocolo == null ? "" : Protocolo);
                per.Referencia = (Referencia == null ? "" : Referencia);
                per.MotivoManutencao = (Motivo_Manutencao == null ? "" : Motivo_Manutencao);
                per.Aplicacao = (Aplicacao == null ? "" : Aplicacao);
                per.Observacao = (Observacao == null ? "" : Observacao);
                per.UsuarioCriador = UsuarioLogado();

                cli.Id = ID_Cliente;
                cli = cliNeg.ConsultarUM(cli);

                if(perNeg.ConsultarNota(per) != true)
                {
                    if (perNeg.InserirPeritagem(per))
                    {
                        if (Documento.Length != 0)
                        {
                            int i = 0;
                            while (i < Documento.Length) {
                                 tDoc = new TratarDocumento();
                                 docNeg = new DocumentoNegocio();

                                doc.ID_Peritagem = perNeg.ConsultarUltima(per);
                                doc.Caminho = tDoc.GravarDocumento(Documento[i], cli.Nome, 0, NumeroNota);
                                doc.Nome = Documento[i].FileName;
                                docNeg.InserirDocumento(doc);
                                i++;
                            }
                        }
                        return RedirectToAction("ListarPeritagem", new { Status = true });
                    }
                }
                
            }
            return RedirectToAction("InserirPeritagem");
        }

        [HttpGet]
        public IActionResult InserirPeritagem()
        {
            ClienteNegocio cliNeg = new ClienteNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();

            vwPer.listCliente = cliNeg.ListaCliente();
            vwPer.usuario = UsuarioLogado();

            return View(vwPer);
        }


        [HttpGet]
        public IActionResult ExcluirPeritagem(int ID_Peritagem)
        {
            PeritagemNegocio perNeg = new PeritagemNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            per.Id = ID_Peritagem;

            perNeg.ExcluirPeritagem(per);

            return RedirectToAction("ListarPeritagem", new { page = 1, NFE = 0, ID_Cliente = 0, ID_Situacao = 0 });
        }

        [HttpGet]
        public IActionResult AlterarSituacao(int ID_Peritagem, int ID_Situacao)
        {
            PeritagemNegocio perNeg = new PeritagemNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            Situacao sit = new Situacao();

            sit.Id = ID_Situacao;
            per.Id = ID_Peritagem;
            per.Situacao = sit;

            perNeg.AlterarSituacao(per);

            return RedirectToAction("ListarPeritagem", new { page = 1, NFE = 0, ID_Cliente = 0, ID_Situacao = 0 });
        }



        [HttpGet]
        public  IActionResult ListarPeritagem(int page, int NFE, int ID_Cliente, int ID_Situacao, string NomeEquipamento)
        {

            PeritagemNegocio perNeg = new PeritagemNegocio();
            ViewHelperPeritagem vw = new ViewHelperPeritagem();
            ClienteNegocio cliNeg = new ClienteNegocio();
            SituacaoNegocio sitNeg = new SituacaoNegocio();

            vw.listPeritagem = perNeg.ConsultarTodos(page, 10, NFE, ID_Cliente, ID_Situacao, NomeEquipamento);
            vw.quantidade = perNeg.QuantidadePeritagem();
            vw.page = page;
            vw.listCliente = cliNeg.ListaCliente();
            vw.listSituacao = sitNeg.ListarSituacao();

            int qt = vw.quantidade;
            float totalPg = (float)qt / 5;
            vw.pages = Convert.ToInt32(Math.Ceiling(totalPg));
            vw.usuario = UsuarioLogado();

            return View(vw);
        }

        [HttpGet]
        public IActionResult Visualizar(int ID_Peritagem)
        {
            CarcacaNegocio carNeg = new CarcacaNegocio();
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            ItemDiversoNegocio itemDivNeg = new ItemDiversoNegocio();
            DocumentoNegocio docNeg = new DocumentoNegocio();
            RedutorNegocio redNeg= new RedutorNegocio();
            Redutor red = new Redutor();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            ViewHelperPeritagem vw = new ViewHelperPeritagem();
            ItemDiverso itDiv = new ItemDiverso();
            ImagemNegocio imgNeg = new ImagemNegocio();
            Imagem img = new Imagem();
            PecaNegocio pecNeg = new PecaNegocio();

            img.ID_Peritagem = ID_Peritagem;

            itDiv.ID_Peritagem = ID_Peritagem;

            red.ID_Peritagem = ID_Peritagem;

            per.Id = ID_Peritagem;
            per = perNeg.ConsultaUM(ID_Peritagem);
            per.ListDoc = docNeg.ListarDocumento(per.Id, 0);
            red.ID_Peritagem = ID_Peritagem;
            per.Redutor = redNeg.ConsultaUm(red);
            per.ListCarcaca = carNeg.ConsultarTodos(per);
            per.Acionamento = aciNeg.ConsultarAcionamento(per);
            per.ListPeca = pecNeg.Listar(per);
            vw.listItemDiverso = itemDivNeg.ConsultarTodos(itDiv);

            vw.ID_Peritagem = ID_Peritagem;
            vw.peritagem = per;
            vw.listImagem = imgNeg.ListarImagem(img);
            vw.usuario = UsuarioLogado();

            return View(vw);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult PeritagemPDF(int ID_Peritagem)
        {
            CarcacaNegocio carNeg = new CarcacaNegocio();
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            ItemDiversoNegocio itemDivNeg = new ItemDiversoNegocio();
            DocumentoNegocio docNeg = new DocumentoNegocio();
            RedutorNegocio redNeg = new RedutorNegocio();
            Redutor red = new Redutor();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            ViewHelperPeritagem vw = new ViewHelperPeritagem();
            ItemDiverso itDiv = new ItemDiverso();
            ImagemNegocio imgNeg = new ImagemNegocio();
            Imagem img = new Imagem();
            PecaNegocio pecNeg = new PecaNegocio();
            Acionamento aci = new Acionamento();

            img.ID_Peritagem = ID_Peritagem;

            itDiv.ID_Peritagem = ID_Peritagem;

            per.Id = ID_Peritagem;
            per = perNeg.ConsultaUM(ID_Peritagem);
            per.ListDoc = docNeg.ListarDocumento(per.Id, 0);

            vw.listRedutor = redNeg.ConsultaTodos(per);
            vw.listCarcaca = carNeg.ConsultarTodos(per);
            vw.acionamento = aciNeg.ConsultarAcionamento(per);

            vw.listPeca = pecNeg.Listar(per);
            vw.listItemDiverso = itemDivNeg.ConsultarTodos(itDiv);

            vw.peritagem = per;

            vw.listImagem = imgNeg.ListarImagem(img);
            //vw.usuario = UsuarioLogado();


            return new ViewAsPdf(vw);
        }

        [HttpPost]
        public IActionResult GravarAlteracao(DateTime DT_Chegada, DateTime DT_Inicio, DateTime DT_Previsao, DateTime DT_Revisao, DateTime DT_Finalizacao,  int NumeroContrato,
            int NumeroOrcamento, string Protocolo, string Referencia, string Motivo_Manutencao, string Aplicacao, string Observacao, string Descricao, int ID_Peritagem)
        {
            Modelo.Peritagem per = new Modelo.Peritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();

            per.Dt_Chegada = DT_Chegada;
            per.Dt_Inicio = DT_Inicio;
            per.Dt_Previsao = DT_Previsao;
            per.Dt_Revisao = DT_Revisao;
            per.Dt_Finalizacao = DT_Finalizacao;
            per.NumeroContrato = NumeroContrato;
            per.ID_Orcamento = NumeroOrcamento;
            per.Protocolo = Protocolo == null ? "" : Protocolo;
            per.Referencia = Referencia == null ? "" : Referencia;
            per.Aplicacao = Aplicacao == null ? "" : Aplicacao;
            per.MotivoManutencao = Motivo_Manutencao == null ? "" : Motivo_Manutencao;
            per.Descricao = Descricao == null ? "" : Descricao;
            per.Observacao = Observacao == null ? "" : Observacao;
            per.Id = ID_Peritagem;

            if (perNeg.AlterarPeritagem(per))
            {
                return RedirectToAction("ListarPeritagem", "Peritagem", new { page = 1, NFE = 0, ID_Cliente = 0, ID_Situacao = 0 });
            }
            return RedirectToAction("ListarPeritagem", "Peritagem", new { page = 1, NFE = 0, ID_Cliente = 0, ID_Situacao = 0 });
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