using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Modelo;
using ProjetoPeritagem.ViewHelper;

namespace TesteJWT.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class MaterialAPIController : ControllerBase
    {

        [Route("api/MeterialAPI/ListarMaterial")]
        public List<Material> ListarMaterial()
        {
            MaterialNegocio matNeg = new MaterialNegocio();

            return matNeg.ListarMaterial();
        }

    }
}