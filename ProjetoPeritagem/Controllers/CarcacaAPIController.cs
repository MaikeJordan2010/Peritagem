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
    //[Route("api/[controller]")]
    [ApiController]
    public class CarcacaAPIController : ControllerBase
    {

        [Route("api/CarcacaAPI/InserirCarcaca")]
        [HttpPost]
        public string InserirCarcaca([FromForm] string[] Posicao, [FromForm] string[] Medicao, [FromForm] string[] Toletancia, [FromForm] string[] DescricaoMedida, [FromForm] int ID_Peritagem, [FromForm] int Usuario_Criador,
                                     [FromForm] string Altura, [FromForm] string Largura, [FromForm] string Comprimento, [FromForm] string Descricao, [FromForm] string Peso,
                                     [FromForm] int ID_Disposicao, [FromForm] bool Jateamento, [FromForm] string Nome, [FromForm] bool Medicao_Alinhamento)
        {

            Carcaca car = new Carcaca();
            Carcaca carcaca = new Carcaca();
            ConverterGeral cGer = new ConverterGeral();
            CarcacaMedida carMed = null;
            CarcacaNegocio carNeg = new CarcacaNegocio();
            Disposicao dis = new Disposicao();
            Usuario user = new Usuario();
            int id_carcaca = 0;

          
            user.Id = Usuario_Criador;
            car.Usuario_Criador = user;
            car.ID_Peritagem = ID_Peritagem;
            car.Peso = Peso == null ? "" : Peso;
            car.Largura = Largura == null ? "" : Largura;
            car.Altura = Altura == null ? "" : Altura;
            car.Comprimento = Comprimento == null ? "" : Comprimento;
            car.Descricao = Descricao == null ? "" : Descricao;
            car.Jateamento = Jateamento;
            dis.ID_Disposicao = ID_Disposicao;
            car.Disposicao = dis;
            car.Usuario_Criador = user;
            car.Nome = Nome == null ? "" : Nome;
            car.Dt_Cadastro = DateTime.Now;
            car.MedicaoAlinhamento = Medicao_Alinhamento;

            try
            {
                if (carNeg.InserirCarcaca(car))
                {
                    carcaca = carNeg.ConsultarUltima(car);

                    if (carcaca.Id != 0)
                    {
                        int i = 0;
                        while (i < Posicao.Length)
                        {
                            carMed = new CarcacaMedida();
                            carMed.Id_Carcaca = carcaca.Id;
                            carMed.Dt_Cadastro = carcaca.Dt_Cadastro;
                            carMed.UsuarioCriador = user;
                            carMed.Posicao = Convert.ToInt32(Posicao[i]);
                            carMed.Medicao = Medicao[i];
                            carMed.Tolerancia = Toletancia[i];
                            carMed.Descricao = DescricaoMedida[i];
                            carNeg.InserirCarcacaMedida(carMed);
                            i++;
                        }
                        return "Inserido com sucesso";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return "Não foi possivel inserir";

        }

        [Route("api/CarcacaAPI/ListarCarcaca")]
        [HttpPost]
        public List<Carcaca> ListarCarcaca([FromForm]int ID_peritagem)
        {
            CarcacaNegocio carNeg = new CarcacaNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            List<Carcaca> listCarcaca = new List<Carcaca>();

            per.Id = ID_peritagem;
            listCarcaca = carNeg.ConsultarTodos(per);
            return listCarcaca;
        }


        [Route("api/CarcacaAPI/AlterarCarcaca")]
        [HttpPost]
        public String AlterarCarcaca([FromForm] int[] Posicao, [FromForm] string[] Medicao, [FromForm] string[] Tolerancia,[FromForm] string[] DescricaoMedida, [FromForm] int ID_Peritagem, 
            [FromForm] string Altura, [FromForm] string Largura, [FromForm] string Comprimento, [FromForm] bool Medicao_Alinhamento,[FromForm] int ID_Usuario_Criador,
            [FromForm] string Descricao, [FromForm] string Peso, [FromForm] int ID_Disposicao, [FromForm] bool Jateamento, [FromForm] string Nome, [FromForm] int ID_Carcaca)
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
                car.MedicaoAlinhamento = Medicao_Alinhamento;

                user.Id = ID_Usuario_Criador;
                if (carNeg.AlterarCarcaca(car))
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
                            carMed.Dt_Cadastro = DateTime.Now;

                            carNeg.InserirCarcacaMedida(carMed);

                            i++;

                        }

                    return "Alterado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return "Não foi possível alterar!";

        }

        [Route("api/CarcacaAPI/AlterarCarcacaMedida")]
        [HttpPost]
        public List<CarcacaMedida> AlterarCarcacaMedida([FromForm] int ID_CarMed, [FromForm] int ID_Carcaca, [FromForm] int Posicao, [FromForm] string Medicao, [FromForm] string Tolerancia, [FromForm] string DescricaoMedida)
        {
            Carcaca car = new Carcaca();

            CarcacaMedida carMed = null;
            CarcacaNegocio carNeg = new CarcacaNegocio();
            Disposicao dis = new Disposicao();
            Usuario user = new Usuario();
            ConverterGeral cGer = new ConverterGeral();

            car.Id = ID_Carcaca;

            try
            {

                    if (ID_Carcaca != 0)
                    {
                            carMed = new CarcacaMedida();
                            carMed.UsuarioCriador = user;
                            carMed.Posicao = Posicao;
                            carMed.Medicao = Medicao == null ? "" : Medicao;
                            carMed.Tolerancia = Tolerancia == null ? "" : Tolerancia;
                            carMed.Descricao = DescricaoMedida == null ? "" : DescricaoMedida;
                            carMed.Id = ID_CarMed;
                        if (carNeg.AlterarCarcacaMedida(carMed))
                        {
                            //return "Alterado com sucesso!";
                            return carNeg.ListarCarcacaMedida(car);
                        }

                    }
            }
            catch (Exception ex)
            {
                //return ex.Message.ToString();
            }
            //return "Não foi possível alterar!";
            return null;
        }



        [Route("api/CarcacaAPI/ExcluirCarcacaMedida")]
        [HttpPost]
        public List<CarcacaMedida> ExcluirCarcacaMedida([FromForm] int ID_CarMed, [FromForm] int ID_Carcaca)
        {

            CarcacaMedida carMed = null;
            CarcacaNegocio carNeg = new CarcacaNegocio();

            Carcaca car = new Carcaca();
            car.Id = ID_Carcaca;

            try
            {

                if (ID_Carcaca != 0)
                {
                    carMed = new CarcacaMedida();
                    carMed.Id = ID_CarMed;
                    carMed.Id_Carcaca = ID_Carcaca;
                    carNeg.ExcluirCarcacaMedida(carMed);
                }
            }
            catch (Exception ex)
            {
                //return ex.Message.ToString();
            }
            //return "Não foi possível alterar!";
            return carNeg.ListarCarcacaMedida(car);
        }


        [Route("api/CarcacaAPI/ExcluirCarcaca")]
        [HttpPost]
        public String ExcluirCarcaca([FromForm] int ID_Carcaca)
        {

            CarcacaNegocio carNeg = new CarcacaNegocio();
            Carcaca car = new Carcaca();
            car.Id = ID_Carcaca;

            if (carNeg.ExcluirCarcaca(car))
            {
                return "Excluir com Sucesso";
            }

            return "Não foi possivel excluir";

        }


    }
}