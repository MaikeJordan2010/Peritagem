using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Util;
using Negocio;
using Modelo;
using ProjetoPeritagem.ViewHelper;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoPeritagem.Controllers
{
    [Authorize]
    public class ImagemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListarImagem(int ID_Peritagem, int ID_Peca, int ID_Carcaca, int ID_Acionamento,int ID_Redutor, int ID_ItemDiverso)
        {
            Imagem img = new Imagem();
            img.ID_Peritagem = ID_Peritagem;
            img.ID_Carcaca = ID_Carcaca;
            img.ID_Peca = ID_Peca;
            img.ID_Acionamento = ID_Acionamento;
            img.ID_Redutor = ID_Redutor;
            img.ID_ItemDiverso = ID_ItemDiverso;

            ImagemNegocio imgNeg = new ImagemNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();

            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.ID_Peca = ID_Peca;
            vwPer.ID_Carcaca = ID_Carcaca;
            vwPer.ID_Redutor = ID_Redutor;
            vwPer.ID_ItemDiverso = ID_ItemDiverso;
            vwPer.ID_Acionamento = ID_Acionamento;
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);

            vwPer.listImagem = imgNeg.ListarImagem(img);

            vwPer.usuario = UsuarioLogado();

            return View(vwPer);
        }


        [HttpPost]
        public IActionResult CadastrarImagem(IFormFile[] file, int ID_Peritagem, int ID_Peca, int ID_Redutor, int ID_Carcaca, int ID_Acionamento, string Descricao, bool Capa, int ID_ItemDiverso, string Latitude, string Longitude)
        {
            TratarImagem tImg = new TratarImagem();
            Modelo.Peritagem per = new Modelo.Peritagem();
            Imagem img = new Imagem();
            ImagemNegocio imgNeg = new ImagemNegocio();

            PeritagemNegocio perNeg = new PeritagemNegocio();
            per.Id = ID_Peritagem;

            per = perNeg.ConsultaUM(ID_Peritagem);

            img.Usuario_Criador = UsuarioLogado();
            
            if(per != null)
            {
                int i = 0;

                while ( i < file.Length) {
                    if (per.Cliente.Nome != null && per.Cliente.Nome != "")
                    {
                        img.Path_Img = tImg.GravarImagem(file[i], per.Cliente.Nome, per.Nfe);
                        img.Path_Miniatura = tImg.GravarMiniatura(file[i], per.Cliente.Nome, per.Nfe);
                        img.Width = tImg.PegarWith(img.Path_Img);
                        img.Height = tImg.PegarHeigth(img.Path_Img);
                        img.Qualidade = "1";
                        img.ID_Peritagem = ID_Peritagem;
                        img.ID_Peca = ID_Peca;
                        img.ID_Redutor = ID_Redutor;
                        img.ID_Acionamento = ID_Acionamento;
                        img.ID_Carcaca = ID_Carcaca;
                        img.ID_ItemDiverso = ID_ItemDiverso;
                        img.Descricao = Descricao == null ? "" : Descricao;
                        img.Latitude = Latitude == null ? "" : Latitude;
                        img.Longitude = Longitude == null ? "" : Longitude;
                        imgNeg.InserirImagem(img);
                    }

                    i++;
                }
                return RedirectToAction("ListarImagem", new { ID_Peritagem = ID_Peritagem, ID_Peca = ID_Peca, ID_Carcaca = ID_Carcaca, ID_Acionamento = ID_Acionamento, ID_Redutor = ID_Redutor, ID_ItemDiverso = ID_ItemDiverso });

            }
            return RedirectToAction("InserirImagem", new { ID_Peritagem = ID_Peritagem, ID_Peca = ID_Peca, ID_Carcaca = ID_Carcaca, ID_Acionamento = ID_Acionamento, ID_Redutor = ID_Redutor, ID_ItemDiverso = ID_ItemDiverso });

        }

        [HttpGet]
        public IActionResult InserirImagem(int ID_Peritagem, int ID_Peca, int ID_Carcaca, int ID_Acionamento, int ID_Redutor, int ID_ItemDiverso)
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
                vwPer.ID_Carcaca =  ID_Carcaca;

                vwPer.ID_Peca = ID_Peca;

                vwPer.ID_Peritagem = ID_Peritagem;

                vwPer.ID_Acionamento = ID_Acionamento;

                vwPer.ID_Redutor = ID_Redutor;

                vwPer.ID_ItemDiverso = ID_ItemDiverso;

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