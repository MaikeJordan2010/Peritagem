using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Modelo;

namespace ProjetoPeritagem.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class TipoItemAPIController : ControllerBase
    {
        [Route("api/TipoItemAPI/ListarTipoItem")]
        [HttpGet]
        public List<TipoItem> ListaTipoObjeto()
        {
            TipoItemNegocio toNeg = new TipoItemNegocio();
            return toNeg.ListaTipoItem();
        }

    }
}