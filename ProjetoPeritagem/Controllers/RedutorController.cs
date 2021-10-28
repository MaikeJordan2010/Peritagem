using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Modelo;
using ProjetoPeritagem.ViewHelper;
using Modelo.Util;

namespace ProjetoPeritagem.Controllers
{
    [Authorize]
    public class RedutorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InserirRedutor(int ID_Peritagem)
        {

            PeritagemNegocio perNeg = new PeritagemNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            Modelo.Peritagem per = new Modelo.Peritagem();
            RedutorNegocio redNeg = new RedutorNegocio();

            per.Id = ID_Peritagem;

            vwPer.peritagem= perNeg.ConsultaUM(ID_Peritagem);
            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.usuario = UsuarioLogado();
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);

            if (redNeg.ValidarExistencia(ID_Peritagem))
            {
                ViewData["msg"] = "Já existe um acionamento cadastrado!";
            }

                return View(vwPer);
        }

        [HttpGet]
        public IActionResult AlterarRedutor(int ID_Peritagem, int ID_Redutor)
        {

            PeritagemNegocio perNeg = new PeritagemNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            Modelo.Peritagem per = new Modelo.Peritagem();
            RedutorNegocio redNeg = new RedutorNegocio();
            Redutor red = new Redutor();
            red.Id = ID_Redutor;
            per.Id = ID_Peritagem;

            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);
            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.usuario = UsuarioLogado();
            vwPer.Redutor = redNeg.ConsultaUm(red);



            return View(vwPer);
        }

        [HttpGet]
        public IActionResult ExcluirRedutor(int ID_Peritagem, int ID_Redutor)
        {

            
            RedutorNegocio redNeg = new RedutorNegocio();
            Redutor red = new Redutor();
            red.Id = ID_Redutor;

            redNeg.ExcluirRedutor(red);

            return RedirectToAction("ListarRedutor", new { ID_Peritagem = ID_Peritagem });
        }


        [HttpPost]
        public IActionResult GravarAlteracao( int ID_Redutor, bool PinturaPadraoSantana, Redutor redPer, int ID_Peritagem)
        {
            RedutorNegocio redPerNeg = new RedutorNegocio();
            ConverterGeral cGer = new ConverterGeral();


            redPer.Descricao = redPer.Descricao == null ? "" : redPer.Descricao;
            redPer.Aplicacao = redPer.Aplicacao == null ? "" : redPer.Aplicacao;
            redPer.Outro = redPer.Outro == null ? "" : redPer.Outro;
            redPer.PosicaoMontagem = redPer.PosicaoMontagem == null ? "" : redPer.PosicaoMontagem;
            redPer.Desenho = redPer.Desenho == null ? "" : redPer.Desenho;
            redPer.MotivoManutencao = redPer.MotivoManutencao == null ? "" : redPer.MotivoManutencao;
            redPer.Cor = redPer.Cor == null ? "" : redPer.Cor;
            redPer.TipoDados = redPer.TipoDados == null ? "" : redPer.TipoDados;
            redPer.FatorServico = redPer.FatorServico == null ? "" : redPer.FatorServico;
            redPer.Fabricante = redPer.Fabricante == null ? "" : redPer.Fabricante;
            redPer.Viscosidade = redPer.Viscosidade == null ? "" : redPer.Viscosidade;
            redPer.Potencia = redPer.Potencia == null ? "" : redPer.Potencia;
            redPer.Lubrificacao = redPer.Lubrificacao == null ? "" : redPer.Lubrificacao;
            redPer.AnoFabricacao = redPer.AnoFabricacao == null ? "" : redPer.AnoFabricacao;
            redPer.RotacaoIN = redPer.RotacaoIN == null ? "" : redPer.RotacaoIN;
            redPer.RotacaoOUT = redPer.RotacaoOUT == null ? "" : redPer.RotacaoOUT;
            redPer.PinturaPadraoSantana = PinturaPadraoSantana;

            redPer.Id = ID_Redutor;

            if (redPerNeg.AlterarRedutor(redPer))
            {
                return RedirectToAction("ListarRedutor", new { ID_Peritagem = ID_Peritagem });
            }
            return RedirectToAction("AlterarRedutor", new { ID_Peritagem = ID_Peritagem, ID_Redutor = ID_Redutor });
        }

        [HttpPost]
        public IActionResult CadastrarRedutor(Redutor redPer, bool PinturaPadraoSantana,  int ID_Peritagem )
        {
            RedutorNegocio redPerNeg = new RedutorNegocio();
            ConverterGeral cGer = new ConverterGeral();
            Modelo.Peritagem per = new Modelo.Peritagem();
            per.Id = ID_Peritagem;
            

            if (!redPerNeg.ValidarExistencia(ID_Peritagem))
            {
                redPer.DT_Cadastro = DateTime.Now;
                redPer.Descricao = redPer.Descricao == null ? "" : redPer.Descricao;
                redPer.Aplicacao = redPer.Aplicacao == null ? "" : redPer.Aplicacao;
                redPer.Outro = redPer.Outro == null ? "" : redPer.Outro;
                redPer.PosicaoMontagem = redPer.PosicaoMontagem == null ? "" : redPer.PosicaoMontagem;
                redPer.Desenho = redPer.Desenho == null ? "" : redPer.Desenho;
                redPer.MotivoManutencao = redPer.MotivoManutencao == null ? "" : redPer.MotivoManutencao;
                redPer.Cor = redPer.Cor == null ? "" : redPer.Cor;
                redPer.TipoDados = redPer.TipoDados == null ? "" : redPer.TipoDados;
                redPer.FatorServico = redPer.FatorServico == null ? "" : redPer.FatorServico;
                redPer.Fabricante = redPer.Fabricante == null ? "" : redPer.Fabricante;
                redPer.Viscosidade = redPer.Viscosidade == null ? "" : redPer.Viscosidade;
                redPer.Potencia = redPer.Potencia == null ? "" : redPer.Potencia;
                redPer.Lubrificacao = redPer.Lubrificacao == null ? "" : redPer.Lubrificacao;
                redPer.Volume = redPer.Volume == null ? "" : redPer.Volume;
                redPer.AnoFabricacao = redPer.AnoFabricacao == null ? "" : redPer.AnoFabricacao;
                redPer.RotacaoIN = redPer.RotacaoIN == null ? "" : redPer.RotacaoIN;
                redPer.RotacaoOUT = redPer.RotacaoOUT == null ? "" : redPer.RotacaoOUT;
                redPer.PinturaPadraoSantana = PinturaPadraoSantana;

                if (redPerNeg.inserirRedutor(redPer))
                {
                    return RedirectToAction("ListarRedutor", new { ID_Peritagem = ID_Peritagem });
                }
            }
            return RedirectToAction("InserirRedutor", new { ID_Peritagem = ID_Peritagem });

        }

        [HttpGet]
        public IActionResult ListarRedutor(int ID_Peritagem)
        {
            RedutorNegocio redPerNeg = new RedutorNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            per.Id = ID_Peritagem;

            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);
            vwPer.listRedutor =  redPerNeg.ConsultaTodos(per);
            vwPer.ID_Peritagem = ID_Peritagem;
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