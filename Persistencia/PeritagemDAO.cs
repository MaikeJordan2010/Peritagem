using Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Modelo;
using Modelo.Util;

namespace Persistencia
{
    public class PeritagemDAO 
    {
        public Boolean InserirPeritagem(Peritagem per)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();


            String Chegada = cdd.PadraoAmericano(per.Dt_Chegada.ToString());
            String Inicio = cdd.PadraoAmericano(per.Dt_Inicio.ToString());
            String Previsao = cdd.PadraoAmericano(per.Dt_Previsao.ToString());
            String Revisao = DateTime.Now.Year.ToString() + "-01-01";
            String Finalizacao = DateTime.Now.Year.ToString() + "-01-01";
            //String Entrega = cdd.PadraoAmericano(per.Dt_Entrega.ToString());
            String Cadastro = cdd.PadraoAmericano(per.Dt_Cadastro.ToString());
            try
            {

                String sql = "insert into Peritagem" +
                                            "(" +
                                            //"nome," +
                                            "id_orcamento," +
                                            "dt_chegada," +
                                            "dt_inicio," +
                                            "dt_previsao," +
                                            "dt_revisao," +
                                            "dt_finalizacao," +
                                            "id_cliente, " +
                                            "descricao, " +
                                           // "id_os," +
                                            "usuario_Criador," +
                                            "dt_cadastro," +
                                            "protocolo," +
                                            "referencia," +
                                            "motivo, " +
                                            "aplicacao," +
                                            "observacao," +
                                            "numContrato," +
                                            "nfe," +
                                            "id_peritagem," +
                                            "ativo," +
                                            "isDeletede," +
                                            "situacao" +
                                            ")" +
                                    "values" +
                                            "(" +
                                           // "@Nome," +
                                            "@ID_Orcamento," +
                                            "@DT_Chegada," +
                                            "@DT_Inicio," +
                                            "@DT_Previsao," +
                                            "@DT_Revisao," +
                                            "@DT_Finalizacao," +
                                            "@ID_Cliente," +
                                            "@Descricao," +
                                           // "@id_os," +
                                            "@Usuario_Criador,"+
                                            "@DT_Cadastro," +
                                            "@Protocolo," +
                                            "@Referencia," +
                                            "@Motivo, "+
                                            "@Aplicacao," +
                                            "@Observacao," +
                                            "@NumContrato," +
                                            "@Nfe," +
                                            "next value for sequence_peritagem," +
                                            "1," +
                                            "0," +
                                            "0)";

            
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);

                    //comand.Parameters.AddWithValue("@Nome",per.Nome);
                    comand.Parameters.AddWithValue("@Descricao", per.Nome);
                    comand.Parameters.AddWithValue("@ID_Orcamento", per.ID_Orcamento);
                    comand.Parameters.AddWithValue("@DT_Chegada", Chegada);
                    comand.Parameters.AddWithValue("@DT_Inicio", Inicio);
                    comand.Parameters.AddWithValue("@DT_Previsao", Previsao);
                    comand.Parameters.AddWithValue("@DT_Revisao", Revisao);
                    comand.Parameters.AddWithValue("@DT_Finalizacao", Finalizacao);
                    comand.Parameters.AddWithValue("@ID_Cliente", per.Cliente.Id);
                    comand.Parameters.AddWithValue("@Usuario_Criador", per.UsuarioCriador.Id);
                    comand.Parameters.AddWithValue("@DT_Cadastro", Cadastro);
                    comand.Parameters.AddWithValue("@Protocolo", per.Protocolo);
                    comand.Parameters.AddWithValue("@Referencia", per.Referencia);
                    comand.Parameters.AddWithValue("@Motivo", per.MotivoManutencao);
                    comand.Parameters.AddWithValue("@Aplicacao", per.Aplicacao);
                    comand.Parameters.AddWithValue("@Observacao", per.Observacao);
                    comand.Parameters.AddWithValue("@NumContrato", per.NumeroContrato);
                    comand.Parameters.AddWithValue("@Nfe", per.Nfe);

