using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Negocio;
using ProjetoPeritagem.ViewHelper;

namespace ProjetoPeritagem.Controllers
{
    [Authorize]
    public class DisposicaoController : Controller
    {
        public IActionResult Index()
        {
            DisposicaoNegocio disNeg = new DisposicaoNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            vwPer.listDisposicao = disNeg.ListaDisposicao();
            vwPer.usuario = UsuarioLogado();

            return View(vwPer);
        }

        public IActionResult CadastrarDisposicao()
        {
            return View();
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