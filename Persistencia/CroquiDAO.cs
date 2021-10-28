using Modelo;
using Modelo.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Persistencia
{
    public class CroquiDAO
    {


        public bool Inserir(Croqui croqui)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;

            ConversorDeData cdd = new ConversorDeData();
            String Cadastro = cdd.PadraoAmericano(DateTime.Now.ToString());

            String sql = "insert into croqui (" +
                                            "id_croqui," +
                                            "id_peca," +
                                            "id_carcaca," +
                                            "id_peritagem," +
                                            "path_img," +
                                            "qualidade," +
                                            "descricao," +
                                            "width," +
                                            "height," +
                                            "usuario_criador," +
                                            "dt_cadastro," +
                                            "latitude," +
                                            "longitude" +
                                " )values(" +
                                            "next value for sequence_croqui," +
                                            "@ID_Peca," +
                                            "@ID_Carcaca, " +
                                            "@ID_Peritagem, " +
                                            "@Path_Img, " +
                                            "@Qualidade," +
                                            "@Descricao," +
                                            "@Width," +
                                            "@Height," +
                                            "@Usuario_Criador," +
                                            "@DT_Cadastro," +
                                            "@Latitude," +
                                            "@Longitude)";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@ID_Peca", croqui.ID_Peca);
                    comand.Parameters.AddWithValue("@ID_Carcaca", croqui.ID_Carcaca);
                    comand.Parameters.AddWithValue("@ID_Peritagem", croqui.ID_Peritagem);
                    comand.Parameters.AddWithValue("@Path_Img", croqui.Path_Img);
                    comand.Parameters.AddWithValue("@Qualidade", croqui.Qualidade);
                    comand.Parameters.AddWithValue("@Descricao", croqui.Descricao);
                    comand.Parameters.AddWithValue("@Width", croqui.Width);
                    comand.Parameters.AddWithValue("@Height", croqui.Height);
                    comand.Parameters.AddWithValue("@Usuario_Criador", croqui.Usuario_Criador.Id);
                    comand.Parameters.AddWithValue("@DT_Cadastro", Cadastro);
                    comand.Parameters.AddWithValue("@Latitude", croqui.Latitude);
                    comand.Parameters.AddWithValue("@Longitude", croqui.Longitude);

                    comand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------" + ex.Message.ToString());
            }
            conn.Close();
            return false;
        }


        public List<Croqui> ListarCroqui(Croqui croqui)
        {
            List<Croqui> Lista = new List<Croqui>();
            Croqui cro = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            Usuario user = null;
            UsuarioDAO userDao = new UsuarioDAO();

            String sql = " SELECT * FROM croqui " +
                         " WHERE id_peritagem = @ID_Peritagem  ";

            if(croqui.ID_Peca != 0)
            {
                sql = sql + " and id_peca = @ID_Peca ";
            }

            if (croqui.ID_Carcaca != 0)
            {
                sql = sql + " and id_carcaca = @ID_Carcaca ";
            }


            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@ID_Peca", croqui.ID_Peca);
                    comand.Parameters.AddWithValue("@ID_Carcaca", croqui.ID_Carcaca);
                    comand.Parameters.AddWithValue("@ID_Peritagem", croqui.ID_Peritagem);


                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        cro = new Croqui();
                        user = new Usuario();

                        cro.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        cro.Id = Convert.ToInt32(result["id_croqui"]);
                        cro.ID_Peca = result["id_peca"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["id_peca"]);                        cro.ID_Peca = result["id_peca"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["id_peca"]);
                        cro.ID_Peca = result["id_carcaca"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["id_carcaca"]);
                        cro.Path_Img = result["path_img"].ToString();
                        cro.Descricao = result["descricao"].ToString();
                        cro.Width = Convert.ToInt32(result["width"]);
                        cro.Height = Convert.ToInt32(result["height"]);
                        cro.Latitude = result["latitude"].Equals(DBNull.Value) ? "" : result["latitude"].ToString();
                        cro.Longitude = result["longitude"].Equals(DBNull.Value) ? "" : result["longitude"].ToString();
                        cro.DT_Cadastro = result["dt_cadastro"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_cadastro"]);
                        user.Id = result["usuario_criador"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["usuario_criador"]);
                        cro.Usuario_Criador = userDao.ConsultarUsuario(user.Id);

                        Lista.Add(cro);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return Lista;
        }
    }
}
