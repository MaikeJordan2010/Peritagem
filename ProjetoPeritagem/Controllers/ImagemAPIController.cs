using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Util;
using Negocio;
using Modelo;
using static System.Net.Mime.MediaTypeNames;

namespace TesteJWT.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ImagemAPIController : ControllerBase
    {

        public static IHostingEnvironment _environment;

        public ImagemAPIController(IHostingEnvironment environment)
        {
            _environment = environment;
        }


        // POST: api/PecaAPI
        [Route("api/ImagemAPI/InserirImagem")]
        [HttpPost("UploadFile")]
        public String UploadFile(IFormFile UploadFile, [FromForm] int ID_Peritagem, [FromForm] int ID_Redutor, [FromForm] int ID_Acionamento, [FromForm] int ID_ItemDiverso,
             [FromForm] int ID_Carcaca, [FromForm] int ID_Peca, [FromForm] int Usuario_Criador, [FromForm] bool Capa,  [FromForm] String Descricao, [FromForm] string Qualidade,
             [FromForm] string Latitude, [FromForm] string Longitude)
        {

            String caminho = _environment.WebRootPath;
            Modelo.Peritagem per = new Modelo.Peritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();

            RedutorNegocio redNeg = new RedutorNegocio();
            PecaNegocio pecNeg = new PecaNegocio();
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            ItemDiversoNegocio itNeg = new ItemDiversoNegocio();
            CarcacaNegocio carNeg = new CarcacaNegocio();

            Imagem img = new Imagem();
            ImagemNegocio imgNeg = new ImagemNegocio();
            TratarImagem tImg = new TratarImagem();
            String localImagem, localMiniatura;

            Usuario user = new Usuario();
            user.Id = Usuario_Criador;

            try
            {
                if (UploadFile != null && ID_Peritagem != 0)
                {
                    per.Id = ID_Peritagem;
                    per = perNeg.ConsultaUM(ID_Peritagem);

                    localImagem = tImg.GravarImagem(UploadFile, per.Cliente.Nome, per.Nfe);
                    localMiniatura = tImg.GravarMiniatura(UploadFile, per.Cliente.Nome, per.Nfe);

                    if (localImagem != null && localMiniatura != null || localImagem != "" && localMiniatura != "")
                    {
                        img.ID_Redutor = ID_Redutor;
                        img.ID_Peca=  ID_Peca; 
                        img.ID_Peritagem = ID_Peritagem;
                        img.Path_Img = localImagem;
                        img.Qualidade = Qualidade;
                        img.Path_Miniatura = localMiniatura;
                        img.Width =  tImg.PegarWith(localImagem);
                        img.Height = tImg.PegarHeigth(localImagem);
                        img.ID_Carcaca = ID_Carcaca;
                        img.ID_Acionamento = ID_Acionamento;
                        img.ID_ItemDiverso = ID_ItemDiverso;
                        img.Usuario_Criador = user;
                        img.Descricao = Descricao == null ? "" : Descricao;
                        img.Latitude = Latitude == null ? "" : Latitude;
                        img.Longitude = Longitude == null ? "" : Longitude;
                        if(imgNeg.InserirImagem(img))
                        {
                            if (ID_Peritagem != 0 && Capa)
                            {
                                if(ID_Peca != 0)
                                {
                                    pecNeg.AlterarCapa(ID_Peca, localMiniatura);
                                }
                                else if(ID_Redutor != 0)
                                {
                                    redNeg.AlterarCapa(ID_Redutor, localMiniatura);
                                }
                                else if(ID_Acionamento != 0)
                                {
                                    aciNeg.AlterarCapa(ID_Acionamento, localMiniatura);
                                }
                                else if(ID_ItemDiverso != 0)
                                {
                                    itNeg.AlterarCapa(ID_ItemDiverso, localMiniatura);
                                }
                                else if(ID_Carcaca != 0)
                                {
                                    carNeg.AlterarCapa(ID_Carcaca, localMiniatura);
                                }
                                else
                                {
                                    perNeg.AlterarCapa(ID_Peritagem, localMiniatura);
                                }
                            }
                            
                            return "Imagem inserida com sucesso!";
                        }
                    }
                    else
                    {
                        return "erro imagem";
                    }
                }
                else
                {
                    return "Erro Arquivo";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            return "Não foi possível inserir";
        }






        // POST: api/PecaAPI
        [Route("api/ImagemAPI/AlterarCapa")]
        [HttpPost]
        public String AlterarCapa( [FromForm] int ID_Peritagem, [FromForm] int ID_Redutor, [FromForm] int ID_Acionamento, [FromForm] int ID_ItemDiverso,
                                    [FromForm] int ID_Carcaca, [FromForm] int ID_Peca, [FromForm] string CaminhoMiniatura)
        {


            PeritagemNegocio perNeg = new PeritagemNegocio();

            RedutorNegocio redNeg = new RedutorNegocio();
            PecaNegocio pecNeg = new PecaNegocio();
            AcionamentoNegocio aciNeg = new AcionamentoNegocio();
            ItemDiversoNegocio itNeg = new ItemDiversoNegocio();
            CarcacaNegocio carNeg = new CarcacaNegocio();

            bool resp = false;

            try
            {
              
                if (ID_Peca != 0)
                {
                    pecNeg.AlterarCapa(ID_Peca, CaminhoMiniatura);
                    resp = true;
                }
                else if (ID_Redutor != 0)
                {
                    redNeg.AlterarCapa(ID_Redutor, CaminhoMiniatura);
                    resp = true;
                }
                else if (ID_Acionamento != 0)
                {
                    aciNeg.AlterarCapa(ID_Acionamento, CaminhoMiniatura);
                    resp = true;
                }
                else if (ID_ItemDiverso != 0)
                {
                    itNeg.AlterarCapa(ID_ItemDiverso, CaminhoMiniatura);
                    resp = true;
                }
                else if (ID_Carcaca != 0)
                {
                    carNeg.AlterarCapa(ID_Carcaca, CaminhoMiniatura);
                    resp = true;
                }
                else
                {
                    perNeg.AlterarCapa(ID_Peritagem, CaminhoMiniatura);
                    resp = true;
                }

                if (resp)
                {
                    return "Alterado com sucesso!";
                }
                         
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            return "Não foi possível Alterar";
        }








        [Route("api/ImagemAPI/BuscarImagem")]
        [HttpPost]
        public List<Imagem> BuscarImagem([FromForm] int ID_Peritagem, [FromForm] int ID_Redutor, [FromForm] int ID_Peca, [FromForm] int ID_Carcaca, [FromForm] int ID_Acionamento, [FromForm] int ID_ItemDiverso)
        {
            //String caminho =  url;
            Imagem img = new Imagem();
            ImagemNegocio imgNeg = new ImagemNegocio();

            try
            {
                img.ID_Peca = ID_Peca;
                img.ID_Redutor = ID_Redutor;
                img.ID_Peritagem = ID_Peritagem;
                img.ID_Acionamento = ID_Acionamento;
                img.ID_Carcaca = ID_Carcaca;
                img.ID_ItemDiverso = ID_ItemDiverso;
            }
            catch( Exception ex)
            {
                //return ex.Message.ToString();
            }

           // return img.ID_Objeto.ToString();
            return imgNeg.ListarImagem(img);
        }



    }
}