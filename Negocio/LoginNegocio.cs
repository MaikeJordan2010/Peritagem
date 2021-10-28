using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class LoginNegocio
    {
       

        public Usuario ConsultarLogin(Usuario user)
        {

            UsuarioDAO log = new UsuarioDAO();
            Usuario usuario = new Usuario();

            try
            {
                usuario = log.ConsultarLogin(user);
                if(usuario != null)
                {
                    return usuario;
                }

            }
            catch (Exception ex)
            {

            }

            return null;
        }

    }
}
