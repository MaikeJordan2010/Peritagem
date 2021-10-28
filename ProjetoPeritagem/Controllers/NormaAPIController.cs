using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Negocio;
using ProjetoPeritagem.ViewHelper;

namespace ProjetoPeritagem.Controllers
{
    [ApiController]
    public class NormaAPIController : ControllerBase
    {

        [Route("api/NormaAPI/ListarNorma")]
        [HttpGet]
        public List<Norma> ListarNorma()
        {
            NormaNegocio norNeg = new NormaNegocio();
            List<Norma> listNorma = new List<Norma>();
            listNorma = norNeg.ListarNorma();

            return listNorma;
        }

    }
}