using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Negocio;

namespace ProjetoPeritagem.Controllers
{
    [ApiController]
    public class SituacaoAPIController : ControllerBase
    {
        [Route("api/SituacaoAPI/ListarSituacao")]
        [HttpGet]
        public List<Situacao> ListarSituacao()
        {
            SituacaoNegocio sitNeg = new SituacaoNegocio();
            return sitNeg.ListarSituacao();
        }
    }
}