using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Modelo;

namespace ProjetoPeritagem.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ClienteAPIController : ControllerBase
    {
        //[AllowAnonymous]
        //[Authorize]
        [Route("api/ClienteAPI/ListaCliente")]
        [HttpGet]
        public List<Cliente> ListaCliente()
        {
            ClienteNegocio cliNeg = new ClienteNegocio();
            return cliNeg.ListaCliente();
        }



    }
}
