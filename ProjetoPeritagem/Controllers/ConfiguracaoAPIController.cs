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
    public class ConfiguracaoAPIController : ControllerBase
    {
        [HttpPost]
        [Route("api/ListarConfiguracao")]
        public List<Configuracao> ListarConfiguracao()
        {
            ConfiguracaoNegocio confNeg = new ConfiguracaoNegocio();

            return confNeg.ListarConfiguracao();
        }

    }
}