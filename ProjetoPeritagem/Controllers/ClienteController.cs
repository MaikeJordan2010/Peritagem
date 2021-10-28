using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Util;
using Negocio;
using Modelo;
using ProjetoPeritagem.ViewHelper;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoPeritagem.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View("CadastrarCliente");
        }

        [HttpPost]
        public IActionResult InserirCliente(String nome, IFormFile img)
        {
            ClienteNegocio cliNeg = new ClienteNegocio();
            Cliente cliente = new Cliente();
            String caminho;
            cliente.Nome = (nome == null ? "" : nome);
            TratarImagem ti = new TratarImagem();

            caminho =  ti.GravarLogo(img);
            if(caminho != null)
            {
                cliente.Icone = caminho;
            }

            if (cliNeg.InserirCliente(cliente))
            {
                return View("ListarCliente");
            }

            return View();
        }

        public IActionResult ListarCliente()
        {
            ClienteNegocio cliNeg = new ClienteNegocio();
            ViewHelperPeritagem vwPer = new ViewHelperPeritagem();

            vwPer.listCliente = cliNeg.ListaCliente();
            vwPer.usuario = UsuarioLogado();
            return View(vwPer);
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