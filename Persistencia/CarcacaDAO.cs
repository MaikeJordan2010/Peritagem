using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Persistencia.Conexao;
using Modelo;
using Modelo.Util;

namespace Persistencia
{
    public class CarcacaDAO
    {


        public bool InserirCarcaca(Carcaca car)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = "insert into carcaca(" +
                                     "id," +
                                     "largura," +
                                     "altura," +
                                     "comprimento," +
                                     "peso," +
                                     "descricao," +
                                     "dt_cadastro," +
                                     "medicao_alinhamento," +
                                     "id_disposicao," +
                                     "jateamento," +
                                     "id_peritagem, " +
                                     "id_criador," +
                                     "nome," +
                                     "ativo," +
                                     "isDeletede " +
                        ")values(" +
                                    "next value for sequence_carcaca," +
                                     "@largura," +
                                     "@altura," +
                                     "@comprimento," +
                                     "@peso," +
                                     "@descricao," +
                                     "@dt_cadastro," +
                                     "@medicao_alinhamento," +
                                     "@id_disposicao," +
                                     "@jateamento," +
                                     "@id_peritagem," +
                                     "@id_criador," +
                                     "@nome," +
                                     "1," +
                                     "0" +
                                    ") ";

            String dt_cadastro = cdd.PadraoAmericano(car.Dt_Cadastro.ToString());

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@largura", car.Largura);
                    comand.Parameters.AddWithValue("@altura", car.Altura);
                    comand.Parameters.AddWithValue("@comprimento", car.Comprimento);
                    comand.Parameters.AddWithValue("@peso", car.Peso);
                    comand.Parameters.AddWithValue("@descricao", car.Descricao);
                    comand.Parameters.AddWithValue("@dt_cadastro", dt_cadastro);
                    comand.Parameters.AddWithValue("@medicao_alinhamento", car.MedicaoAlinhamento);
                    comand.Parameters.AddWithValue("@id_disposicao", car.Disposicao.ID_Disposicao);
                    comand.Parameters.AddWithValue("@jateamento", car.Jateamento);
                    comand.Parameters.AddWithValue("@id_criador", car.Usuario_Criador.Id);
                    comand.Parameters.AddWithValue("@id_peritagem", car.ID_Peritagem);
                    comand.Parameters.AddWithValue("@nome", car.Nome);

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




        public List<Carcaca> ConsultarTodos(Peritagem per)
        {
            List<Carcaca> listCarcaca = new List<Carcaca>();
            Carcaca car = null;
            Disposicao dis = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = " select *, " +
                            " d.nome as d_nome, " +
                            " d.id_disposicao as d_id_disposicao " +
                         " from carcaca as c " +
                            " inner join  disposicao as d " +
                            " on c.id_disposicao = d.id_disposicao " +
                         " where c.id_peritagem = @id_peritagem and c.ativo = 1 " ;

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
                        car = new Carcaca();
                        dis = new Disposicao();

                        car.Id = Convert.ToInt32(result["id"]);
                        car.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        car.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        car.Largura = result["largura"].Equals(DBNull.Value) ? "" : result["largura"].ToString();
                        car.Altura = result["altura"].Equals(DBNull.Value) ? "" : result["altura"].ToString();
                        car.Comprimento = result["comprimento"].Equals(DBNull.Value) ? "" : result["comprimento"].ToString();
                        //car.Disposicao.ID_Disposicao = Convert.ToInt32(result["id_disposicao"]);
                        car.Peso = result["peso"].Equals(DBNull.Value) ? "" : result["peso"].ToString();
                        car.Jateamento = Convert.ToBoolean(result["jateamento"]);
                        car.MedicaoAlinhamento = Convert.ToBoolean(result["medicao_alinhamento"]);
                        car.Dt_Cadastro = Convert.ToDateTime(result["dt_cadastro"]);
                        car.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        car.Capa = result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();

                        car.Medicao = ConsultaCarcacaMedida(car);

                        dis.ID_Disposicao = Convert.ToInt32(result["d_id_disposicao"]);
                        dis.Nome = result["d_nome"].Equals(DBNull.Value) ? "" : result["d_nome"].ToString();

                        car.Disposicao = dis;

                        listCarcaca.Add(car);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------" + ex.Message.ToString());
            }
            conn.Close();

            return listCarcaca;
        }


