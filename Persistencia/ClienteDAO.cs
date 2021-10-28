using Modelo.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Modelo;

namespace Persistencia
{
    public class ClienteDAO
    {

        public bool InserirCliente(Cliente cliente)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "insert into Cliente(id_cliente,Nome, Icone) values (next value for sequence_cliente, @nome, @icone)";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@nome", cliente.Nome);
                    comand.Parameters.AddWithValue("@icone", cliente.Icone);
                    comand.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Mensagem de Erro!");
                Console.WriteLine(ex.Message.ToString());
            }
            conn.Close();
            return false;
        }


        public List<Cliente> ListaCliente()
        {
            List<Cliente> Lista = new List<Cliente>();
            Cliente cli = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from cliente";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        cli = new Cliente();
                        cli.Id = Convert.ToInt32(result["id_cliente"]);
                        cli.Nome =result["nome"].ToString();
                        cli.Icone = result["icone"].ToString();
                        Lista.Add(cli);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return Lista;
        }


        public Cliente ConsultarUM(Cliente cliente)
        {
            Cliente cli = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            TratarImagem conImg = new TratarImagem();
            String sql = "select * from Cliente where ID_Cliente = @id";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", cliente.Id);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        cli = new Cliente();
                        cli.Id  = Convert.ToInt32(result["ID_Cliente"]);
                        cli.Nome = result["Nome"].ToString();
                        String url = result["Icone"].ToString();
                        cli.Icone = conImg.ConverterImagemBase64(url);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            conn.Close();
            return cli;
        }

    }
}
