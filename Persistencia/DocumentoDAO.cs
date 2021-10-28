using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Persistencia.Conexao;
using Modelo.Util;
using Modelo;

namespace Persistencia
{
    public class DocumentoDAO
    {
        public bool InserirDocumento(Documento doc)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "insert into documento(" +
                                                "id_documento, " +
                                                "id_peritagem," +
                                                "id_peca, " +
                                                "caminho," +
                                                "nome," +
                                                "ativo" +
                                                ")" +
                                      "values(" +
                                                "next value for sequence_documento," +
                                                " @id_peritagem," +
                                                " @id_peca," +
                                                " @caminho," +
                                                " @nome," +
                                                "1" +
                                            ") ";

            ConversorDeData cdd = new ConversorDeData();

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@caminho", doc.Caminho);
                    comand.Parameters.AddWithValue("@id_peritagem", doc.ID_Peritagem);
                    comand.Parameters.AddWithValue("@id_peca", doc.ID_Peca);
                    comand.Parameters.AddWithValue("@nome", doc.Nome);

                    comand.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception ex)
            {
                //return ex.Message.ToString();
            }

            conn.Close();
            return false;
        }


        public List<Documento> ConsultarDocumento(int ID_Peritagem, int ID_Peca)
        {
            Documento doc = null;
            List<Documento> listDoc = new List<Documento>();
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;

            String sql = "select * from documento where ativo = 1  ";

            if(ID_Peca != 0)
            {
                sql = sql + " and id_peca = @id_peca ";
            }
            else if(ID_Peritagem != 0 && ID_Peca == 0)
            {
                sql = sql + " and id_peritagem = @id_peritagem and id_peca = 0 or id_peca = null ";
            }
            else
            {
                sql = sql + " and id_peritagem = @id_peritagem and id_peca = 0 or id_peca != null ";
            }

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_peritagem", ID_Peritagem);
                    comand.Parameters.AddWithValue("@id_peca", ID_Peca);

                    result = comand.ExecuteReader();

                    while(result.Read())
                    {
                        doc = new Documento();
                        doc.Id = result["id_documento"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["id_documento"]);
                        doc.ID_Peritagem = result["id_peritagem"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["id_peritagem"]);
                        doc.ID_Peca = result["id_peca"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["id_peca"]);
                        doc.Caminho = (result["caminho"].Equals(DBNull.Value) ? "" : result["caminho"].ToString());
                        doc.Nome = (result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString());

                        listDoc.Add(doc);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            conn.Close();
            return listDoc;
        }



        public bool ExcluirDocumento(Documento doc)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update documento set " +
                                        " ativo = 0," +
                                        " isDeletede = 1 " +
                                " Where id_documento = @id_documento ";
                                                


            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_documento", doc.Id);

                    comand.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception ex)
            {
                //return ex.Message.ToString();
            }

            conn.Close();
            return false;
        }


    }
}
