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

namespace ProjetoPeritagem.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class PecaAPIController : ControllerBase
    {

        [Route("api/PecaAPI/ListarPeca")]
        [HttpPost]
        public List<Peca> ListarPeca([FromForm] int ID_Peritagem)
        {
            List<Peca> listPeca = new List<Peca>();
            Modelo.Peritagem per = new Modelo.Peritagem();
            PecaNegocio pecNeg = new PecaNegocio();

            per.Id = ID_Peritagem;
            
            listPeca = pecNeg.Listar(per);

            return listPeca;
        }

        [Route("api/PecaAPI/InserirPeca")]
        [HttpPost]
        public String InserirPeca([FromForm] int ID_Peritagem, [FromForm] int ID_Disposicao, [FromForm] int ID_Material, [FromForm] int ID_TipoPeca ,
            [FromForm] string Descricao, [FromForm] string Altura, [FromForm] string Largura, [FromForm] string Furo, [FromForm] string Dureza, [FromForm] string TratamentoTermico,
            [FromForm] string Peso, [FromForm] string[] NumDentes, [FromForm] bool Helicoidal, [FromForm] string Sentido, [FromForm] string[] AnguloPressao,
            [FromForm] string ValorK, [FromForm] string MetodoFabricacao, [FromForm] string Especial, [FromForm] string[] AnguloHelice, [FromForm] string[] Externo,
            [FromForm] string DescricaoRetrabalho, [FromForm] string[] Medida_W, [FromForm] string[] Modulo, [FromForm] string Nome, [FromForm] string[] LarguraDente,
            [FromForm] string Desenho, [FromForm] string Produto)
        {

            PecaNegocio pecNeg = new PecaNegocio();
            ConverterGeral conGer = new ConverterGeral();

            Peca pec = new Peca();
            Material mat = new Material();
            Disposicao dis = new Disposicao();
            TipoPeca tipo = new TipoPeca();
            Peca_Dados peca_dados = null;
            int ID_Ultima = 0;

            try
            {
              

                if (ID_Peritagem != 0)
                {
                    pec.Nome = Nome == null ? "" : Nome;
                    pec.ID_Peritagem = ID_Peritagem;
                    pec.Descricao = Descricao == null ? "" : Descricao;
                    pec.Altura = Altura == null ? "" : Altura;
                    pec.Largura = Largura == null ? "" : Largura;
                    pec.Furo = Furo == null ? "" : Furo;
                    pec.Dureza = Dureza == null ? "" : Dureza;
                    pec.TratamentoTermico = TratamentoTermico == null ? "" : TratamentoTermico;
                    pec.Peso = Peso == null ? "" : Peso;
                    pec.Helicoidal = Convert.ToBoolean(Helicoidal);
                    pec.Sentido = Sentido == null ? "" : Sentido;
                    pec.ValorK = ValorK == null ? "" : ValorK;
                    pec.MetodoFabricacao = MetodoFabricacao == null ? "" : MetodoFabricacao;
                    pec.Especial = Especial == null ? "" : Especial;
                    pec.DescricaoRetrabalho = DescricaoRetrabalho == null ? "" : DescricaoRetrabalho;
                    pec.Desenho = Desenho == null ? "" : Desenho;
                    pec.Produto = Produto == null ? "" : Produto;
                    pec.Dt_Cadastro = DateTime.Now;
                    dis.ID_Disposicao = ID_Disposicao;
                    mat.Id = ID_Material;
                    tipo.Id = ID_TipoPeca;

                    pec.Material = mat;
                    pec.Disposicao = dis;
                    pec.TipoPeca = tipo;

                    //return pecNeg.inserir(pec);
                    if (pecNeg.Inserir(pec))
                    {
                        ID_Ultima = pecNeg.ConsultaUltima(pec);


                        for (int i = 0; i < NumDentes.Length; i++)
                        {
                            peca_dados = new Peca_Dados();

                            peca_dados.NumDentes = NumDentes[i] == null ? "" : NumDentes[i];
                            peca_dados.AnguloHelice = AnguloHelice[i] == null ? "" : AnguloHelice[i];
                            peca_dados.AnguloPressao = AnguloPressao[i] == null ? "" : AnguloPressao[i];
                            peca_dados.Modulo = Modulo[i] == null ? "" : Modulo[i];
                            peca_dados.Externo = Externo[i] == null ? "" : Externo[i];
                            peca_dados.LarguraDente = LarguraDente[i] == null ? "" : LarguraDente[i];
                            peca_dados.Medida_W = Medida_W[i] == null ? "" : Medida_W[i];
                            peca_dados.ID_Peca = ID_Ultima;

                            pecNeg.InserirPecaDados(peca_dados);
                        }

                        return "Inserido com Sucesso";
                    }
                }
            }
            catch (Exception ex)
            {
                return "------------"+ ex.ToString();
            }

            return ID_Peritagem.ToString();
        }

        [Route("api/PecaAPI/ExcluirPeca")]
        [HttpPost]
        public String ExcluirPeca([FromForm]int ID_Peca)
        {
            PecaNegocio pecNeg = new PecaNegocio();
            Peca pec = new Peca();

            pec.Id = ID_Peca;

            if (pecNeg.ExcluirPeca(pec))
            {
                return "Excluido com sucesso!";
            }

            return "Não foi Excluir";
        }



        [Route("api/PecaAPI/AlterarPeca")]
        [HttpPost]
        public String AlterarPeca([FromForm] int ID_Peca, [FromForm] int ID_Disposicao, [FromForm] int ID_Material, [FromForm] string[] Medida_W, [FromForm] string[] LarguraDente,
            [FromForm] string Descricao, [FromForm] string Altura, [FromForm] string Largura, [FromForm] string Furo, [FromForm] string Dureza, [FromForm] string TratamentoTermico,
            [FromForm] string Peso, [FromForm] string[] NumDentes, [FromForm] bool Helicoidal, [FromForm] string Sentido, [FromForm] string[] AnguloPressao,
            [FromForm] string ValorK, [FromForm] string MetodoFabricacao, [FromForm] string Especial, [FromForm] string[] AnguloHelice, [FromForm] string[] Externo,
            [FromForm] string DescricaoRetrabalho, [FromForm] string[] Modulo, [FromForm] string Nome, [FromForm] string Desenho, [FromForm] string Produto)
        {

            PecaNegocio pecNeg = new PecaNegocio();
            ConverterGeral conGer = new ConverterGeral();

            Peca pec = new Peca();
            Material mat = new Material();
            Disposicao dis = new Disposicao();
            Peca_Dados peca_dados = null;
            Peca_W peca_w = null;
            try
            {

                if (ID_Peca != 0)
                {
                    pec.Nome = Nome == null ? "" : Nome;
                    pec.Id= ID_Peca;
                    pec.Descricao = Descricao == null ? "" : Descricao;
                    pec.Altura = Altura == null ? "" : Altura;
                    pec.Largura = Largura == null ? "" : Largura;
                    pec.Furo = Furo == null ? "" : Furo;
                    pec.Dureza = Dureza == null ? "" : Dureza;
                    pec.TratamentoTermico = TratamentoTermico == null ? "" : TratamentoTermico;
                    pec.Peso = Peso == null ? "" : Peso;
                    pec.Helicoidal = Convert.ToBoolean(Helicoidal);
                    pec.Sentido = Sentido == null ? "" : Sentido;
                    pec.ValorK = ValorK == null ? "" : ValorK;
                    pec.MetodoFabricacao = MetodoFabricacao == null ? "" : MetodoFabricacao;
                    pec.Especial = Especial == null ? "" : Especial;
                    pec.DescricaoRetrabalho = DescricaoRetrabalho == null ? "" : DescricaoRetrabalho;
                    pec.Desenho = Desenho == null ? "" : Desenho;
                    pec.Produto = Produto == null ? "" : Produto;

                    dis.ID_Disposicao = ID_Disposicao;
                    mat.Id = ID_Material;

                    pec.Material = mat;
                    pec.Disposicao = dis;

                    if (pecNeg.AlterarPeca(pec) == true)
                    {

                        for (int i = 0; i < NumDentes.Length; i++)
                        {
                            peca_dados = new Peca_Dados();

                            peca_dados.NumDentes = NumDentes[i] == null ? "" : NumDentes[i];
                            peca_dados.AnguloHelice = AnguloHelice[i] == null ? "" : AnguloHelice[i];
                            peca_dados.AnguloPressao = AnguloPressao[i] == null ? "" : AnguloPressao[i];
                            peca_dados.Modulo = Modulo[i] == null ? "" : Modulo[i];
                            peca_dados.Externo = Externo[i] == null ? "" : Externo[i];
                            peca_dados.LarguraDente = LarguraDente[i] == null ? "" : LarguraDente[i];
                            peca_dados.Medida_W = Medida_W[i] == null ? "" : Medida_W[i];
                            peca_dados.ID_Peca = ID_Peca;

                            pecNeg.InserirPecaDados(peca_dados);
                        }

                        return "Alterado com Sucesso";
                    }
                }
            }
            catch (Exception ex)
            {
                return "------------" + ex.ToString();
            }

            return "Não foi possivel alterar";
        }





        [Route("api/PecaAPI/AlterarPecaDados")]
        [HttpPost]
        public List<Peca_Dados> AlterarPecaDados([FromForm] int Id, [FromForm] string AnguloHelice, [FromForm] string Externo, [FromForm] string Medida_W, [FromForm] string LarguraDente,
                                        [FromForm] string AnguloPressao, [FromForm] string NumDentes, [FromForm] string Modulo, [FromForm] int ID_Peca)
        {

            PecaNegocio pecNeg = new PecaNegocio();

            Peca_Dados d = new Peca_Dados();

            try
            {

                if (Id != 0)
                {
                    d.Id = Id;
                    d.AnguloHelice = AnguloHelice == null ? "" : AnguloHelice;
                    d.AnguloPressao = AnguloPressao == null ? "" : AnguloPressao;
                    d.Modulo = Modulo == null ? "" : Modulo;
                    d.LarguraDente = LarguraDente == null ? "" : LarguraDente;
                    d.Externo = Externo == null ? "" : Externo;
                    d.NumDentes = NumDentes == null ? "" : NumDentes;
                    d.Medida_W = Medida_W == null ? "" : Medida_W;
                    d.ID_Peca = ID_Peca;

                    pecNeg.AlterarPecaDados(d);

                }
            }
            catch (Exception ex)
            {
                //return "------------" + ex.ToString();
            }

            return pecNeg.ListarPecaDados(ID_Peca);

        }


        [Route("api/PecaAPI/ExcluirPecaDados")]
        [HttpPost]
        public List<Peca_Dados> ExcluirPecaDados([FromForm] int Id, [FromForm] int ID_Peca)
        {

            PecaNegocio pecNeg = new PecaNegocio();

            Peca_Dados d = new Peca_Dados();

            try
            {

                if (Id != 0)
                {
                    d.Id = Id;

                    if (pecNeg.ExcluirPecaDados(d))
                    {
                        return pecNeg.ListarPecaDados(ID_Peca);
                    }
                }
            }
            catch (Exception ex)
            {
               // return "------------" + ex.ToString();
            }

            return null;

        }



        [Route("api/PecaAPI/ListarPecaDados")]
        [HttpPost]
        public List<Peca_Dados> ListarPecaDados([FromForm] int ID_Peca)
        {

            PecaNegocio pecNeg = new PecaNegocio();

           return pecNeg.ListarPecaDados(ID_Peca);
          
        }

    }
}
