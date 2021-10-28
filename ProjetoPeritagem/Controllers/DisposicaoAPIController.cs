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
    //[Route("api/[controller]")]
    [ApiController]
    public class DisposicaoAPIController : ControllerBase
    {
        [Route("api/DisposicaoAPI/ListarDisposicao")]
        [HttpGet]
        public List<Disposicao> ListarDisposicao()
        {
            DisposicaoNegocio disNeg = new DisposicaoNegocio();

            return disNeg.ListaDisposicao();
        }
    }
}