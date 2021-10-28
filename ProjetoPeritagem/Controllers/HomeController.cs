using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Modelo;
using Negocio;
using ProjetoPeritagem.Models;
using ProjetoPeritagem.ViewHelper;

namespace ProjetoPeritagem.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Authorize]
        public IActionResult Index()
        {

            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();
            ClienteNegocio cliNeg = new ClienteNegocio();
            SituacaoNegocio sitNeg = new SituacaoNegocio();


            vwPer.listCliente = cliNeg.ListaCliente();
            vwPer.usuario = UsuarioLogado();
            vwPer.listSituacao = sitNeg.ListarSituacao();
            //ViewData["Usuario"] = HttpContext.Session.GetString("email");


            return View(vwPer);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Buscar(int NumeroNota, int ID_Cliente, int ID_Situacao, string NomeEquipamento)
        {

            return RedirectToAction("ListarPeritagem", "Peritagem", new { NFE = NumeroNota, ID_Cliente = ID_Cliente, ID_Situacao = ID_Situacao, NomeEquipamento = NomeEquipamento });

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult CadastrarPeritagem()
        {
            return View();
        }


        public Usuario UsuarioLogado()
        {
            Usuario user = new Usuario();

            user.Id = Convert.ToInt32(HttpContext.Session.GetString("id"));
            user.Nome = HttpContext.Session.GetString("nome");
            user.Email = HttpContext.Session.GetString("email");

            return user;
        }

    }
}
