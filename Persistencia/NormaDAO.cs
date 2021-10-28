using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Persistencia.Conexao;
using Modelo;

namespace Persistencia
{
    public class NormaDAO
    {
        public List<Norma> ListarNorma()
        {
            List<Norma> Lista = new List<Norma>();
            Norma nor = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from norma where ativo = 1";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        nor = new Norma();
                        nor.Id = Convert.ToInt32(result["id"]);
                        nor.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        nor.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        Lista.Add(nor);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return Lista;
        }



        public Norma ConsultarUm(int ID_Norma)
        {
            Norma nor = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from norma where id = @id";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", ID_Norma);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        nor = new Norma();
                        nor.Id = Convert.ToInt32(result["id"]);
                        nor.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        nor.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return nor;
        }



        public bool InserirNorma(Norma nor)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "insert into norma(id,nome, descricao, ativo, isDeletede)" +
                        " values(next value for sequence_norma,@nome,@descricao, 1, 0)";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@nome", nor.Nome);
                    comand.Parameters.AddWithValue("@descricao", nor.Descricao);
                    comand.ExecuteReader();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------" + ex.Message.ToString());
            }
            conn.Close();
            return false; 
        }


        public bool AlterarNorma(Norma nor)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update norma set " +
                            " nome = @nome," +
                            " descricao = @descricao " +
                        " where id = @id";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@nome", nor.Nome);
                    comand.Parameters.AddWithValue("@descricao", nor.Descricao);
                    comand.Parameters.AddWithValue("@id", nor.Id);

                    comand.ExecuteReader();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------" + ex.Message.ToString());
            }
            conn.Close();
            return false;
        }



        public bool ExcluirNorma(Norma nor)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update norma set " +
                            " ativo = 0," +
                            " isDeletede = 1 " +
                        " where id = @id";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", nor.Id);

                    comand.ExecuteReader();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------" + ex.Message.ToString());
            }
            conn.Close();
            return false;
        }

    }
}
