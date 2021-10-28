using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Modelo.Util;

namespace Persistencia
{
    public class RedutorDAO
    {


        public bool Inserir(Redutor dadosRedutor)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = "insert into redutor(" +
                                     "id," +
                                     "id_peritagem, " +
                                     "descricao, " +
                                     "dt_cadastro," +
                                     "tipo_dados," +
                                     "fabricante," +
                                     "modelo," +
                                     "rotacao_in," +
                                     "rotacao_out," +
                                     "reducao," +
                                     "potencia," +
                                     "fator_servico,"+
                                     "lubrificacao," +
                                     "viscosidade, " +
                                     "ano_fabricacao," +
                                     "volume, " +
                                     "sentido," +
                                     "visto," +
                                     "aplicacao, " +
                                     "motivo_manutencao," +
                                     "peso," +
                                     "cor," +
                                     "outro, " +
                                     "desenho, " +
                                     "posicao_montagem," +
                                     "pintura_padrao_santana," +
                                     "ativo," +
                                     "isDeletede" +


                        ")values(" +
                                    "next value for sequence_redutor,"+
                                     "@id_peritagem, " +
                                     "@descricao, " +
                                     "@dt_cadastro," +
                                     "@tipo_dados," +
                                     "@fabricante," +
                                     "@modelo," +
                                     "@rotacao_in," +
                                     "@rotacao_out," +
                                     "@reducao," +
                                     "@potencia," +
                                     "@fator_servico," +
                                     "@lubrificacao," +
                                     "@viscosidade, " +
                                     "@ano_fabricacao," +
                                     "@volume, " +
                                     "@sentido," +
                                     "@visto," +
                                     "@aplicacao, " +
                                     "@motivo_manutencao," +
                                     "@peso," +
                                     "@cor," +
                                     "@outro, " +
                                     "@desenho, " +
                                     "@posicao_montagem," +
                                     "@pintura_padrao_santana," +
                                     "1," +
                                     "0" +
                                    ") ";

            String dt_cadastro = cdd.PadraoAmericano(dadosRedutor.DT_Cadastro.ToString());

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_peritagem", dadosRedutor.ID_Peritagem);
                    comand.Parameters.AddWithValue("@descricao", dadosRedutor.Descricao);
                    comand.Parameters.AddWithValue("@dt_cadastro", dt_cadastro);
                    comand.Parameters.AddWithValue("@tipo_dados", dadosRedutor.TipoDados);
                    comand.Parameters.AddWithValue("@fabricante", dadosRedutor.Fabricante);
                    comand.Parameters.AddWithValue("@modelo", dadosRedutor.Modelo);
                    comand.Parameters.AddWithValue("@rotacao_in", dadosRedutor.RotacaoIN);
                    comand.Parameters.AddWithValue("@rotacao_out", dadosRedutor.RotacaoOUT);
                    comand.Parameters.AddWithValue("@reducao", dadosRedutor.Reducao);
                    comand.Parameters.AddWithValue("@potencia", dadosRedutor.Potencia);
                    comand.Parameters.AddWithValue("@fator_servico", dadosRedutor.FatorServico);
                    comand.Parameters.AddWithValue("@lubrificacao", dadosRedutor.Lubrificacao);
                    comand.Parameters.AddWithValue("@viscosidade", dadosRedutor.Viscosidade);
                    comand.Parameters.AddWithValue("@ano_fabricacao", dadosRedutor.AnoFabricacao);
                    comand.Parameters.AddWithValue("@volume", dadosRedutor.Volume);
                    comand.Parameters.AddWithValue("@sentido", dadosRedutor.Sentido);
                    comand.Parameters.AddWithValue("@visto", dadosRedutor.Visto);
                    comand.Parameters.AddWithValue("@aplicacao", dadosRedutor.Aplicacao);
                    comand.Parameters.AddWithValue("@motivo_manutencao", dadosRedutor.MotivoManutencao);
                    comand.Parameters.AddWithValue("@peso", dadosRedutor.Peso);
                    comand.Parameters.AddWithValue("@cor", dadosRedutor.Cor);
                    comand.Parameters.AddWithValue("@outro", dadosRedutor.Outro);
                    comand.Parameters.AddWithValue("@desenho", dadosRedutor.Desenho);
                    comand.Parameters.AddWithValue("@posicao_montagem", dadosRedutor.PosicaoMontagem);
                    comand.Parameters.AddWithValue("@pintura_padrao_santana", dadosRedutor.PinturaPadraoSantana);

