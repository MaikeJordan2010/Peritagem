using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Persistencia.Conexao;
using Modelo;

namespace Persistencia
{
    public class MaterialDAO
    {

        public List<Material> ListarMaterial()
        {
            List<Material> Lista = new List<Material>();
            Material mat = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from material where ativo = 1";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        mat = new Material();
                        mat.Id = Convert.ToInt32(result["id"]);
                        mat.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        mat.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        Lista.Add(mat);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return Lista;
        }




        public Material ConsultarUM(int ID_Material)
        {
            Material mat = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from material where id = @id and ativo = 1";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", ID_Material);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        mat = new Material();
                        mat.Id = Convert.ToInt32(result["id"]);
                        mat.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        mat.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return mat;
        }



        public bool InserirMaterial(Material mat)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "insert into material(id,nome,descricao, ativo, isDeletede) " +
                        " values(next value for sequence_material, @nome, @descricao, 1, 0) ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@nome", mat.Nome);
                    comand.Parameters.AddWithValue("@descricao", mat.Descricao);

                    comand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------" + ex.Message.ToString());
            }
            conn.Close();

            return false;
        }


        public bool AlterarMaterial(Material mat)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update material set" +
                            " nome = @nome," +
                            " descricao = @descricao " +
                        " where id = @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@nome", mat.Nome);
                    comand.Parameters.AddWithValue("@descricao", mat.Descricao);
                    comand.Parameters.AddWithValue("@id", mat.Id);

                    comand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------" + ex.Message.ToString());
            }
            conn.Close();

            return false;
        }



        public bool ExcluirMaterial(Material mat)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update material set" +
                            " ativo = 0," +
                            " isDeletede = 1 " +
                        " where id = @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", mat.Id);

                    comand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------" + ex.Message.ToString());
            }
            conn.Close();

            return false;
        }

    }
}
