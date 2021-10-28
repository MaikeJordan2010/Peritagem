using Modelo.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Modelo;

namespace Persistencia
{
    public class ImagemDAO
    {


        public bool Inserir(Imagem imagem)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;

            ConversorDeData cdd = new ConversorDeData();
            String Cadastro = cdd.PadraoAmericano(DateTime.Now.ToString());

            String sql = "insert into Imagem(" +
                                            "id_img," +
                                            "id_peca," +
                                            "id_redutor," +
                                            "id_peritagem," +
                                            "id_carcaca," +
                                            "id_acionamento," +
                                            "id_item," +
                                            "path_img," +
                                            "qualidade," +
                                            "path_miniatura," +
                                            "descricao," +
                                            "width," +
                                            "height," +
                                            "usuario_criador," +
                                            "dt_cadastro," +
                                            "latitude," +
                                            "longitude" +
                                " )values(" +
                                            "next value for sequence_imagem," +
                                            "@ID_Peca, " +
                                            "@ID_Redutor," +
                                            "@ID_Peritagem, " +
                                            "@ID_Carcaca," +
                                            "@ID_Acionamento," +
                                            "@ID_ItemDiverso," +
                                            "@Path_Img, " +
                                            "@Qualidade," +
                                            "@Path_Miniatura," +
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
                    comand.Parameters.AddWithValue("@ID_Peca", imagem.ID_Peca);
                    comand.Parameters.AddWithValue("@ID_Redutor", imagem.ID_Redutor);
                    comand.Parameters.AddWithValue("@ID_Peritagem", imagem.ID_Peritagem);
                    comand.Parameters.AddWithValue("@ID_Carcaca", imagem.ID_Carcaca);
                    comand.Parameters.AddWithValue("@ID_Acionamento", imagem.ID_Acionamento);
                    comand.Parameters.AddWithValue("@ID_ItemDiverso", imagem.ID_ItemDiverso);
                    comand.Parameters.AddWithValue("@Path_Img", imagem.Path_Img);
                    comand.Parameters.AddWithValue("@Qualidade", imagem.Qualidade);
                    comand.Parameters.AddWithValue("@Path_Miniatura", imagem.Path_Miniatura);
                    comand.Parameters.AddWithValue("@Descricao", imagem.Descricao);
                    comand.Parameters.AddWithValue("@Width", imagem.Width);
                    comand.Parameters.AddWithValue("@Height", imagem.Height);
                    comand.Parameters.AddWithValue("@Usuario_Criador", imagem.Usuario_Criador.Id);
                    comand.Parameters.AddWithValue("@DT_Cadastro", Cadastro);
                    comand.Parameters.AddWithValue("@Latitude", imagem.Latitude);
                    comand.Parameters.AddWithValue("@Longitude", imagem.Longitude);

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


        public List<Imagem> ListarImagem(Imagem imagem)
        {
            List<Imagem> Lista = new List<Imagem>();
            Imagem img = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            TratarImagem tImg = new TratarImagem();
            Usuario user = null;
            UsuarioDAO userDao = new UsuarioDAO();

            String sql = " select * from Imagem " +
                        " where id_peritagem = @ID_Peritagem " ;

            if(imagem.ID_Redutor != 0)
            {
                sql = sql + " and id_redutor = @ID_Redutor ";
            }

            if (imagem.ID_Peca != 0)
            {
                sql = sql + " and id_peca = @ID_Peca ";
            }

            if (imagem.ID_Carcaca != 0)
            {
                sql = sql + " and id_carcaca = @ID_Carcaca ";
            }

            if (imagem.ID_Acionamento != 0)
            {
                sql = sql + " and id_acionamento = @ID_Acionamento ";
            }

            if (imagem.ID_ItemDiverso != 0)
            {
                sql = sql + " and id_item = @ID_ItemDiverso ";
            }



            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@ID_Carcaca", imagem.ID_Carcaca);
                    comand.Parameters.AddWithValue("@ID_Peritagem", imagem.ID_Peritagem);
                    comand.Parameters.AddWithValue("@ID_Redutor", imagem.ID_Redutor);
                    comand.Parameters.AddWithValue("@ID_Peca", imagem.ID_Peca);
                    comand.Parameters.AddWithValue("@ID_Acionamento", imagem.ID_Acionamento);
                    comand.Parameters.AddWithValue("@ID_ItemDiverso", imagem.ID_ItemDiverso);


                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        img = new Imagem();
                        user = new Usuario();

                        img.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        img.ID_Img = Convert.ToInt32(result["id_img"]);
                        img.ID_Peca = result["id_peca"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["id_peca"]);
                        img.ID_Redutor = result["id_redutor"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["id_redutor"]);
                        img.Path_Img = result["path_img"].ToString();
                        img.Path_Miniatura = result["path_miniatura"].ToString();
                        img.Descricao = result["descricao"].ToString();
                        img.Width = Convert.ToInt32(result["width"]);
                        img.Height = Convert.ToInt32(result["height"]);
                        img.Latitude = result["latitude"].Equals(DBNull.Value) ? "" : result["latitude"].ToString();
                        img.Longitude = result["longitude"].Equals(DBNull.Value) ? "" : result["longitude"].ToString();
                        img.DT_Cadastro = result["dt_cadastro"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_cadastro"]);
                        user.Id = result["usuario_criador"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["usuario_criador"]);
                        img.Usuario_Criador = userDao.ConsultarUsuario(user.Id);

                        Lista.Add(img);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------------------" +  ex.Message.ToString());
            }
            conn.Close();
            return Lista;
        }

    }
}