        public Carcaca ConsultaUltima(Carcaca carcaca)
        {
            Carcaca car = null;
            Disposicao dis = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = " select *, " +
                            " d.nome as d_nome, " +
                            " d.id_disposicao as d_id_disposicao " +
                         " from carcaca as c " +
                            " inner join  disposicao as d " +
                            " on c.id_disposicao = d.id_disposicao " +
                         " where id_peritagem = @id_peritagem and dt_cadastro = @dt_cadastro ";

            ConversorDeData cdd = new ConversorDeData();
            String dt_cadastro = cdd.PadraoAmericano(carcaca.Dt_Cadastro.ToString());

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_peritagem", carcaca.ID_Peritagem);
                    comand.Parameters.AddWithValue("@dt_cadastro", dt_cadastro);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        car = new Carcaca();
                        dis = new Disposicao();

                        car.Id = Convert.ToInt32(result["id"]);
                        car.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        car.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        car.Largura = result["largura"].Equals(DBNull.Value) ? "" : result["largura"].ToString();
                        car.Altura = result["altura"].Equals(DBNull.Value) ? "" : result["altura"].ToString();
                        car.Comprimento = result["comprimento"].Equals(DBNull.Value) ? "" : result["comprimento"].ToString();
                        //car.Disposicao.ID_Disposicao = Convert.ToInt32(result["id_disposicao"]);
                        car.Peso = result["peso"].Equals(DBNull.Value) ? "" : result["peso"].ToString();
                        car.Jateamento = Convert.ToBoolean(result["jateamento"]);
                        car.MedicaoAlinhamento = Convert.ToBoolean(result["medicao_alinhamento"]);
                        car.Dt_Cadastro = Convert.ToDateTime(result["dt_cadastro"]);
                        car.Capa = result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();

                        car.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        car.Medicao = ConsultaCarcacaMedida(car);

                        dis.ID_Disposicao = Convert.ToInt32(result["d_id_disposicao"]);
                        dis.Nome = result["d_nome"].Equals(DBNull.Value) ? "" : result["d_nome"].ToString();

                        car.Disposicao = dis;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------" + ex.Message.ToString());
            }
            conn.Close();

