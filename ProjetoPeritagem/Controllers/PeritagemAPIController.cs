using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Util;
using Negocio;
using ProjetoPeritagem.ViewHelper;
using Modelo;
namespace ProjetoPeritagem.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    ///[Authorize]
    public class PeritagemAPIController : ControllerBase
    {

        public static IHostingEnvironment _environment;

        public PeritagemAPIController(IHostingEnvironment environment)
        {
            _environment = environment;
        }


        [Route("api/PeritagemAPI/ListarPeritagem")]
        [HttpPost]
        public ViewHelperPeritagem ListarPeritagem([FromForm] int page, [FromForm] int NFE, [FromForm] int ID_Cliente, [FromForm] int ID_Situacao, [FromForm] string NomeEquipamento)
        {
            PeritagemNegocio perNeg = new PeritagemNegocio();
            ViewHelperPeritagem vwper = new ViewHelperPeritagem();

            vwper.listPeritagem =  perNeg.ConsultarTodos(page, 5, NFE, ID_Cliente, ID_Situacao, NomeEquipamento);
            vwper.quantidade = perNeg.QuantidadePeritagem();
            vwper.page = page;

            int qt = vwper.quantidade;
            float totalPg = (float) qt / 5;
            vwper.pages = Convert.ToInt32(Math.Ceiling(totalPg));

            return vwper;
        }


        [Route("api/PeritagemAPI/CadastrarPeritagem")]
        [HttpPost]
        public string CadastrarPeritagem([FromForm] string DT_Chegada,[FromForm] string DT_Entrada, [FromForm] string DT_Previsao, [FromForm] string Nome, [FromForm] string NumeroContrato,
                                          [FromForm] string NumeroOrcamento, [FromForm] string Produto, [FromForm] string Protocolo, [FromForm] string Referencia, [FromForm] string Motivo_Manutencao,
                                          [FromForm] int NumeroNota, [FromForm] String Observacao, [FromForm] string Aplicacao, [FromForm] int ID_Cliente, [FromForm] int Usuario_Criador)
        {

            Modelo.Peritagem per = new Modelo.Peritagem();
            Cliente cli = new Cliente();
            PeritagemNegocio perNeg = new PeritagemNegocio();
            Usuario user = new Usuario();

            user.Id = Usuario_Criador;
            try
            {
                if (ID_Cliente != 0 && NumeroNota != 0 && DT_Chegada != null)
                {
                    per.Nome = Nome;
                    cli.Id = ID_Cliente;
                    per.Cliente = cli;
                    per.Dt_Chegada = Convert.ToDateTime(DT_Chegada);
                    per.Dt_Inicio = Convert.ToDateTime(DT_Entrada);
                    per.Dt_Previsao = Convert.ToDateTime(DT_Previsao);
                    per.Dt_Cadastro = DateTime.Now;
                    per.Nfe = NumeroNota;
                    per.NumeroContrato = NumeroContrato == null ? 0 : Convert.ToInt32(NumeroContrato);
                    per.ID_Orcamento = NumeroOrcamento == null ? 0 :  Convert.ToInt32(NumeroOrcamento);
                    per.Protocolo = (Protocolo == null ? "" : Protocolo);
                    per.Referencia = (Referencia == null ? "" : Referencia);
                    per.MotivoManutencao = (Motivo_Manutencao == null ? "" : Motivo_Manutencao);
                    per.Aplicacao = (Aplicacao == null ? "" : Aplicacao);
                    per.Observacao = (Observacao == null ? "" : Observacao);
                    per.UsuarioCriador = user;

                    if (perNeg.ConsultarNota(per) != true)
                    {
                        if (perNeg.InserirPeritagem(per))
                        {
                            return "Inserido com Sucesso!";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }
            return "Não foi possível inserir!";
        }


        [Route("api/PeritagemAPI/GravarAlteracao")]
        [HttpPost]
        public String GravarAlteracao([FromForm] string DT_Chegada, [FromForm] string DT_Inicio, [FromForm] string DT_Previsao, [FromForm] string DT_Revisao, [FromForm] string DT_Finalizacao,
            [FromForm] string NumeroContrato, [FromForm] string NumeroOrcamento, [FromForm] string Protocolo, [FromForm] string Referencia, [FromForm]  string Motivo_Manutencao, [FromForm] string Aplicacao,
            [FromForm] string Observacao, [FromForm] string Nome, [FromForm] int ID_Peritagem)
        {
            Modelo.Peritagem per = new Modelo.Peritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();

            try
            {
                if (ID_Peritagem != 0)
                {
                    per.Dt_Chegada = Convert.ToDateTime(DT_Chegada);
                    per.Dt_Inicio = Convert.ToDateTime(DT_Inicio);
                    per.Dt_Previsao = Convert.ToDateTime(DT_Previsao);
                    per.Dt_Revisao = Convert.ToDateTime(DT_Revisao);
                    per.Dt_Finalizacao = Convert.ToDateTime(DT_Finalizacao);
                    per.NumeroContrato = NumeroContrato == null ? 0 : Convert.ToInt32(NumeroContrato);
                    per.ID_Orcamento = NumeroOrcamento == null ? 0 : Convert.ToInt32(NumeroOrcamento);
                    per.Protocolo = Protocolo == null ? "" : Protocolo;
                    per.Referencia = Referencia == null ? "" : Referencia;
                    per.Aplicacao = Aplicacao == null ? "" : Aplicacao;
                    per.MotivoManutencao = Motivo_Manutencao == null ? "" : Motivo_Manutencao;
                    per.Nome = Nome == null ? "" : Nome;
                    per.Observacao = Observacao == null ? "" : Observacao;
                    per.Id = ID_Peritagem;

                    if (perNeg.AlterarPeritagem(per))
                    {
                        return "Alterado com Sucesso!";
                    }
                }
            }catch(Exception ex)
            {
                //return ex.Message.ToString();
                return "Deu erro";
            }

            return "Não foi possível inserir!";
        }


        [Route("api/PeritagemAPI/BuscarPeritagem")]
        [HttpPost]
        public Modelo.Peritagem BuscarPeritagem([FromForm] int ID_Peritagem)
        {
            Modelo.Peritagem per = new Modelo.Peritagem();
            per.Id = Convert.ToInt32(ID_Peritagem);
            PeritagemNegocio perNeg = new PeritagemNegocio();
            try
            {
                return perNeg.ConsultaUM(ID_Peritagem);
            }
            catch(Exception ex)
            {
               
            }

            return null;
        }

    }
}