                    comand.ExecuteNonQuery();
                    conn.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("--------------------" + ex.Message.ToString());
            }
            return false ;
        }


        public bool ExcluirPeritagem(Peritagem per)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = " update peritagem set " +
                                     " ativo = 0, " +
                                     " isDeletede = 1 " +
                        " where id_peritagem = @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", per.Id);

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

        public bool AlterarSituacao(Peritagem per)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = " update peritagem set " +
                                     " id_situacao = @ID_Situacao " +
                        " where id_peritagem = @ID_Peritagem ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@ID_Situacao", per.Situacao.Id);
                    comand.Parameters.AddWithValue("@ID_Peritagem", per.Id);


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



        public List<Peritagem> TodasPeritagens( int page, int qtde, int NFE, int ID_Cliente, int ID_Situacao, string NomeEquipamento)
        {
            List<Peritagem> todasPeritagens = new List<Peritagem>();
            Peritagem per = null;
            Usuario user = null;
            Situacao sit = null;
            OrdemServico os = null;
            Cliente cli = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            ClienteDAO cliDAO = null;
            DocumentoDAO docDao = new DocumentoDAO();
            UsuarioDAO useDao = new UsuarioDAO();

            ConversorDeData cdd = new ConversorDeData();
           //TratarImagem conImg = new TratarImagem();
           // String url;
            String chegada;


            int iLimite = 0, fLimite = qtde;

            if (page > 1)
            {
                fLimite = qtde * page;
                iLimite = fLimite - qtde;
            }


            String sql = " SELECT *, " +
                                " (c.id_cliente) as c_id_cLiente," +
                                " (c.nome) as c_nome," +
                                " (c.icone) as c_icone," +
                                " (s.descricao) as s_descricao," +
                                " (s.id_situacao) as s_id_situacao  " +
                            " FROM " +

                                " peritagem as P" +

                                " inner join " +

                                " situacao as s on " +

                                " s.id_situacao = isnull(p.id_situacao, 0) " +

                                " INNER JOIN " +

                                " cliente C  ON " +

                                " p.ID_Cliente = c.ID_Cliente " +

                           " WHERE p.ativo = 1 and p.id_situacao = @ID_Situacao";
                               
            if (NFE != 0)
            {
                sql = sql + "  and p.nfe = @NFE ";
            }
             if(ID_Cliente != 0)
            {
                sql = sql + "   and p.id_cliente = @ID_Cliente ";
            }

            if (NomeEquipamento != null && NomeEquipamento != "")
            {
                sql = sql + "  and p.nome like '%" + NomeEquipamento + "%'";
            }

            sql = sql + " ORDER BY dt_cadastro desc ";

            if (NomeEquipamento == null && NomeEquipamento == "" && ID_Cliente != 0 && NFE != 0 && ID_Situacao != 0)
            {
                sql = sql + " OFFSET @iLimite ROWS FETCH NEXT @fLimite ROWS ONLY ";

            }


            try
            {

                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@iLimite", iLimite);
                    comand.Parameters.AddWithValue("@fLimite", fLimite);
                    comand.Parameters.AddWithValue("@NFE", NFE);
                    comand.Parameters.AddWithValue("@ID_Cliente", ID_Cliente);
                    comand.Parameters.AddWithValue("@ID_Situacao", ID_Situacao);


                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        per = new Peritagem();
                        cli = new Cliente();
                        user = new Usuario();
                        os = new OrdemServico();
                        sit = new Situacao();

                        cli.Id = Convert.ToInt32(result["c_id_cliente"]);
                        cli.Nome = result["c_nome"].ToString();
                        cli.Icone = result["c_icone"].ToString();
                        per.Cliente = cli;

                        os.Id = result["id_os"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["id_os"]);
                        per.OrdemServico = os;

                        sit.Id = Convert.ToInt32(result["s_id_situacao"]);
                        sit.Descricao = result["s_descricao"].Equals(DBNull.Value) ? "" : result["s_descricao"].ToString();

                        per.Situacao = sit;

                        per.Descricao = (result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString());
                        per.Id = Convert.ToInt32(result["id_peritagem"]);
                        per.Descricao = (result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString());
                        per.Dt_Chegada = (result["dt_chegada"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_chegada"].ToString()));
                        per.Dt_Inicio = (result["dt_inicio"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_inicio"].ToString()));
                        per.Dt_Finalizacao = (result["dt_finalizacao"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_finalizacao"].ToString()));
                        per.Dt_Previsao = (result["dt_previsao"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_previsao"].ToString()));
                        per.Dt_Revisao = (result["dt_revisao"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_revisao"].ToString()));
                        per.Dt_Cadastro = (result["dt_cadastro"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_cadastro"].ToString()));
                        per.Nfe = (result["nfe"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["nfe"]));
                        per.Protocolo = (result["protocolo"].Equals(DBNull.Value) ? "" : result["protocolo"].ToString());
                        per.Referencia = (result["referencia"].Equals(DBNull.Value) ? "" : result["referencia"].ToString());
                        per.MotivoManutencao = (result["motivo"].Equals(DBNull.Value) ? "" : result["motivo"].ToString());
                        per.Aplicacao = (result["aplicacao"].Equals(DBNull.Value) ? "" : result["aplicacao"].ToString());
                        per.Observacao = (result["observacao"].Equals(DBNull.Value) ? "" : result["observacao"].ToString());
                        per.NumeroContrato = (result["numContrato"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["numContrato"]));
                        per.Capa = result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();
                        per.ListDoc = docDao.ConsultarDocumento(per.Id, 0);

                        per.UsuarioCriador = useDao.ConsultarUsuario(Convert.ToInt32(result["usuario_criador"]));

                        todasPeritagens.Add(per);

                    }

                }

            }
            catch (Exception ex)
            {
               Console.WriteLine("-------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return todasPeritagens;
            //return "nada demais";
        }



        public Peritagem ConsultarUM(int ID_Peritagem)
        {
            Peritagem per = null;
            Usuario user = null;
            OrdemServico os = null;
            Cliente cli = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            ClienteDAO cliDAO = null;
            UsuarioDAO useDao = new UsuarioDAO();
            DocumentoDAO docDao = new DocumentoDAO();

            String sql = " SELECT  *, " +
                                
                                " (c.id_cliente) as c_id_cliente," +
                                " (c.nome) as c_nome," +
                                " (c.icone) as c_icone " +
                            " FROM " +
                                " Peritagem as p " +
                            " INNER JOIN " +
                                " cliente as c " +
                            " ON " +
                               " p.id_cliente = c.id_cliente " +

                            " WHERE id_peritagem = @id_peritagem ";

            try
            {

                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@ID_Peritagem", ID_Peritagem);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        per = new Peritagem();
                        cli = new Cliente();
                        user = new Usuario();
                        os = new OrdemServico();

                        cli.Id = Convert.ToInt32(result["c_id_cliente"]);
                        cli.Nome = result["c_nome"].ToString();
                        cli.Icone = result["c_icone"].ToString();
                        per.Cliente = cli;

                        os.Id = result["id_os"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["id_os"]);
                        per.OrdemServico = os;


                        per.Descricao = (result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString());
                        per.Id = Convert.ToInt32(result["id_peritagem"]);
                        per.Descricao = (result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString());
                        per.Dt_Chegada = (result["dt_chegada"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_chegada"].ToString()));
                        per.Dt_Inicio = (result["dt_inicio"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_inicio"].ToString()));
                        per.Dt_Finalizacao = (result["dt_finalizacao"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_finalizacao"].ToString()));
                        per.Dt_Previsao = (result["dt_previsao"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_previsao"].ToString()));
                        per.Dt_Revisao = (result["dt_revisao"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_revisao"].ToString()));
                        per.Dt_Cadastro = (result["dt_cadastro"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_cadastro"].ToString()));
                        per.Nfe = (result["nfe"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["nfe"]));
                        per.Protocolo = (result["protocolo"].Equals(DBNull.Value) ? "" : result["protocolo"].ToString());
                        per.Referencia = (result["referencia"].Equals(DBNull.Value) ? "" : result["referencia"].ToString());
                        per.MotivoManutencao = (result["motivo"].Equals(DBNull.Value) ? "" : result["motivo"].ToString());
                        per.Aplicacao = (result["aplicacao"].Equals(DBNull.Value) ? "" : result["aplicacao"].ToString());
                        per.Observacao = (result["observacao"].Equals(DBNull.Value) ? "" : result["observacao"].ToString());
                        per.NumeroContrato = (result["numContrato"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(result["numContrato"]));
                        per.Capa = result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();

                        per.UsuarioCriador = useDao.ConsultarUsuario(Convert.ToInt32(result["usuario_criador"]));

                        per.ListDoc = docDao.ConsultarDocumento(per.Id, 0);

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("--------------------" + ex.Message.ToString());
            }
            conn.Close();
            return per;

        }





        public bool AlterarCapa(int ID_Peritagem, string Capa)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update peritagem set capa = @Capa where ID_Peritagem = @ID_Peritagem";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@Capa", Capa);
                    comand.Parameters.AddWithValue("@ID_Peritagem", ID_Peritagem);

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


        public int QuantidadePeritagem()
        {


            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select count(ID_Peritagem) as qtd from peritagem where ativo = 1 ";
            int quantidade = 0;

            try
            {

                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        quantidade = Convert.ToInt32(result["qtd"]);
                    }

                }

            }
            catch (Exception ex)
            {
                //return ex.Message.ToString();
            }
            conn.Close();
            return quantidade;
        }



        public bool ConsultarNota(Peritagem per )
        {

            ConversorDeData cdd = new ConversorDeData();

            String Cadastro = cdd.PadraoAmericano(per.Dt_Cadastro.ToString());

            Peritagem peritagem = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "Select top 1 * from Peritagem where nfe = @nfe and id_cliente = @id_cliente";

            conn = new Conexao.Conexao().abrirConexao();


            if (conn != null)
            {
                try
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@nfe", per.Nfe);
                    comand.Parameters.AddWithValue("@id_cliente", per.Cliente.Id);

                    result = comand.ExecuteReader();

                    if(result.Read())
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
            return false;
        }

        public int ConsultarUltima(Peritagem per)
        {

            ConversorDeData cdd = new ConversorDeData();

            String dt_cadastro = cdd.PadraoAmericano(per.Dt_Cadastro.ToString());

            Peritagem peritagem = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "Select top 1 * from Peritagem where nfe = @nfe and dt_cadastro = @dt_cadastro";

            conn = new Conexao.Conexao().abrirConexao();

            if (conn != null)
            {
                try
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@nfe", per.Nfe);
                    comand.Parameters.AddWithValue("@dt_cadastro", dt_cadastro);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        peritagem = new Peritagem();
                        peritagem.Id = Convert.ToInt32(result["id_peritagem"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
            return peritagem.Id;
        }


        public Boolean AlterarPeritagem(Peritagem per)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();


            String Chegada = cdd.PadraoAmericano(per.Dt_Chegada.ToString());
            String Inicio = cdd.PadraoAmericano(per.Dt_Inicio.ToString());
            String Previsao = cdd.PadraoAmericano(per.Dt_Previsao.ToString());
            String Revisao = cdd.PadraoAmericano(per.Dt_Revisao.ToString());
            String Finalizacao = cdd.PadraoAmericano(per.Dt_Finalizacao.ToString());
            String Cadastro = cdd.PadraoAmericano(per.Dt_Cadastro.ToString());
            try
            {

                String sql = " update peritagem set " +
                                            " descricao = @descricao," +
                                            " id_orcamento = @id_orcamento," +
                                            " dt_chegada = @dt_chegada," +
                                            " dt_inicio = @dt_inicio," +
                                            " dt_previsao = @dt_previsao," +
                                            " dt_revisao = @dt_revisao, " +
                                            " dt_finalizacao = @dt_finalizacao," +
                                            " protocolo = @protocolo," +
                                            " referencia = @referencia," +
                                            " motivo = @motivo, " +
                                            " aplicacao = @aplicacao," +
                                            " observacao = @observacao," +
                                            " numContrato = @numContrato" +
                                    " where id_peritagem = @id_peritagem ";
                                           

                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);

                    comand.Parameters.AddWithValue("@descricao", per.Descricao);
                    comand.Parameters.AddWithValue("@id_orcamento", per.ID_Orcamento);
                    comand.Parameters.AddWithValue("@dt_chegada", Chegada);
                    comand.Parameters.AddWithValue("@dt_inicio", Inicio);
                    comand.Parameters.AddWithValue("@dt_previsao", Previsao);
                    comand.Parameters.AddWithValue("@dt_revisao", Revisao);
                    comand.Parameters.AddWithValue("@dt_finalizacao", Finalizacao);
                    comand.Parameters.AddWithValue("@protocolo", per.Protocolo);
                    comand.Parameters.AddWithValue("@referencia", per.Referencia);
                    comand.Parameters.AddWithValue("@motivo", per.MotivoManutencao);
                    comand.Parameters.AddWithValue("@aplicacao", per.Aplicacao);
                    comand.Parameters.AddWithValue("@observacao", per.Observacao);
                    comand.Parameters.AddWithValue("@numContrato", per.NumeroContrato);
                    comand.Parameters.AddWithValue("@id_peritagem", per.Id);

                    comand.ExecuteNonQuery();
                    conn.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("--------------------" + ex.Message.ToString());
            }
            return false;
        }



    }
}
