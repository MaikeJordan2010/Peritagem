using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modelo;
using Negocio;
using System.Net;
using ProjetoPeritagem.ViewHelper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Caching.Memory;

namespace ProjetoPeritagem.Controllers
{
    public class LoginController : Controller
    {

        public IConfiguration configuration;

        public LoginController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Logar(String Email, String Senha)
        {

            LoginNegocio logNeg = new LoginNegocio();
            Usuario usuario = new Usuario();
            Usuario user = new Usuario();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            PeritagemNegocio perNeg = new PeritagemNegocio();

            user.Email = Email;
            user.Password = Senha;

            usuario = logNeg.ConsultarLogin(user);

            try
            {
                if (usuario != null)
                {

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, usuario.Nome),
                    };

                    var usuarioIdentidade = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentidade);

                    var authProperties = new AuthenticationProperties { };
                    

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                        new ClaimsPrincipal(principal),
                                                        authProperties);

                        HttpContext.Session.SetString("nome", usuario.Nome);
                        HttpContext.Session.SetString("email", usuario.Email.ToString());
                        HttpContext.Session.SetString("id", usuario.Id.ToString());
                        //ViewData["usuarioLogado"] = usuario.Email.ToString();
                        //ViewBag.Usuario = usuario.Email.ToString();
                    CookieOptions cookie = new CookieOptions();

                    cookie.Expires = DateTime.Now.AddHours(1);
                    cookie.HttpOnly = true;
                    cookie.Secure = true;

                    Response.Cookies.Append("usuario_logado", "Sim", cookie);


                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    String msg = "Usuário ou Senha inválidos!";
                    ViewData["msg"] = msg;
                }

            }
            catch (Exception ex)
            {

            }
            return View("Index");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            HttpContext.Session.Remove("nome");
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("id");

            return View("Index", "Login");
        }


    }
}