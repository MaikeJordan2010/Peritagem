using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Persistencia.Conexao;
using Modelo.Util;
using Modelo;

namespace Persistencia
{
    public class AcionamentoDAO
    {

        public bool InserirAcionamento(Acionamento aci)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = "insert into acionamento(" +
                                     "id," +
                                     "nome," +
                                     "id_peritagem," +
                                     "id_disposicao," +
                                     "tipo," +
                                     "fabricante," +
                                     "modelo," +
                                     "rotacao_polos," +
                                     "potencia," +
                                     "carcaca," +
                                     "descricao," +
                                     "teste_redutor," +
                                     "tipo_teste," +
                                     "inspecao_visual," +
                                     "ativo," +
                                     "isDeletede" +

                        ") values (" +
                                     "next value for sequence_acionamento," +
                                     "@nome," +
                                     "@id_peritagem," +
                                     "@id_disposicao," +
                                     "@tipo," +
                                     "@fabricante," +
                                     "@modelo," +
                                     "@rotacao_polos," +
                                     "@potencia," +
                                     "@carcaca," +
                                     "@descricao," +
                                     "@teste_redutor," +
                                     "@tipo_teste," +
                                     "@inspecao_visual," +
                                     "1," +
                                     "0" +
                                    ") ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_peritagem", aci.ID_Peritagem);
                    comand.Parameters.AddWithValue("@id_disposicao", aci.Disposicao.ID_Disposicao);
                    comand.Parameters.AddWithValue("@tipo", aci.TipoAcionamento);
                    comand.Parameters.AddWithValue("@fabricante", aci.Fabricante);
                    comand.Parameters.AddWithValue("@modelo", aci.Modelo);
                    comand.Parameters.AddWithValue("@rotacao_polos", aci.RotacaoPolos);
                    comand.Parameters.AddWithValue("@potencia", aci.Potencia);
                    comand.Parameters.AddWithValue("@carcaca", aci.Carcaca);
                    comand.Parameters.AddWithValue("@descricao", aci.Descricao);
                    comand.Parameters.AddWithValue("@teste_redutor", aci.Teste);
                    comand.Parameters.AddWithValue("@tipo_teste", aci.TipoTeste);
                    comand.Parameters.AddWithValue("@inspecao_visual", aci.InspecaoVisual);
                    comand.Parameters.AddWithValue("@nome", aci.Nome);


