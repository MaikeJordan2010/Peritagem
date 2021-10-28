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
    
    [ApiController]
    public class CroquiAPIController : ControllerBase
    {

        [Route("api/CroquiAPI/ListarCroqui")]
        [HttpPost]
        public List<Croqui> ListarCroqui([FromForm] int ID_Peritagem, [FromForm] int ID_Peca, [FromForm] int ID_Carcaca )
        {
            Croqui cro = new Croqui();
            CroquiNegocio croNeg = new CroquiNegocio();
            PeritagemNegocio perNeg = new PeritagemNegocio();

            cro.ID_Peritagem = ID_Peritagem;
            cro.ID_Peca = ID_Peca;
            cro.ID_Carcaca = ID_Carcaca;

            return croNeg.ListarCroqui(cro);
        }


        [Route("api/CroquiAPI/InserirCroqui")]
        [HttpPost("UploadFile")]
        public String InserirCroqui(IFormFile UploadFile, [FromForm] int ID_Peritagem,[FromForm] int ID_Carcaca, [FromForm] int ID_Peca, [FromForm] string Qualidade,
                                            [FromForm] int Usuario_Criador,  [FromForm] String Descricao,  [FromForm] string Latitude, [FromForm] string Longitude)
        {
            TratarImagem tImg = new TratarImagem();
            Modelo.Peritagem per = new Modelo.Peritagem();
            Croqui cro = new Croqui();
            CroquiNegocio croNeg = new CroquiNegocio();

            Usuario user = new Usuario();
            user.Id = Usuario_Criador;

            PeritagemNegocio perNeg = new PeritagemNegocio();
            per.Id = ID_Peritagem;

            per = perNeg.ConsultaUM(ID_Peritagem);

            if (per != null)
            {
                    cro.Path_Img = tImg.GravarCroqui(UploadFile, ID_Peca, ID_Carcaca, per.Id, per.Nfe);
                    cro.Width = tImg.PegarWith(cro.Path_Img);
                    cro.Height = tImg.PegarHeigth(cro.Path_Img);
                    cro.Qualidade = Qualidade;
                    cro.ID_Peritagem = ID_Peritagem;
                    cro.ID_Peca = ID_Peca;
                    cro.ID_Carcaca = ID_Carcaca;
                    cro.Descricao = Descricao == null ? "" : Descricao;
                    cro.Latitude = Latitude;
                    cro.Longitude = Longitude;
                    cro.Usuario_Criador = user;

                if (croNeg.InserirCroqui(cro))
                {
                    return "Inserido com sucesso!";
                }
               
            }
            return "Não foi possivel Inserir";

        }

       

    }
}