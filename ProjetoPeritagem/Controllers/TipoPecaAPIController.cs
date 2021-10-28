using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPeritagem.Models;
using Negocio;
using Modelo;

namespace ProjetoPeritagem.Controllers
{
    
    [ApiController]
    public class TipoPecaAPIController : ControllerBase
    {
        [Route("api/TipoPecaAPI/ListarTipoPeca")]
        [HttpGet]
        public List<TipoPeca> ListarTipoPeca()
        {
            TipoPecaNegocio toNeg = new TipoPecaNegocio();
            return toNeg.ListarTipoPeca();
        }

    }
}
