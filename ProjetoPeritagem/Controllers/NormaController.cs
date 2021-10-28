using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Modelo;
using ProjetoPeritagem.ViewHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoPeritagem.Controllers
{
    [Authorize]
    public class NormaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InserirNorma()
        {

            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            vwPer.usuario = UsuarioLogado();
            return View(vwPer);
        }

        [HttpGet]
        public IActionResult AlterarNorma(int ID_Norma)
        {
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            NormaNegocio norNeg = new NormaNegocio();
            vwPer.norma = norNeg.ConsultarUm(ID_Norma);
            vwPer.usuario = UsuarioLogado();
            return View(vwPer);
        }


        [HttpGet]
        public IActionResult ExcluirNorma(int ID_Norma)
        {
            NormaNegocio norNeg = new NormaNegocio();
            Norma nor = new Norma();
            nor.Id = ID_Norma;
            norNeg.ExcluirNorma(nor);
            return RedirectToAction("ListarNorma");
        }

        [HttpPost]
        public IActionResult CadastrarNorma(string Nome, string Descricao)
        {
            Norma nor = new Norma();
            NormaNegocio norNeg = new NormaNegocio();

            if(Nome != null || Nome != "")
            {
                nor.Nome = Nome == null ? "" : Nome;
                nor.Descricao = Descricao == null ? "" : Descricao;

                if (norNeg.InserirNorma(nor))
                {
                    return RedirectToAction("ListarNorma");
                }
            }
            return View("InserirNorma");
        }


        [HttpPost]
        public IActionResult GravarAlteracao(string Nome, string Descricao, int ID_Norma)
        {
            Norma nor = new Norma();
            NormaNegocio norNeg = new NormaNegocio();

            if (Nome != null || Nome != "")
            {
                nor.Nome = Nome == null ? "" : Nome;
                nor.Descricao = Descricao == null ? "" : Descricao;
                nor.Id = ID_Norma;

                if (norNeg.AlterarNorma(nor))
                {
                    return RedirectToAction("ListarNorma");
                }
            }
            return RedirectToAction("AlterarNorma", new { ID_Norma = ID_Norma });
            
        }


        public IActionResult ListarNorma()
        {
            NormaNegocio norNeg = new NormaNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            vwPer.listNorma = norNeg.ListarNorma();
            vwPer.usuario = UsuarioLogado();

            return View(vwPer);
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