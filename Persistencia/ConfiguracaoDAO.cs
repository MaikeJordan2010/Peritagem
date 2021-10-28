using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Persistencia
{
    public class ConfiguracaoDAO
    {
        public List<Configuracao> ListarConfiguracao()
        {
            List<Configuracao> Lista = new List<Configuracao>();
            Configuracao conf = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from configuracao where ativo = 1";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        conf = new Configuracao();
                        conf.Id = Convert.ToInt32(result["id"]);
                        conf.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        conf.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        conf.Protocolo = result["protocolo"].Equals(DBNull.Value) ? "" : result["protocolo"].ToString();
                        conf.Dominio = result["dominio"].Equals(DBNull.Value) ? "" : result["dominio"].ToString();
                        conf.Porta = result["porta"].Equals(DBNull.Value) ? "" : result["porta"].ToString();
                        conf.Padrao = Convert.ToBoolean(result["padrao"]);

                        Lista.Add(conf);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return Lista;
        }



        public Configuracao ConsultarUm(int ID_Configuracao)
        {
            Configuracao conf = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from configuracao where id = @id";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", ID_Configuracao);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        conf = new Configuracao();
                        conf.Id = Convert.ToInt32(result["id"]);
                        conf.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        conf.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        conf.Protocolo = result["protocolo"].Equals(DBNull.Value) ? "" : result["protocolo"].ToString();
                        conf.Dominio = result["dominio"].Equals(DBNull.Value) ? "" : result["dominio"].ToString();
                        conf.Porta = result["porta"].Equals(DBNull.Value) ? "" : result["porta"].ToString();
                        conf.Padrao = Convert.ToBoolean(result["padrao"]);

                    }
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return conf;
        }



        public bool InserirConfiguracao(Configuracao conf)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "insert into configuracao(id, nome, descricao, dominio, porta, protocolo,padrao, ativo, isDeletede)" +
                        " values(next value for sequence_configuracao, @nome, @descricao, @dominio, @porta, @protocolo,0, 1, 0)";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@nome", conf.Nome);
                    comand.Parameters.AddWithValue("@descricao", conf.Descricao);
                    comand.Parameters.AddWithValue("@dominio", conf.Dominio);
                    comand.Parameters.AddWithValue("@porta", conf.Porta);
                    comand.Parameters.AddWithValue("@protocolo", conf.Protocolo);

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


        public bool AlterarConfiguracao(Configuracao conf)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update configuracao set " +
                            " nome = @nome," +
                            " descricao = @descricao, " +
                            " dominio = @dominio, " +
                            " porta = @porta, " +
                            " protocolo = @protocolo " +
                        " where id = @id";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@nome", conf.Nome);
                    comand.Parameters.AddWithValue("@descricao", conf.Descricao);
                    comand.Parameters.AddWithValue("@dominio", conf.Dominio);
                    comand.Parameters.AddWithValue("@porta", conf.Porta);
                    comand.Parameters.AddWithValue("@protocolo", conf.Protocolo);
                    comand.Parameters.AddWithValue("@id", conf.Id);

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



        public bool ExcluirConfiguracao(Configuracao conf)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update configuracao set " +
                            " ativo = 0," +
                            " isDeletede = 1 " +
                        " where id = @id";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", conf.Id);

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


        public bool AlterarPadrao(Configuracao conf)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;

            String sql = "update configuracao set " +
                          " padrao = 1 " +
                      " where id = @id ";


            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    if (LimparPadrao())
                    {
                        comand = new SqlCommand(sql, conn);
                        comand.Parameters.AddWithValue("@id", conf.Id);

                        comand.ExecuteReader();

                        return true;
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------" + ex.Message.ToString());
            }
            conn.Close();
            return false;
        }


        public bool LimparPadrao()
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update configuracao set " +
                            " padrao = 0 " +
                        " where id > 0 ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
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

