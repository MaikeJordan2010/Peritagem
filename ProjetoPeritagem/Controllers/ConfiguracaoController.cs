using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Negocio;
using ProjetoPeritagem.ViewHelper;

namespace ProjetoPeritagem.Controllers
{
    public class ConfiguracaoController : Controller
    {
        public IActionResult Index()
        {
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            vwPer.usuario = UsuarioLogado();

            return View(vwPer);
        }


        public IActionResult ListarConfiguracao()
        {
            ConfiguracaoNegocio confNeg = new ConfiguracaoNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();

            vwPer.listConfiguracao = confNeg.ListarConfiguracao();
            vwPer.usuario = UsuarioLogado();

            return View(vwPer);
        }


        public IActionResult AlterarConfiguracao(int ID_Configuracao)
        {
            ConfiguracaoNegocio confNeg = new ConfiguracaoNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();

            vwPer.configuracao = confNeg.ConsultarUM(ID_Configuracao);
            vwPer.usuario = UsuarioLogado();

            return View(vwPer);
        }

        [HttpPost]
        public IActionResult GravarConfiguracao(string Nome, string Descricao, string Dominio, string Porta, string Protocolo)
        {
            Configuracao conf = new Configuracao();
            ConfiguracaoNegocio confNeg = new ConfiguracaoNegocio();

            conf.Nome = Nome == null ? "" : Nome;
            conf.Descricao = Descricao == null ? "" : Descricao;
            conf.Dominio = Dominio == null ? "" : Dominio;
            conf.Porta = Porta == null ? "" : Porta;
            conf.Protocolo = Protocolo == null ? "" : Protocolo;

            if (confNeg.InserirConfiguracao(conf))
            {
                return RedirectToAction("ListarConfiguracao");
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult GravarAlteracao(string Nome, string Descricao, string Dominio, string Porta, string Protocolo, int ID_Configuracao)
        {
            Configuracao conf = new Configuracao();
            ConfiguracaoNegocio confNeg = new ConfiguracaoNegocio();

            conf.Id = ID_Configuracao;
            conf.Nome = Nome == null ? "" : Nome;
            conf.Descricao = Descricao == null ? "" : Descricao;
            conf.Dominio = Dominio == null ? "" : Dominio;
            conf.Porta = Porta == null ? "" : Porta;
            conf.Protocolo = Protocolo == null ? "" : Protocolo;

            if (confNeg.AlterarConfiguracao(conf))
            {
                return RedirectToAction("ListarConfiguracao");
            }

            return RedirectToAction("AlterarConfiguracao", new { ID_Configuracao = ID_Configuracao });
        }


        [HttpGet]
        public IActionResult GravarPadrao(int ID_Configuracao)
        {
            Configuracao conf = new Configuracao();
            ConfiguracaoNegocio confNeg = new ConfiguracaoNegocio();

            conf.Id = ID_Configuracao;

            confNeg.AlterarPadrao(conf);
            return RedirectToAction("ListarConfiguracao");
        }

        [HttpGet]
        public IActionResult ExcluirConfiguracao(int ID_Configuracao)
        {
            Configuracao conf = new Configuracao();
            ConfiguracaoNegocio confNeg = new ConfiguracaoNegocio();

            conf.Id = ID_Configuracao;

            confNeg.ExcluirConfiguracao(conf);
            return RedirectToAction("ListarConfiguracao");
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