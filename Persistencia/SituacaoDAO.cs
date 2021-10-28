using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Persistencia.Conexao;
using Modelo;

namespace Persistencia
{
    public class SituacaoDAO
    {
        public List<Situacao> ListarSituacao()
        {
            List<Situacao> Lista = new List<Situacao>();
            Situacao sit = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from Situacao ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        sit = new Situacao();
                        sit.Id = Convert.ToInt32(result["id_situacao"]);
                        sit.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        Lista.Add(sit);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return Lista;
        }



        public Situacao ConsultarUm(int ID_Classe)
        {
            Situacao sit = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from situacao where id_situacao = @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        sit = new Situacao();
                        sit.Id = Convert.ToInt32(result["id_situacao"]);
                        sit.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return sit;
        }



        public bool InserirSituacao(Situacao sit)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "insert into classe(id_situacao, descricao) values(next value for sequence_situacao, @descricao)";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@descricao", sit.Descricao);

                    comand.ExecuteReader();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return false;
        }



        public bool AlterarSituacao(Situacao sit)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update situacao set " +
                                 " descricao = @descricao " +
                          " where id = @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@descricao", sit.Descricao);
                    comand.Parameters.AddWithValue("@id", sit.Id);

                    comand.ExecuteReader();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return false;
        }





        //public bool ExcluirClasse(Classe cla)
        //{
        //    SqlConnection conn = null;
        //    SqlCommand comand = null;
        //    String sql = "update situacao set " +
        //                         " ativo = 0," +
        //                         " isDeletede = 1" +
        //                  " where id = @id ";

        //    try
        //    {
        //        conn = new Conexao.Conexao().abrirConexao();
        //        if (conn != null)
        //        {
        //            comand = new SqlCommand(sql, conn);

        //            comand.ExecuteReader();
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    conn.Close();
        //    return false;
        //}

    }
}
