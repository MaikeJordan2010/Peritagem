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
    public class MaterialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListarMaterial()
        {
            MaterialNegocio matNeg = new MaterialNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();

            vwPer.listMaterial = matNeg.ListarMaterial();
            vwPer.usuario = UsuarioLogado();


            return View(vwPer);
        }

        public IActionResult InserirMaterial()
        {
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            vwPer.usuario = UsuarioLogado();

            return View(vwPer);
        }

        [HttpPost]
        public IActionResult CadastrarMaterial(string Nome,string Descricao )
        {
            Material mat = new Material();
            MaterialNegocio matNeg = new MaterialNegocio();

            if(Nome != null || Nome != "")
            {
                mat.Nome = Nome == null ? "" : Nome;
                mat.Descricao = Descricao.Equals(null) ? "" : Descricao;

                if (matNeg.InserirMaterial(mat))
                {
                    return RedirectToAction("ListarMaterial");
                }
            }

            return RedirectToAction("InserirMaterial");

        }

        [HttpGet]
        public IActionResult AlterarMaterial(int ID_Material)
        {
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            MaterialNegocio matNeg = new MaterialNegocio();

            vwPer.material =  matNeg.ConsultarUm(ID_Material);
            vwPer.usuario = UsuarioLogado();

            return View(vwPer);
        }
        [HttpGet]
        public IActionResult ExcluirMaterial(int ID_Material)
        {
            MaterialNegocio matNeg = new MaterialNegocio();
            Material mat = new Material();
            mat.Id = ID_Material;

            matNeg.ExcluirMaterial(mat);
            return RedirectToAction("ListarMaterial");

        }

        [HttpPost]
        public IActionResult GravarAlteracao(string Nome, string Descricao, int ID_Material)
        {
            Material mat = new Material();
            MaterialNegocio matNeg = new MaterialNegocio();

            mat.Nome = Nome;
            mat.Descricao = Descricao.Equals(null) ? "" : Descricao;
            mat.Id = ID_Material;

            if (matNeg.AlterarMaterial(mat))
            {
                return RedirectToAction("ListarMaterial");
            }

            return RedirectToAction("AlterarMaterial");

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