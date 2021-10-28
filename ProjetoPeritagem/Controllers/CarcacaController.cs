using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Modelo;
using ProjetoPeritagem.ViewHelper;
using Modelo.Util;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoPeritagem.Controllers
{
    [Authorize]
    public class CarcacaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult InserirCarcaca(int ID_Peritagem)
        {

            DisposicaoNegocio disNeg = new DisposicaoNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            Modelo.Peritagem per = new Modelo.Peritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            per.Id = ID_Peritagem;

            vwPer.listDisposicao = disNeg.ListaDisposicao();
            vwPer.peritagem = per;
            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.usuario = UsuarioLogado();
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);

            return View(vwPer);
        }

        [HttpGet]
        public IActionResult ExcluirCarcaca(int ID_Peritagem, int ID_Carcaca)
        {

            CarcacaNegocio carNeg = new CarcacaNegocio();
            Carcaca car = new Carcaca();
            car.Id = ID_Carcaca;
            
            carNeg.ExcluirCarcaca(car);

            return RedirectToAction("ListarCarcaca", new { ID_Peritagem = ID_Peritagem });

        }

        [HttpPost]
        public IActionResult CadastrarCarcaca(int[] Posicao, string[] Medicao, string[] Tolerancia,string[] DescricaoMedida, int ID_Peritagem, string Altura,
            string Largura, string Comprimento, string Descricao, string Peso, int ID_Disposicao, bool Jateamento, string Nome)
        {

            Carcaca car = new Carcaca();
            Carcaca carcaca = new Carcaca();
            ConverterGeral cGer = new ConverterGeral();
            CarcacaMedida carMed = null;
            CarcacaNegocio carNeg = new CarcacaNegocio();
            Disposicao dis = new Disposicao();
            Usuario user = new Usuario();
            int id_carcaca = 0;

            try
            {
                user.Id = Convert.ToInt32(HttpContext.Session.GetString("id"));

                car.ID_Peritagem = ID_Peritagem;
                car.Peso = Peso == null ? "" : Peso;
                car.Largura = Largura == null ? "" : Largura;
                car.Altura = Altura == null ? ""  : Altura;
                car.Comprimento = Comprimento == null ? "" : Comprimento;
                car.Descricao = Descricao == null ? "" : Descricao;
                car.Jateamento = Jateamento;
                dis.ID_Disposicao = ID_Disposicao;
                car.Disposicao = dis;
                car.Usuario_Criador = user;
                car.Nome = Nome == null ? "" : Nome;
                car.Dt_Cadastro = DateTime.Now;

                if (carNeg.InserirCarcaca(car))
                {
                    carcaca = carNeg.ConsultarUltima(car);

                    if (carcaca.Id != 0)
                    {
                        int i = 0;
                        while( i < Posicao.Length)
                        {
                            carMed = new CarcacaMedida();
                            carMed.Id_Carcaca = carcaca.Id;
                            carMed.Dt_Cadastro = carcaca.Dt_Cadastro;
                            carMed.UsuarioCriador = user;
                            carMed.Posicao = Posicao[i];
                            carMed.Medicao = Medicao[i];
                            carMed.Tolerancia = Tolerancia[i];
                            carMed.Descricao = DescricaoMedida[i];

                            carNeg.InserirCarcacaMedida(carMed);
                            i++;
                        }

                        return RedirectToAction("ListarCarcaca", new { ID_Peritagem = ID_Peritagem});
                    }
                }
            }
            catch (Exception ex)
            {
                //return ex.Message.ToString();
            }

            return RedirectToAction("InserirCarcaca", new { ID_Peritagem = ID_Peritagem });

        }


        public IActionResult ListarCarcaca(int ID_peritagem)
        {
            CarcacaNegocio carNeg = new CarcacaNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            Modelo.Peritagem per = new Modelo.Peritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();

            per.Id = ID_peritagem;
            vwPer.peritagem = per;
            vwPer.listCarcaca = carNeg.ConsultarTodos(per);
            vwPer.ID_Peritagem = ID_peritagem;
            vwPer.usuario = UsuarioLogado();
            vwPer.peritagem = perNeg.ConsultaUM(ID_peritagem);
            return View(vwPer);
        }


        public IActionResult AlterarCarcaca(int ID_Carcaca, int ID_Peritagem)
        {
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            DisposicaoNegocio disNeg = new DisposicaoNegocio();
            CarcacaNegocio AciNeg = new CarcacaNegocio();
            PeritagemNegocio perNeg = new PeritagemNegocio();

            Carcaca car = new Carcaca();
            car.Id = ID_Carcaca;
            vwPer.carcaca = AciNeg.ConsultarUm(car);
            vwPer.listDisposicao = disNeg.ListaDisposicao();
            vwPer.ID_Peritagem = ID_Peritagem;
            vwPer.usuario = UsuarioLogado();
            vwPer.peritagem = perNeg.ConsultaUM(ID_Peritagem);
            return View(vwPer);
        }



        [HttpPost]
        public IActionResult GravarAlteracao(string[] DescricaoMedida, int[] Posicao, string[] Medicao, string[] Tolerancia, int[] ID_CarMed, int ID_Peritagem, string Altura,
                            string Largura, string Comprimento, string Descricao, string Peso, int ID_Disposicao, bool Jateamento, string Nome, int ID_Carcaca)
        {
            Carcaca car = new Carcaca();

            CarcacaMedida carMed = null;
            CarcacaNegocio carNeg = new CarcacaNegocio();
            Disposicao dis = new Disposicao();
            Usuario user = new Usuario();
            ConverterGeral cGer = new ConverterGeral();

            try
            {

                car.ID_Peritagem = ID_Peritagem;
                car.Peso = Peso == null ? "" : Peso;
                car.Largura = Largura == null ? "" : Largura;
                car.Altura = Altura == null ? "" : Altura;
                car.Comprimento = Comprimento == null ? "" : Comprimento;
                car.Descricao = Descricao == null ? "" : Descricao;
                car.Jateamento = Jateamento;
                dis.ID_Disposicao = ID_Disposicao;
                car.Disposicao = dis;
                car.Nome = Nome == null ? "" : Nome;
                car.Id = ID_Carcaca;

                if (carNeg.AlterarCarcaca(car))
                {
                    if (ID_Carcaca != 0)
                    {
                        int i = 0;
                        while (i < Posicao.Length)
                        {

                            carMed = new CarcacaMedida();
                            carMed.Id_Carcaca = ID_Carcaca;
                            carMed.UsuarioCriador = user;
                            carMed.Posicao = Posicao[i];
                            carMed.Medicao = Medicao[i];
                            carMed.Tolerancia = Tolerancia[i];
                            carMed.Descricao = DescricaoMedida[i];
                            carMed.Id = ID_CarMed[i];
                            carMed.Dt_Cadastro = DateTime.Now;

                            if (ID_CarMed[i] != 0)
                            {
                                carNeg.AlterarCarcacaMedida(carMed);
                            }
                            else
                            {
                                carNeg.InserirCarcacaMedida(carMed);
                            }

                            i++;

                        }

                        return RedirectToAction("ListarCarcaca", new { ID_Peritagem = ID_Peritagem });
                    }
                }
            }
            catch (Exception ex)
            {
                //return ex.Message.ToString();
            }

            return RedirectToAction("AlterarCarcaca", new {ID_Carcaca = ID_Carcaca, ID_Peritagem = ID_Peritagem });

        }



        [HttpGet]
        public IActionResult ExcluirCarcacaMedida(int ID_CarMed, int ID_Carcaca, int ID_Peritagem)
        {

            CarcacaMedida carMed = null;
            CarcacaNegocio carNeg = new CarcacaNegocio();

            Carcaca car = new Carcaca();
            car.Id = ID_Carcaca;

                if (ID_Carcaca != 0)
                {
                    carMed = new CarcacaMedida();
                    carMed.Id = ID_CarMed;
                    carMed.Id_Carcaca = ID_Carcaca;
                    carNeg.ExcluirCarcacaMedida(carMed);
                }

            return RedirectToAction("AlterarCarcaca", new { ID_Carcaca = ID_Carcaca, ID_Peritagem = ID_Peritagem });
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