            return car;
        }



        public Carcaca ConsultaUm(Carcaca carcaca)
        {
            Carcaca car = null;
            Disposicao dis = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = " select *, " +
                            " d.nome as d_nome, " +
                            " d.id_disposicao as d_id_disposicao " +
                         " from carcaca as c " +
                            " inner join  disposicao as d " +
                            " on c.id_disposicao = d.id_disposicao " +
                         " where id = @id_carcaca and ativo = 1 ";

            ConversorDeData cdd = new ConversorDeData();
            String dt_cadastro = cdd.PadraoAmericano(carcaca.Dt_Cadastro.ToString());

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_carcaca", carcaca.Id);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        car = new Carcaca();
                        dis = new Disposicao();

                        car.Id = Convert.ToInt32(result["id"]);
                        car.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        car.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        car.Largura = result["largura"].Equals(DBNull.Value) ? "" : result["largura"].ToString();
                        car.Altura = result["altura"].Equals(DBNull.Value) ? ""  : result["altura"].ToString();
                        car.Comprimento = result["comprimento"].Equals(DBNull.Value) ? "" : result["comprimento"].ToString();
                        //car.Disposicao.ID_Disposicao = Convert.ToInt32(result["id_disposicao"]);
                        car.Peso = result["peso"].Equals(DBNull.Value) ? "" : result["peso"].ToString();
                        car.Jateamento = Convert.ToBoolean(result["jateamento"]);
                        car.MedicaoAlinhamento = Convert.ToBoolean(result["medicao_alinhamento"]);
                        car.Dt_Cadastro = Convert.ToDateTime(result["dt_cadastro"]);
                        car.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        car.Capa = result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();

                        car.Medicao = ConsultaCarcacaMedida(car);

                        dis.ID_Disposicao = Convert.ToInt32(result["d_id_disposicao"]);
                        dis.Nome = result["d_nome"].Equals(DBNull.Value) ? "" : result["d_nome"].ToString();

                        car.Disposicao = dis;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------" + ex.Message.ToString());
            }
            conn.Close();

            return car;
        }



        public bool InserirCarcacaMedida(CarcacaMedida carMed)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = "insert into carcaca_medida(" +
                                     "id," +
                                     "id_carcaca," +
                                     "posicao," +
                                     "medicao," +
                                     "tolerancia," +
                                     "dt_cadastro," +
                                     "descricao," +
                                     "ativo," +
                                     "isDeletede" +

                        ") values (" +
                                     "next value for sequence_carcaca_medida," +
                                     "@id_carcaca," +
                                     "@posicao," +
                                     "@medicao," +
                                     "@tolerancia," +
                                     "@dt_cadastro," +
                                     "@descricao," +
                                     "1," +
                                     "0" +
                                    ") ";

            String dt_cadastro = cdd.PadraoAmericano(carMed.Dt_Cadastro.ToString());

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_carcaca", carMed.Id_Carcaca);
                    comand.Parameters.AddWithValue("@posicao", carMed.Posicao);
                    comand.Parameters.AddWithValue("@medicao", carMed.Medicao);
                    comand.Parameters.AddWithValue("@tolerancia", carMed.Tolerancia);
                    comand.Parameters.AddWithValue("@dt_cadastro", dt_cadastro);
                    comand.Parameters.AddWithValue("@descricao", carMed.Descricao);


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



        public bool ExcluirCarcacaMedida(CarcacaMedida carMed)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = "update carcaca_medida " +
                            " set ativo = 0, isDeletede = 1 " +
                         " where id = @id ";
            
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", carMed.Id);

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



        public List<CarcacaMedida> ConsultaCarcacaMedida(Carcaca carcaca)
        {
            List<CarcacaMedida> lisCarMed = new List<CarcacaMedida>();
            CarcacaMedida carMed = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from carcaca_medida where id_carcaca = @id_carcaca and ativo = 1";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_carcaca", carcaca.Id);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        carMed = new CarcacaMedida();

                        carMed.Id = Convert.ToInt32(result["id"]);
                        carMed.Medicao = result["medicao"].Equals(DBNull.Value) ? "" : result["medicao"].ToString();
                        carMed.Tolerancia = result["tolerancia"].Equals(DBNull.Value) ? "" : result["tolerancia"].ToString();
                        carMed.Posicao = Convert.ToInt32(result["posicao"]);
                        carMed.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        carMed.Dt_Cadastro = result["dt_cadastro"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_cadastro"]);
                        carMed.Id_Carcaca = Convert.ToInt32(result["id_carcaca"]);

                        lisCarMed.Add(carMed);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------" + ex.Message.ToString());
            }
            conn.Close();

            return lisCarMed;
        }

        public bool AlterarCarcaca(Carcaca car)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = " update carcaca set " +
                                     " largura = @largura, " +
                                     " altura = @altura," +
                                     " comprimento = @comprimento, " +
                                     " peso = @peso, " +
                                     " descricao = @descricao, " +
                                     " medicao_alinhamento = @medicao_alinhamento, " +
                                     " id_disposicao = @id_disposicao, " +
                                     " jateamento = @jateamento, " +
                                     " nome = @nome " +
                        " where id = @id ";
                                    
            String dt_cadastro = cdd.PadraoAmericano(car.Dt_Cadastro.ToString());

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@largura", car.Largura);
                    comand.Parameters.AddWithValue("@altura", car.Altura);
                    comand.Parameters.AddWithValue("@comprimento", car.Comprimento);
                    comand.Parameters.AddWithValue("@peso", car.Peso);
                    comand.Parameters.AddWithValue("@descricao", car.Descricao);
                    comand.Parameters.AddWithValue("@medicao_alinhamento", car.MedicaoAlinhamento);
                    comand.Parameters.AddWithValue("@id_disposicao", car.Disposicao.ID_Disposicao);
                    comand.Parameters.AddWithValue("@jateamento", car.Jateamento);
                    comand.Parameters.AddWithValue("@nome", car.Nome);
                    comand.Parameters.AddWithValue("@id", car.Id);

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


        public bool ExcluirCarcaca(Carcaca car)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = " update carcaca set " +
                                     " ativo = 0, " +
                                     " isDeletede = 1 " +
                        " where id = @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", car.Id);

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



        public bool AlterarCarcacaMedida(CarcacaMedida carMed)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = "update carcaca_medida set " +
                                     " posicao = @posicao, " +
                                     " medicao = @medicao, " +
                                     " tolerancia = @tolerancia," +
                                     " descricao = @descricao " +
                        " where id = @id ";
                                     
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", carMed.Id);
                    comand.Parameters.AddWithValue("@posicao", carMed.Posicao);
                    comand.Parameters.AddWithValue("@medicao", carMed.Medicao);
                    comand.Parameters.AddWithValue("@tolerancia", carMed.Tolerancia);
                    comand.Parameters.AddWithValue("@descricao", carMed.Descricao);


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


        public bool AlterarCapa(int ID_Carcaca, string Capa)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update carcaca set capa = @capa where id = @id_carcaca";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@capa", Capa);
                    comand.Parameters.AddWithValue("@id_carcaca", ID_Carcaca);

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
