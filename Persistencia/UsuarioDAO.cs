using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Modelo;

namespace Persistencia
{ 
    public class UsuarioDAO
    {
        public Usuario ConsultarLogin(Usuario user)
        {
            string sql = "select * from TB_Usuario where Login = @email and senha = @senha and ativo = 1";

            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            Usuario usuario = null;
            try
            {
            conn = new Conexao.Conexao("CPD").abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@email", user.Email);
                    comand.Parameters.AddWithValue("@senha", user.Password);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(result["ID_Usuario"]);
                        usuario.Email = result["Login"].Equals(DBNull.Value) ? "" : result["Login"].ToString();
                        usuario.Nome = result["Nome"].Equals(DBNull.Value) ? "" : result["Nome"].ToString();
                        usuario.Nome = result["Departamento"].Equals(DBNull.Value) ? "" : result["Departamento"].ToString();

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }

            return usuario;
        }


        public Usuario ConsultarUsuario(int ID_Usuario)
        {
            string sql = "select * from TB_Usuario where ID_Usuario = @id";

            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            Usuario usuario = null;
            try
            {
                conn = new Conexao.Conexao("CPD").abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", ID_Usuario);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(result["ID_Usuario"]);
                        usuario.Email = result["Login"].Equals(DBNull.Value) ? "" : result["Login"].ToString();
                        usuario.Nome = result["Nome"].Equals(DBNull.Value) ? "" : result["Nome"].ToString();
                        usuario.Nome = result["Departamento"].Equals(DBNull.Value) ? "" : result["Departamento"].ToString();
                        //usuario.Foto = result["Foto"].Equals(DBNull.Value) ? "" : result["Foto"].ToString();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }

            return usuario;
        }



    }
}
