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

namespace Peritagem.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AcionamentoAPIController : ControllerBase
    {
        [HttpPost]
        [Route("api/AcionamentoAPI/InserirAcionamento")]
        public string InserirAcionamento([FromForm]string Tipo_Acionamento, [FromForm] string Fabricante, [FromForm]string Modelo, [FromForm] string Rotacao_Polos, [FromForm]string Nome,
                                         [FromForm] string Potencia, [FromForm] string Descricao, [FromForm]string Carcaca, [FromForm]int ID_Disposicao, [FromForm] int ID_Peritagem,
                                         [FromForm] bool Teste_Redutor, [FromForm] string Tipo_Teste, [FromForm] string Inspecao_Visual, [FromForm] string Observacao_Teste)
        {
            try
            {
                Acionamento aci = new Acionamento();
                Disposicao dis = new Disposicao();
                AcionamentoNegocio aciNeg = new AcionamentoNegocio();
                Modelo.Peritagem per = new Modelo.Peritagem();

                if (!aciNeg.ValidarExistencia(ID_Peritagem))
                {

                    aci.Nome = Nome == null ? "" : Nome;
                    aci.TipoAcionamento = Tipo_Acionamento == null ? "" : Tipo_Acionamento;
                    aci.Fabricante = Fabricante == null ? "" : Fabricante;
                    aci.Modelo = Modelo == null ? "" : Modelo;
                    aci.Descricao = Descricao == null ? "" : Descricao;
                    aci.Carcaca = Carcaca == null ? "" : Carcaca;
                    aci.ID_Peritagem = ID_Peritagem;
                    aci.Teste = Teste_Redutor;
                    aci.TipoTeste = Tipo_Teste == null ? "" : Tipo_Teste;
                    aci.InspecaoVisual = Inspecao_Visual == null ? "" : Inspecao_Visual;
                    dis.ID_Disposicao = ID_Disposicao;
                    aci.Disposicao = dis;
                    aci.Potencia = Potencia == null ? "" : Potencia;
                    aci.RotacaoPolos = Rotacao_Polos == null ? "" : Rotacao_Polos;
 
                    if (ID_Peritagem != 0)
                    {
                        if (aciNeg.InserirAcionamento(aci))
                        {
                            return "Inserido!"; ;
                        }
                    }
                }
                else
                {
                    return "Verificamos que já existe um acionamento cadastrado para essa peritagem!";
                }
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
            return "Não inserido!";
        }


        [Route("api/AcionamentoAPI/ConsultarAcionamento")]
        [HttpPost]
        public List<Acionamento> ConsultarAcionamento([FromForm] int ID_Peritagem)
        {
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            Acionamento aci = new Acionamento();
            List<Acionamento> listAcionamento = new List<Acionamento>();
            per.Id = ID_Peritagem;

            aci = aciNeg.ConsultarAcionamento(per);

            listAcionamento.Add(aci);
            return listAcionamento;
        }

        [Route("api/AcionamentoAPI/GravarAlteracao")]
        [HttpPost]
        public string GravarAlteracao([FromForm] string Tipo_Acionamento, [FromForm] string Fabricante, [FromForm] string Modelo, [FromForm] string Rotacao_Polos, [FromForm] string Potencia,
                                            [FromForm] string Descricao, [FromForm] string Carcaca, [FromForm] int ID_Disposicao, [FromForm] int ID_Peritagem, [FromForm] bool Teste_Redutor,
                                            [FromForm] string Tipo_Teste, [FromForm] string Inspecao_Visual, [FromForm] int ID_Acionamento, [FromForm] string Nome, [FromForm]  string Descricao_Teste)
        {
            Acionamento aci = new Acionamento();
            Disposicao dis = new Disposicao();
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            Modelo.Peritagem per = new Modelo.Peritagem();
            ConverterGeral cGer = new ConverterGeral();


            try{
                aci.TipoAcionamento = Tipo_Acionamento == null ? "" : Tipo_Acionamento;
                aci.Fabricante = Fabricante == null ? "" : Fabricante;
                aci.Modelo = Modelo == null ? "" : Modelo;
                aci.Descricao = Descricao == null ? "" : Descricao;
                aci.Carcaca = Carcaca == null ? "" : Carcaca;
                aci.ID_Peritagem = ID_Peritagem;
                aci.Teste = Teste_Redutor;
                aci.TipoTeste = Tipo_Teste == null ? "" : Tipo_Teste;
                aci.InspecaoVisual = Inspecao_Visual == null ? "" : Inspecao_Visual;
                dis.ID_Disposicao = ID_Disposicao;
                aci.Disposicao = dis;
                aci.Potencia = Potencia == null ? "" : Potencia;
                aci.RotacaoPolos = Rotacao_Polos == null ? "" : Rotacao_Polos;
                aci.ID_Peritagem = ID_Peritagem;
                aci.Id = ID_Acionamento;
                aci.Nome = Nome == null ? "" : Nome;
                aci.DescricaoTeste = Descricao_Teste == null ? "" : Descricao_Teste;

                if (ID_Acionamento != 0)
                {
                    if (aciNeg.AlterarAcionamento(aci))
                    {
                        return "Inserido com sucesso";
                    }
                }
            }
            catch (Exception ex)
            {
                return (ex.Message.ToString());
            }

            return ("Não foi possível inserir");
        }

        [Route("api/AcionamentoAPI/ExcluirAcionamento")]
        [HttpPost]
        public String ExcluirAcionamento([FromForm] int ID_Acionamento)
        {
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            Acionamento aci = new Acionamento();

            aci.Id = ID_Acionamento;
            if (aciNeg.ExcluirAcionamento(aci))
            {
                return "Excluido com sucesso!";
            }

            return "Não foi possivel excluir";
        }

    }
}