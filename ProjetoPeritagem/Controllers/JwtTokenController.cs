using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelo;

namespace TesteJWT.Controllers
{
    [Route("api/[controller]")]
    public class JwtTokenController : Controller
    {
        private readonly IConfiguration _configuration;

        public JwtTokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet("{Username}/{Password}")]
        public ActionResult RequestToken(String Username, String Password)
        {
            /*
            Usuario request = new Usuario();
            request.SetUsername(Username);
            request.SetPassword(Password);

            if(request.GetUsername() == "Maike" && request.GetPassword() == "sempre")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.GetUsername()),
                    new Claim(ClaimTypes.Role, "admin"),
                };

                var key = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

                var Issuer = Convert.ToString(_configuration["JWT:Issuer"]);

                var Audience = Convert.ToString(_configuration["JWT:Audience"]);

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        issuer: Issuer,
                        audience: Audience,
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials:creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            else
            {
                return BadRequest("Credenciais Inválidas");
            }
            */
            return View();
        }
    }
}