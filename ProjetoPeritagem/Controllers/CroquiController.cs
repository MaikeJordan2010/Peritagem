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
    public class CroquiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ListarCroqui(int ID_Peritagem, int ID_Peca, int ID_Carcaca)
        {
            Croqui cro = new Croqui();
            cro.ID_Peritagem = ID_Peritagem;
            cro.ID_Peca = ID_Peca;
            cro.ID_Carcaca = ID_Carcaca;


            CroquiNegocio croNeg = new CroquiNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();

            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.ID_Peca = ID_Peca;
            vwPer.ID_Carcaca = ID_Carcaca;
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);

            vwPer.listCroqui = croNeg.ListarCroqui(cro);

            vwPer.usuario = UsuarioLogado();

            return View(vwPer);
        }


        [HttpPost]
        public IActionResult CadastrarCroqui(IFormFile[] file, int ID_Peritagem, int ID_Peca,  int ID_Carcaca, string Descricao)
        {
            TratarImagem tImg = new TratarImagem();
            Modelo.Peritagem per = new Modelo.Peritagem();
            Croqui cro = new Croqui();
            CroquiNegocio croNeg = new CroquiNegocio();

            PeritagemNegocio perNeg = new PeritagemNegocio();
            per.Id = ID_Peritagem;

            per = perNeg.ConsultaUM(ID_Peritagem);

            cro.Usuario_Criador = UsuarioLogado();

            if (per != null)
            {
                int i = 0;

                while (i < file.Length)
                {
                    cro.Path_Img = tImg.GravarCroqui(file[i], ID_Peca, ID_Carcaca, per.Id, per.Nfe);
                    cro.Width = tImg.PegarWith(cro.Path_Img);
                    cro.Height = tImg.PegarHeigth(cro.Path_Img);
                    cro.Qualidade = "1";
                    cro.ID_Peritagem = ID_Peritagem;
                    cro.ID_Peca = ID_Peca;
                    cro.ID_Carcaca = ID_Carcaca;
                    cro.Descricao = Descricao == null ? "" : Descricao;
                    cro.Latitude = "0";
                    cro.Longitude = "0";
                    croNeg.InserirCroqui(cro);

                    i++;
                }
                return RedirectToAction("ListarCroqui", new { ID_Peritagem = ID_Peritagem, ID_Peca = ID_Peca , ID_Carcaca = ID_Carcaca});

            }
            return RedirectToAction("InserirCroqui", new { ID_Peritagem = ID_Peritagem, ID_Peca = ID_Peca, ID_Carcaca = ID_Carcaca });

        }

        [HttpGet]
        public IActionResult InserirCroqui(int ID_Peritagem, int ID_Peca, int ID_Carcaca)
        {
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            PecaNegocio pecNeg = new PecaNegocio();
            Peca pec = new Peca();
            CarcacaNegocio carNeg = new CarcacaNegocio();
            Carcaca car = new Carcaca();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();

            try
            {
                vwPer.ID_Carcaca = ID_Carcaca;

                vwPer.ID_Peca = ID_Peca;

                vwPer.ID_Peritagem = ID_Peritagem;


                vwPer.usuario = UsuarioLogado();

                vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);
            }
            catch (Exception ex)
            {

            }

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