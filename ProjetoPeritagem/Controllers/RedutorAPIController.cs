using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPeritagem.Models;
using Negocio;
using Microsoft.AspNetCore.Authorization;
using Modelo.Util;
using Modelo;

namespace ProjetoPeritagem.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class RedutorAPIController : ControllerBase
    {
        [Route("api/RedutorAPI/CadastrarRedutor")]
        [HttpPost]
        public string CadastrarRedutor([FromForm] string Nome,[FromForm] string Descricao, [FromForm] string Fabricante, [FromForm] string Modelo, 
            [FromForm] int ID_Peritagem, [FromForm] string RotacaoIN, [FromForm] string RotacaoOUT, [FromForm]string Reducao, [FromForm] string Potencia, 
            [FromForm] string FatorServico, [FromForm] string AnoFabricacao, [FromForm] string Lubrificacao, [FromForm] string Viscosidade, [FromForm]string Volume,
            [FromForm] string Sentido, [FromForm] string Aplicacao, [FromForm] string MotivoManutencao, [FromForm] string Peso, [FromForm] string Cor,
            [FromForm] bool PinturaPadraoSantana, [FromForm] string Outro, [FromForm] string PosicaoMontagem, [FromForm] string TipoDados,[FromForm] string Visto,
            [FromForm] string Desenho)
        {

                Redutor redPer = new Redutor();
                ConverterGeral conGer = new ConverterGeral();
                RedutorNegocio redPerNeg = new RedutorNegocio();


            try
            {
                if (ID_Peritagem != 0)
                {
                    if (!redPerNeg.ValidarExistencia(ID_Peritagem))
                    {
                        redPer.Nome = Nome == null ? "" : Nome;
                        redPer.Descricao = (Descricao == null ? "" : Descricao);
                        redPer.ID_Peritagem = ID_Peritagem;
                        redPer.Modelo = (Modelo == null ? "" : Modelo);
                        redPer.Fabricante = (Fabricante == null ? "" : Fabricante);
                        redPer.DT_Cadastro = DateTime.Now;
                        redPer.Descricao = (Descricao == null ? "" : Descricao);
                        redPer.RotacaoIN = RotacaoIN == null ? "" : RotacaoIN;
                        redPer.RotacaoOUT = RotacaoOUT == null ? "" : RotacaoOUT;
                        redPer.Reducao = Reducao == null ? "" : Reducao;
                        redPer.Potencia = Potencia == null ? "" : Potencia;
                        redPer.FatorServico = (FatorServico == null ? "" : FatorServico);
                        redPer.AnoFabricacao = AnoFabricacao == null ? "" : AnoFabricacao;
                        redPer.Lubrificacao = Lubrificacao == null ? "" : Lubrificacao;
                        redPer.Viscosidade = Viscosidade == null ? "" : Viscosidade;
                        redPer.Volume = Volume == null ? "" : Volume;
                        redPer.Sentido = (Sentido == null ? "" : Sentido);
                        redPer.Aplicacao = (Aplicacao == null ? "" : Aplicacao);
                        redPer.MotivoManutencao = (MotivoManutencao == null ? "" : MotivoManutencao);
                        redPer.Peso = Peso == null ? "" : Peso;
                        redPer.Cor = (Cor == null ? "" : Cor);
                        redPer.PinturaPadraoSantana = PinturaPadraoSantana;
                        redPer.Outro = (Outro == null ? "" : Outro);
                        redPer.PosicaoMontagem = (PosicaoMontagem == null ? "" : PosicaoMontagem);
                        redPer.TipoDados = (TipoDados == null ? "" : TipoDados);
                        redPer.Visto = (Visto == null ? "" : Visto);
                        redPer.Desenho = (Desenho == null ? "" : Desenho);
                    }
                    else
                    {
                        return "Verificamos que já existe um redutor cadastrado para essa peritagem!";
                    }
                }
            }
            catch(Exception ex)
            {
                return(ex.Message.ToString());
            }

            if (redPerNeg.inserirRedutor(redPer))
            {
                return "Inserido com sucesso!";
            }

            return "Não Inserido";
        }


        [Route("api/RedutorAPI/AlterarRedutor")]
        [HttpPost]
        public string AlterarRedutor([FromForm] string Nome, [FromForm] string Descricao, [FromForm] string Fabricante, [FromForm] string Modelo,
           [FromForm] string RotacaoIN, [FromForm] string RotacaoOUT, [FromForm]string Reducao, [FromForm] string Potencia,
           [FromForm] string FatorServico, [FromForm] string AnoFabricacao, [FromForm] string Lubrificacao, [FromForm] string Viscosidade, [FromForm]string Volume,
           [FromForm] string Sentido, [FromForm] string Aplicacao, [FromForm] string MotivoManutencao, [FromForm] string Peso, [FromForm] string Cor,
           [FromForm] bool PinturaPadraoSantana, [FromForm] string Outro, [FromForm] string PosicaoMontagem, [FromForm] string TipoDados, [FromForm] string Visto,
           [FromForm] string Desenho, [FromForm] int ID_Redutor)
        {

            Redutor redPer = new Redutor();
            ConverterGeral conGer = new ConverterGeral();
            RedutorNegocio redPerNeg = new RedutorNegocio();

            try
            {
                if (ID_Redutor != 0)
                {
                    redPer.Nome = (Nome == null ? "" : Nome);
                    redPer.Descricao = (Descricao == null ? "" : Descricao);
                    redPer.Modelo = (Modelo == null ? "" : Modelo);
                    redPer.Fabricante = (Fabricante == null ? "" : Fabricante);
                    redPer.DT_Cadastro = DateTime.Now;
                    redPer.Descricao = (Descricao == null ? "" : Descricao);
                    redPer.RotacaoIN = RotacaoIN == null ? "" : RotacaoIN;
                    redPer.RotacaoOUT = RotacaoOUT == null ? "" : RotacaoOUT;
                    redPer.Reducao = Reducao == null ? "" : Reducao;
                    redPer.Potencia = Potencia == null ? "" : Potencia;
                    redPer.FatorServico = (FatorServico == null ? "" : FatorServico);
                    redPer.AnoFabricacao = AnoFabricacao == null ? ""  : AnoFabricacao;
                    redPer.Lubrificacao = Lubrificacao == null ? "" : Lubrificacao;
                    redPer.Viscosidade = Viscosidade == null ? "" : Viscosidade;
                    redPer.Volume = Volume == null ? "" : Volume;
                    redPer.Sentido = (Sentido == null ? "" : Sentido);
                    redPer.Aplicacao = (Aplicacao == null ? "" : Aplicacao);
                    redPer.MotivoManutencao = (MotivoManutencao == null ? "" : MotivoManutencao);
                    redPer.Peso = Peso == null ? "" : Peso;
                    redPer.Cor = (Cor == null ? "" : Cor);
                    redPer.PinturaPadraoSantana = PinturaPadraoSantana;
                    redPer.Outro = (Outro == null ? "" : Outro);
                    redPer.PosicaoMontagem = (PosicaoMontagem == null ? "" : PosicaoMontagem);
                    redPer.TipoDados = TipoDados == null ? "" : TipoDados;
                    redPer.Visto = (Visto == null ? "" : Visto);
                    redPer.Desenho = (Desenho == null ? "" : Desenho);
                    redPer.Id = ID_Redutor;
                }
            }
            catch (Exception ex)
            {
                return (ex.Message.ToString());
            }

            if (redPerNeg.AlterarRedutor(redPer))
            {
                return "Inserido com sucesso!";
            }

            return "Não Inserido";
        }

        [Route("api/RedutorAPI/ExcluirRedutor")]
        [HttpGet]
        public String ExcluirRedutor([FromForm] int ID_Redutor)
        {

            RedutorNegocio redNeg = new RedutorNegocio();
            Redutor red = new Redutor();
            red.Id = ID_Redutor;

            if (redNeg.ExcluirRedutor(red))
            {
                return "Excluir com Sucesso!";
            }

            return "Não foi possivel excluir";
        }



        [Route("api/RedutorAPI/ListarRedutor")]
        [HttpPost]
        public List<Redutor> ListarRedutor([FromForm] int ID_Peritagem)
        {
            Modelo.Peritagem per = new Modelo.Peritagem();
            per.Id = Convert.ToInt32(ID_Peritagem);
            RedutorNegocio redPerNeg = new RedutorNegocio();

            return redPerNeg.ConsultaTodos(per);
            //return ID_Peritagem;
        }


        [Route("api/RedutorAPI/ConsultarUM")]
        [HttpPost]
        public Redutor ConsultarUM([FromForm] int ID_Peritagem)
        {
            Redutor red = new Redutor();
            red.ID_Peritagem = ID_Peritagem;
            RedutorNegocio redPerNeg = new RedutorNegocio();

            return redPerNeg.ConsultaUm(red);
            //return ID_Peritagem;
        }

    }
}