using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Negocio;
using Modelo;
namespace ProjetoPeritagem.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class LoginAPIController : ControllerBase
    {
        // INSTANCIANDO A CONFIGURATION PARA BUSCAR AS CONFIGURAÇÕES DO ARQUIVO APPSETTINGS.JSON
        private readonly IConfiguration _configuration;

        
        //  FUNÇÃO  CONSTRUTORA RECEBENDO A CONFIGURAÇÃO
        public LoginAPIController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [Route("api/LoginAPI/Login")]                                                               // PERMITE QUE USUARIOS ANONIMOS CHAMEM A  FUNÇÃO
        [HttpPost]                                                                                  // RECEBE UM USUARIO E SENHA
        public Usuario Login([FromForm]String Username, [FromForm]String Password)                  // FUNÇÃO QUE RECEBE O USUÁRIO E SENHA PELA API E PROCESSA E DEVOLVE O TOKEN
        {

            LoginNegocio logneg = new LoginNegocio();
            Usuario usuario = new Usuario();
            Usuario request = new Usuario();                                                        // INSTANCIANDO OBJ DE USUARIO
            request.Email = Username;                                                               // PASSANDO O USERNAME PARA O OBJ
            request.Password = Password;                                                            // PASSANDO O PASSWORD PARA O OBJ

            usuario = logneg.ConsultarLogin(request);

            return usuario;
            
        }

    }
}

