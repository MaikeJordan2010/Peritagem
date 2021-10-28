using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Modelo;
using ProjetoPeritagem.ViewHelper;
using Microsoft.AspNetCore.Http;
using ProjetoPeritagem.Services;
using Modelo.Util;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoPeritagem.Controllers
{
    [Authorize]
    public class AcionamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult InserirAcionamento(int ID_Peritagem)
        {

            DisposicaoNegocio disNeg = new DisposicaoNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            vwPer.listDisposicao = disNeg.ListaDisposicao();
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);
            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.usuario = UsuarioLogado();

            //ViewData["Usuario"] = HttpContext.Session.GetString("nome");

            if (aciNeg.ValidarExistencia(ID_Peritagem))
            {
                String msg = "Já existe um acionamento cadastrado!";
                ViewData["msg"] = msg;
            }

           return View(vwPer);
        }

        [HttpGet]
        public IActionResult ExcluirAcionamento(int ID_Peritagem, int ID_Acionamento)
        {
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            Acionamento aci = new Acionamento();

            aci.Id = ID_Acionamento;
            aciNeg.ExcluirAcionamento(aci);

            return RedirectToAction("ListarAcionamento", new { ID_Peritagem = ID_Peritagem });
        }

        [HttpPost]
        public IActionResult CadastrarAcionamento(string Tipo_Acionamento, string Fabricante, string Modelo, string Rotacao_Polos, string Potencia, string Descricao,string Nome,
                                                string Carcaca, int ID_Disposicao, int ID_Peritagem, bool Teste_Redutor, string Tipo_Teste, string Inspecao_Visual, string Descricao_Teste)
        {
            Acionamento aci = new Acionamento();
            Disposicao dis = new Disposicao();
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            ConverterGeral cGer = new ConverterGeral();
            per.Id = ID_Peritagem;
            vwPer.peritagem = per;
            vwPer.usuario = UsuarioLogado();

            if (!aciNeg.ValidarExistencia(ID_Peritagem))
            {

                aci.TipoAcionamento = Tipo_Acionamento == null ? "" : Tipo_Acionamento;
                aci.Fabricante = Fabricante == null ? "" : Fabricante;
                aci.Modelo = Modelo == null ? "" : Modelo;
                aci.Descricao = Descricao == null ? "" : Descricao;
                aci.Carcaca = Carcaca == null ? "" : Carcaca;
                aci.ID_Peritagem = ID_Peritagem;
                aci.Teste = Teste_Redutor;
                aci.TipoTeste = Tipo_Teste == null ? "" : Tipo_Teste;
                aci.InspecaoVisual = Inspecao_Visual == null ? "" : Inspecao_Visual;
                dis.ID_Disposicao = ID_Disposicao;
                aci.Disposicao = dis;
                aci.Nome = Nome == null ? "" : Nome;
                aci.Potencia = Potencia == null ? "" : Potencia;
                aci.RotacaoPolos = Rotacao_Polos == null ? "" : Rotacao_Polos;
                aci.DescricaoTeste = Descricao_Teste == null ? "" : Descricao_Teste;

                if (ID_Peritagem != 0)
                {
                    if (aciNeg.InserirAcionamento(aci))
                    {
                        return RedirectToAction("ListarAcionamento", new { ID_Peritagem = per.Id });
                    }
                }
            }
            else
            {
                String msg = "Já existe um acionamento cadastrado!";
                ViewData["msg"] = msg;
            }

            return RedirectToAction("InserirAcionamento", new { ID_Peritagem = per.Id });
        }

        [HttpGet]
        public IActionResult ListarAcionamento(int ID_Peritagem)
        {
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            per.Id = ID_Peritagem;
            vwPer.acionamento = aciNeg.ConsultarAcionamento(per);
            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.usuario = UsuarioLogado();
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);
            return View(vwPer);
        }

        public IActionResult AlterarAcionamento(int ID_Peritagem)
        {
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            DisposicaoNegocio disNeg = new DisposicaoNegocio();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();

            per.Id = ID_Peritagem;

            vwPer.acionamento = aciNeg.ConsultarAcionamento(per);
            vwPer.listDisposicao = disNeg.ListaDisposicao();
            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.usuario = UsuarioLogado();
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);

            return View(vwPer);
        }

        [HttpPost]
        public IActionResult GravarAlteracao(string Tipo_Acionamento, string Fabricante, string Modelo, string Rotacao_Polos, string Potencia, string Descricao, string Nome, string Descricao_Teste,
                                            string Carcaca, int ID_Disposicao, int ID_Peritagem, bool Teste_Redutor, string Tipo_Teste, string Inspecao_Visual, int ID_Acionamento)
        {
            Acionamento aci = new Acionamento();
            Disposicao dis = new Disposicao();
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();

            aci.TipoAcionamento = Tipo_Acionamento == null ? "" : Tipo_Acionamento;
            aci.Fabricante = Fabricante == null ? "" : Fabricante;
            aci.Modelo = Modelo == null ? "" : Modelo;
            aci.Descricao = Descricao == null ? "" : Descricao;
            aci.Carcaca = Carcaca == null ? "" : Carcaca;
            aci.ID_Peritagem = ID_Peritagem;
            aci.Teste = Teste_Redutor;
            aci.TipoTeste = Tipo_Teste == null ? "" : Tipo_Teste;
            aci.InspecaoVisual = Inspecao_Visual == null ? "" : Inspecao_Visual;
            dis.ID_Disposicao = ID_Disposicao;
            aci.Disposicao = dis;
            aci.Potencia = Potencia == null ? "" : Potencia;
            aci.RotacaoPolos = Rotacao_Polos == null ? "" : Rotacao_Polos;
            aci.ID_Peritagem = ID_Peritagem;
            aci.Nome = Nome == null ? "" : Nome;
            aci.Id = ID_Acionamento;
            aci.DescricaoTeste = Descricao_Teste == null ? "" : Descricao_Teste;

            if (ID_Acionamento != 0)
            {
                if (aciNeg.AlterarAcionamento(aci))
                {
                    return RedirectToAction("ListarAcionamento", new { ID_Peritagem = ID_Peritagem });
                }
            }

            return View("AlterarAcionamento", new { ID_Peritagem = ID_Peritagem });
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