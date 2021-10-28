using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace ProjetoPeritagem.Services
{
    public class ServiceToken
    {
        private IConfiguration _configuration;

        public String GerarToken(Usuario user)
        {

            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            try
            {

                if (user != null)        // VALIDANDO O USUARIO
                {
                    var claims = new[]                                                  // CRIANDO OS CLAIMS
                    {
                    new Claim(ClaimTypes.Name, user.Nome),                          // PASSANDO O NAME COMO CLAIM
                    new Claim(ClaimTypes.Email,user.Email),                        // PASSANDO O EMAIL COMO CLAIM
                    new Claim(ClaimTypes.Role, "Bearer"),                            // PASSANDO O PERFIL COMO ADMIN
                };

                    var key = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));     // BUSCARNDO O VALOR DE KEY NO ARQUIVO APPSETTINGS.JSON

                    var Issuer = Convert.ToString(_configuration["JWT:Issuer"]);        // BUSCARNDO O VALOR DE ISSUER NO ARQUIVO APPSETTINGS.JSON

                    var Audience = Convert.ToString(_configuration["JWT:Audience"]);    // BUSCARNDO O VALOR DE AUDIENCE NO ARQUIVO APPSETTINGS.JSON

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);// CRIPTOGRAFANDO A KEY USANDO HMACSHA256

                    var token = new JwtSecurityToken(                                   // GERANDO O TOKEN
                            issuer: Issuer,                                             // PASSANDO O ISSUER
                            audience: Audience,                                         // PASSANDO O AUDIENCE
                            claims: claims,                                             // PASSANDO O CLAIMS
                            expires: DateTime.Now.AddMinutes(60),                       // PASSANDO O TEMPO DE VALIDADE DO TOKEN
                            signingCredentials: creds                                   // PASSANDO P SINGINGCREDENTIALS

                            );

                    user.Token = (new JwtSecurityTokenHandler().WriteToken(token));    // GERANDO TOKEN E PASSANDO PARA O OBJ

                }
            }
            catch (Exception ex)
            {

            }
            return user.Token.ToString();
        }


    }
}
