using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;
using Modelo;

namespace Negocio
{
    public class ClienteNegocio
    {

        public List<Cliente> ListaCliente()
        {
            ClienteDAO cliDao = new ClienteDAO();
            return cliDao.ListaCliente();
        }


        public Boolean InserirCliente(Cliente cli)
        {
            ClienteDAO cliDao = new ClienteDAO();
            return cliDao.InserirCliente(cli);
        }


        public Cliente ConsultarUM(Cliente cli)
        {
            ClienteDAO cliDao = new ClienteDAO();
            return cliDao.ConsultarUM(cli);
        }

    }
}