                    comand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return false;
        }

        public Acionamento ConsultarAcionamento(Peritagem per)
        {
            Acionamento aci = null;
            Disposicao dis = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql ="select *, " +
                            " d.id_disposicao as d_id_disposicao, d.nome as d_nome " +
                        " from acionamento as a" +
                            " inner join disposicao as d " +
                            " on a.id_disposicao = d.id_disposicao " +
                        " where id_peritagem = @id_peritagem and ativo = 1";
                                     
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_peritagem", per.Id);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        aci = new Acionamento();
                        dis = new Disposicao();
                        aci.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        aci.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        aci.RotacaoPolos = result["rotacao_polos"].Equals(DBNull.Value) ? "" : result["rotacao_polos"].ToString();
                        aci.TipoAcionamento = result["tipo"].Equals(DBNull.Value) ? "" : result["tipo"].ToString();
                        aci.Fabricante = result["fabricante"].Equals(DBNull.Value) ? "" : result["fabricante"].ToString();
                        aci.Modelo = result["modelo"].Equals(DBNull.Value) ? "" : result["modelo"].ToString();
                        aci.Potencia = result["potencia"].Equals(DBNull.Value) ? "" : result["potencia"].ToString();
                        aci.Carcaca = result["carcaca"].Equals(DBNull.Value) ? "" : result["carcaca"].ToString();
                        aci.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        aci.Teste = result["teste_redutor"].Equals(DBNull.Value) ? false : Convert.ToBoolean(result["teste_redutor"]);
                        aci.TipoTeste = result["tipo_teste"].Equals(DBNull.Value) ? "" : result["tipo_teste"].ToString();
                        aci.InspecaoVisual = result["inspecao_visual"].Equals(DBNull.Value) ? "" : result["inspecao_visual"].ToString();
                        aci.Capa = result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();
                        aci.Id = Convert.ToInt32(result["id"]);
                        dis.ID_Disposicao = Convert.ToInt32(result["d_id_disposicao"]);
                        dis.Nome = result["d_nome"].Equals(DBNull.Value) ? "" : result["d_nome"].ToString();
                        aci.Disposicao = dis;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return aci;
        }

        public bool ValidarExistencia(int ID_Peritagem)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from acionamento where id_peritagem = @id_peritagem and ativo = 1";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_peritagem", ID_Peritagem);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return false;
        }


        public bool ExcluirAcionamento(Acionamento aci)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = " update acionamento set " +
                                     " ativo = 0, " +
                                     " isDeletede = 1 " +
                        " where id = @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", aci.Id);

                    comand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return false;
        }

        public Acionamento ConsultarUM(Acionamento acionamento)
        {
            Acionamento aci = null;
            Disposicao dis = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select *, " +
                            " d.id_disposicao as d_id_disposicao, " +
                            " d.nome as d_nome " +
                        " from acionamento as a" +
                            " inner join disposicao as d " +
                            " on a.id_disposicao = d.id_disposicao " +
                        " where a.id = @id_acionamento";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_acionamento", acionamento.Id);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        aci = new Acionamento();
                        dis = new Disposicao();
                        aci.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        aci.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        aci.RotacaoPolos = result["rotacao_polos"].Equals(DBNull.Value) ? "" : result["rotacao_polos"].ToString();
                        aci.TipoAcionamento = result["tipo"].Equals(DBNull.Value) ? "" : result["tipo"].ToString();
                        aci.Fabricante = result["fabricante"].Equals(DBNull.Value) ? "" : result["fabricante"].ToString();
                        aci.Modelo = result["modelo"].Equals(DBNull.Value) ? "" : result["modelo"].ToString();
                        aci.Potencia = result["potencia"].Equals(DBNull.Value) ? "" : result["potencia"].ToString();
                        aci.Carcaca = result["carcaca"].Equals(DBNull.Value) ? "" : result["carcaca"].ToString();
                        aci.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        aci.Teste = result["teste_redutor"].Equals(DBNull.Value) ? false : Convert.ToBoolean(result["teste_redutor"]);
                        aci.TipoTeste = result["tipo_teste"].Equals(DBNull.Value) ? "" : result["tipo_teste"].ToString();
                        aci.InspecaoVisual = result["inspecao_visual"].Equals(DBNull.Value) ? "" : result["inspecao_visual"].ToString();
                        aci.Capa = result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();
                        aci.Id = Convert.ToInt32(result["id"]);
                        dis.ID_Disposicao = Convert.ToInt32(result["d_id_disposicao"]);
                        dis.Nome = result["d_nome"].Equals(DBNull.Value) ? "" : result["d_nome"].ToString();
                        aci.Disposicao = dis;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return aci;
        }


        public bool AlterarAcionamento(Acionamento aci)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = " update acionamento set " +
                                     " nome = @nome," +
                                     " id_disposicao = @id_disposicao, " +
                                     " tipo = @tipo, " +
                                     " fabricante = @fabricante, " +
                                     " modelo = @modelo, " +
                                     " rotacao_polos = @rotacao_polos, " +
                                     " potencia = @potencia, " +
                                     " carcaca = @carcaca, " +
                                     " descricao = @descricao, " +
                                     " teste_redutor = @teste_redutor, " +
                                     " tipo_teste = @tipo_teste, " +
                                     " inspecao_visual = @inspecao_visual " +
                                " where id = @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", aci.Id);
                    comand.Parameters.AddWithValue("@id_peritagem", aci.ID_Peritagem);
                    comand.Parameters.AddWithValue("@id_disposicao", aci.Disposicao.ID_Disposicao);
                    comand.Parameters.AddWithValue("@tipo", aci.TipoAcionamento);
                    comand.Parameters.AddWithValue("@fabricante", aci.Fabricante);
                    comand.Parameters.AddWithValue("@modelo", aci.Modelo);
                    comand.Parameters.AddWithValue("@rotacao_polos", aci.RotacaoPolos);
                    comand.Parameters.AddWithValue("@potencia", aci.Potencia);
                    comand.Parameters.AddWithValue("@carcaca", aci.Carcaca);
                    comand.Parameters.AddWithValue("@descricao", aci.Descricao);
                    comand.Parameters.AddWithValue("@teste_redutor", aci.Teste);
                    comand.Parameters.AddWithValue("@tipo_teste", aci.TipoTeste);
                    comand.Parameters.AddWithValue("@inspecao_visual", aci.InspecaoVisual);
                    comand.Parameters.AddWithValue("@descricao_teste", aci.DescricaoTeste);
                    comand.Parameters.AddWithValue("@nome", aci.Nome);




                    comand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return false;
        }

        public bool AlterarCapa(int ID_Acionamento, string Capa)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update acionamento set capa = @capa where id= @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@capa", Capa);
                    comand.Parameters.AddWithValue("@id", ID_Acionamento);

                    comand.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();
            return false;
        }
    }
}