                    comand.ExecuteNonQuery();

                    return true;
                }

            }
            catch (Exception ex)
            {
                 Console.WriteLine("----------------------" +  ex.Message.ToString());

                //return ("----------------------" + ex.Message.ToString());
            }
            conn.Close();
            return false;
        }

        public bool ValidarExistencia(int ID_Peritagem)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from redutor where id_peritagem = @id_peritagem and ativo = 1";

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



        public bool Alterar(Redutor dadosRedutor)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = "update redutor set " +
                                     " descricao = @descricao , " +
                                     " tipo_dados = @tipo_dados," +
                                     " fabricante = @fabricante," +
                                     " modelo = @modelo," +
                                     " rotacao_in = @rotacao_in," +
                                     " rotacao_out = @rotacao_out," +
                                     " reducao = @reducao," +
                                     " potencia = @potencia," +
                                     " fator_servico = @fator_servico," +
                                     " lubrificacao = @lubrificacao," +
                                     " viscosidade = @viscosidade, " +
                                     " ano_fabricacao = @ano_fabricacao," +
                                     " volume = @volume, " +
                                     " sentido = @sentido," +
                                     " visto = @visto," +
                                     " aplicacao = @aplicacao, " +
                                     " motivo_manutencao = @motivo_manutencao," +
                                     " peso = @peso," +
                                     " cor = @cor," +
                                     " outro = @outro, " +
                                     " desenho = @desenho, " +
                                     " posicao_montagem = @posicao_montagem," +
                                     " pintura_padrao_santana = @pintura_padrao_santana " +
                            " where id = @id_redutor ";

            String dt_cadastro = cdd.PegarDataHoraAtual();

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@descricao", dadosRedutor.Descricao);
                    comand.Parameters.AddWithValue("@tipo_dados", dadosRedutor.TipoDados);
                    comand.Parameters.AddWithValue("@fabricante", dadosRedutor.Fabricante);
                    comand.Parameters.AddWithValue("@modelo", dadosRedutor.Modelo);
                    comand.Parameters.AddWithValue("@rotacao_in", dadosRedutor.RotacaoIN);
                    comand.Parameters.AddWithValue("@rotacao_out", dadosRedutor.RotacaoOUT);
                    comand.Parameters.AddWithValue("@reducao", dadosRedutor.Reducao);
                    comand.Parameters.AddWithValue("@potencia", dadosRedutor.Potencia);
                    comand.Parameters.AddWithValue("@fator_servico", dadosRedutor.FatorServico);
                    comand.Parameters.AddWithValue("@lubrificacao", dadosRedutor.Lubrificacao);
                    comand.Parameters.AddWithValue("@viscosidade", dadosRedutor.Viscosidade);
                    comand.Parameters.AddWithValue("@ano_fabricacao", dadosRedutor.AnoFabricacao);
                    comand.Parameters.AddWithValue("@volume", dadosRedutor.Volume);
                    comand.Parameters.AddWithValue("@sentido", dadosRedutor.Sentido);
                    comand.Parameters.AddWithValue("@visto", dadosRedutor.Visto);
                    comand.Parameters.AddWithValue("@aplicacao", dadosRedutor.Aplicacao);
                    comand.Parameters.AddWithValue("@motivo_manutencao", dadosRedutor.MotivoManutencao);
                    comand.Parameters.AddWithValue("@peso", dadosRedutor.Peso);
                    comand.Parameters.AddWithValue("@cor", dadosRedutor.Cor);
                    comand.Parameters.AddWithValue("@outro", dadosRedutor.Outro);
                    comand.Parameters.AddWithValue("@desenho", dadosRedutor.Desenho);
                    comand.Parameters.AddWithValue("@posicao_montagem", dadosRedutor.PosicaoMontagem);
                    comand.Parameters.AddWithValue("@pintura_padrao_santana", dadosRedutor.PinturaPadraoSantana);
                    comand.Parameters.AddWithValue("@id_redutor", dadosRedutor.Id);

                    comand.ExecuteNonQuery();

                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------" + ex.Message.ToString());
            }
            conn.Close();
            return false;
        }


        public bool ExcluirRedutor(Redutor red)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = " update redutor set " +
                                     " ativo = 0, " +
                                     " isDeletede = 1 " +
                        " where id = @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", red.Id);

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


        public List<Redutor> ConsultaTodos(Peritagem per)
        {
            List<Redutor> Lista = new List<Redutor>();
            Redutor dRed = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            TipoItem tipo = null;
            Disposicao disp = null;
            PecaDAO itDao = new PecaDAO();
            String sql = "select * " +

                         " from redutor " +

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
                        dRed = new Redutor();

                        dRed.Id = Convert.ToInt32(result["id"]);
                        dRed.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        dRed.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        dRed.DT_Cadastro = Convert.ToDateTime(result["dt_cadastro"]);
                        dRed.AnoFabricacao = result["ano_fabricacao"].Equals(DBNull.Value) ? "" : result["ano_fabricacao"].ToString();
                        dRed.TipoDados = result["tipo_dados"].Equals(DBNull.Value) ? "" : result["tipo_dados"].ToString();
                        dRed.Fabricante = result["fabricante"].Equals(DBNull.Value) ? "" : result["fabricante"].ToString();
                        dRed.Modelo = result["modelo"].Equals(DBNull.Value) ? "" : result["modelo"].ToString();
                        dRed.RotacaoIN = result["rotacao_in"].Equals(DBNull.Value) ? "" :result["rotacao_in"].ToString();
                        dRed.RotacaoOUT = result["rotacao_out"].Equals(DBNull.Value) ? "" : result["rotacao_out"].ToString();
                        dRed.Reducao = result["reducao"].Equals(DBNull.Value) ? "" : result["reducao"].ToString();
                        dRed.Potencia = result["potencia"].Equals(DBNull.Value) ? "" : result["potencia"].ToString();
                        dRed.Lubrificacao = result["lubrificacao"].Equals(DBNull.Value) ? "" : result["lubrificacao"].ToString();
                        dRed.FatorServico = result["fator_servico"].Equals(DBNull.Value) ? "" : result["fator_servico"].ToString();
                        dRed.Viscosidade = result["viscosidade"].Equals(DBNull.Value) ? "" : result["viscosidade"].ToString();
                        dRed.Volume = result["volume"].Equals(DBNull.Value) ? "" : result["volume"].ToString();
                        dRed.Peso = result["peso"].Equals(DBNull.Value) ? "" : result["peso"].ToString();
                        dRed.Cor = result["cor"].Equals(DBNull.Value) ? "" : result["cor"].ToString();
                        dRed.Outro = result["outro"].Equals(DBNull.Value) ? "" : result["outro"].ToString();
                        dRed.PosicaoMontagem = result["posicao_montagem"].Equals(DBNull.Value) ? "" : result["posicao_montagem"].ToString();
                        dRed.PinturaPadraoSantana = result["pintura_padrao_santana"].Equals(DBNull.Value) ? false : Convert.ToBoolean(result["pintura_padrao_santana"]);
                        dRed.Capa = result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();
                        dRed.Sentido = result["sentido"].Equals(DBNull.Value) ? "" : result["sentido"].ToString();
                        dRed.Visto = result["visto"].Equals(DBNull.Value) ? "" : result["visto"].ToString();
                        dRed.MotivoManutencao = result["motivo_manutencao"].Equals(DBNull.Value) ? "" : result["motivo_manutencao"].ToString();
                        dRed.Aplicacao = result["aplicacao"].Equals(DBNull.Value) ? "" : result["aplicacao"].ToString();
                        dRed.Desenho = result["desenho"].Equals(DBNull.Value) ? "" : result["desenho"].ToString();


                        Lista.Add(dRed);
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return Lista;
        }



        public Redutor ConsultaUm(Redutor redutor)
        {
            Redutor dRed = new Redutor();

            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from redutor where ativo = 1 and id_peritagem = @id_peritagem ";

            if(redutor.Id != 0)
            {
                sql = sql + " or id = @id ";
            }

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", redutor.Id);
                    comand.Parameters.AddWithValue("@id_peritagem", redutor.ID_Peritagem);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {

                        dRed.Id = Convert.ToInt32(result["id"]);
                        dRed.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        dRed.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        dRed.DT_Cadastro = Convert.ToDateTime(result["dt_cadastro"]);
                        dRed.TipoDados = result["tipo_dados"].Equals(DBNull.Value) ? "" : result["tipo_dados"].ToString();
                        dRed.Fabricante = result["fabricante"].Equals(DBNull.Value) ? "" : result["fabricante"].ToString();
                        dRed.Modelo = result["modelo"].Equals(DBNull.Value) ? "" : result["modelo"].ToString();
                        dRed.RotacaoIN = result["rotacao_in"].Equals(DBNull.Value) ? "" : result["rotacao_in"].ToString();
                        dRed.RotacaoOUT = result["rotacao_out"].Equals(DBNull.Value) ? "" : result["rotacao_out"].ToString();
                        dRed.Reducao = result["reducao"].Equals(DBNull.Value) ? "" : result["reducao"].ToString();
                        dRed.Potencia = result["potencia"].Equals(DBNull.Value) ? "" : result["potencia"].ToString();
                        dRed.Lubrificacao = result["lubrificacao"].Equals(DBNull.Value) ? "" : result["lubrificacao"].ToString();
                        dRed.FatorServico = result["fator_servico"].Equals(DBNull.Value) ? "" : result["fator_servico"].ToString();
                        dRed.Viscosidade = result["viscosidade"].Equals(DBNull.Value) ? "" : result["viscosidade"].ToString();
                        dRed.AnoFabricacao = result["ano_fabricacao"].Equals(DBNull.Value) ? "" : result["ano_fabricacao"].ToString();
                        dRed.Volume = result["volume"].Equals(DBNull.Value) ? "" : result["volume"].ToString();
                        dRed.Peso = result["peso"].Equals(DBNull.Value) ? "" : result["peso"].ToString();
                        dRed.Cor = result["cor"].Equals(DBNull.Value) ? "" : result["cor"].ToString();
                        dRed.Outro = result["outro"].Equals(DBNull.Value) ? "" : result["outro"].ToString();
                        dRed.PosicaoMontagem = result["posicao_montagem"].Equals(DBNull.Value) ? "" : result["posicao_montagem"].ToString();
                        dRed.PinturaPadraoSantana = result["pintura_padrao_santana"].Equals(DBNull.Value) ? false : Convert.ToBoolean(result["pintura_padrao_santana"]);
                        dRed.Capa = result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();
                        dRed.Sentido = result["sentido"].Equals(DBNull.Value) ? "" : result["sentido"].ToString();
                        dRed.Visto = result["visto"].Equals(DBNull.Value) ? "" : result["visto"].ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return dRed;
        }


        public bool AlterarCapa(int ID_Redutor, string Capa)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update redutor set capa = @capa where id= @id_redutor";
                                   
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@capa", Capa);
                    comand.Parameters.AddWithValue("@id_redutor", ID_Redutor);

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
