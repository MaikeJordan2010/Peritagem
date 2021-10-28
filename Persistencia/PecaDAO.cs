using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Modelo;
using Modelo.Util;

namespace Persistencia
{
    public class PecaDAO
    {
        public bool Inserir(Peca peca)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String dt_cadastro = cdd.PadraoAmericano(peca.Dt_Cadastro.ToString());

            String sql = "insert into peca(" +
                                                "id," +
                                                "id_peritagem," +
                                                "descricao," +
                                                "altura," +
                                                "largura," +
                                                "tratamento_termico," +
                                                "dureza," +
                                                "peso," +
                                                "helicoidal," +
                                                "especial," +
                                                "descricao_retrabalho," +
                                                "desenho," +
                                                "produto," +
                                                "valor_k," +
                                                "metodo_fabricacao," +
                                                "furo," +
                                                "dt_cadastro," +
                                                "id_tipo_peca," +
                                                "id_disposicao," +
                                                "id_material," +
                                                "ativo," +
                                                "isDeletede," +
                                                "sentido" +

                                      ")values(" +
                                                "next value for sequence_peca," +
                                                "@id_peritagem," +
                                                "@descricao," +
                                                "@altura," +
                                                "@largura," +
                                                "@tratamento_termico," +
                                                "@dureza," +
                                                "@peso," +
                                                "@helicoidal," +
                                                "@especial," +
                                                "@descricao_retrabalho," +
                                                "@desenho," +
                                                "@produto," +
                                                "@valor_k," +
                                                "@metodo_fabricacao," +
                                                "@furo," +
                                                "@dt_cadastro," +
                                                "@id_tipo_peca," +
                                                "@id_disposicao," +
                                                "@id_material," +
                                                "1," +
                                                "0," +
                                                "@sentido" +
                                                ") ";
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_peritagem", peca.ID_Peritagem);
                    comand.Parameters.AddWithValue("@descricao", peca.Descricao);
                    comand.Parameters.AddWithValue("@altura", peca.Altura);
                    comand.Parameters.AddWithValue("@largura", peca.Largura);
                    comand.Parameters.AddWithValue("@tratamento_termico", peca.TratamentoTermico);
                    comand.Parameters.AddWithValue("@dureza", peca.Dureza);
                    comand.Parameters.AddWithValue("@peso", peca.Peso);
                    comand.Parameters.AddWithValue("@especial", peca.Especial);
                    comand.Parameters.AddWithValue("@descricao_retrabalho", peca.DescricaoRetrabalho);
                    comand.Parameters.AddWithValue("@desenho", peca.Desenho);
                    comand.Parameters.AddWithValue("@produto", peca.Produto);
                    comand.Parameters.AddWithValue("@valor_k", peca.ValorK);
                    comand.Parameters.AddWithValue("@metodo_fabricacao", peca.MetodoFabricacao);
                    comand.Parameters.AddWithValue("@furo", peca.Furo);
                    comand.Parameters.AddWithValue("@dt_cadastro", dt_cadastro);
                    comand.Parameters.AddWithValue("@id_tipo_peca", peca.TipoPeca.Id);
                    comand.Parameters.AddWithValue("@id_disposicao", peca.Disposicao.ID_Disposicao);
                    comand.Parameters.AddWithValue("@id_material", peca.Material.Id);
                    comand.Parameters.AddWithValue("@helicoidal", peca.Helicoidal);
                    comand.Parameters.AddWithValue("@sentido", peca.Sentido);


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



        public List<Peca> ConsultaTodos(Peritagem per)
        {
            //List<Peca_W> vW = new List<Peca_W>();
            List<Peca> ListaItem = new List<Peca>();
            List<Peca_Dados> pd = null;
            List<Documento> ListDoc = new List<Documento>();
            DocumentoDAO docDao = new DocumentoDAO();
            Peca it = null;
            TipoPeca tipo = null;
            Croqui croqui = null;
            CroquiDAO cDao = new CroquiDAO();

            Material mat = null;
            Disposicao dis = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select     *, " +
                            " d.id_disposicao as d_id, d.nome as d_nome, " +
                            " m.id as m_id, m.nome as m_nome,"+
                            " t.id as t_id, t.nome as t_nome " +

                        " from peca as p " +
                            " inner join disposicao as d "+
                            " on p.id_disposicao = d.id_disposicao " +

                            " inner join material as m " +
                            " on p.id_material = m.id " +

                            " inner join tipo_peca as t " +
                            " on p.id_tipo_peca  = t.id " +
                        " where p.id_peritagem = @id_peritagem and p.ativo = 1 " +
                        " order by dt_cadastro desc ";

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
                        it = new Peca();
                        dis = new Disposicao();
                        mat = new Material();
                        tipo = new TipoPeca();
                        croqui = new Croqui();
                        pd = new List<Peca_Dados>();

                        it.Id = Convert.ToInt32(result["id"]);
                        it.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        it.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        it.Altura = result["altura"].Equals(DBNull.Value) ? "" : result["altura"].ToString();
                        it.Largura = result["largura"].Equals(DBNull.Value) ? "" : result["largura"].ToString();
                        it.Furo = result["furo"].Equals(DBNull.Value) ? "" : result["furo"].ToString();
                        it.Dureza = result["dureza"].Equals(DBNull.Value) ? "" : result["dureza"].ToString();
                        it.TratamentoTermico = result["tratamento_termico"].Equals(DBNull.Value) ? "" : result["tratamento_termico"].ToString();
                        it.Peso = result["peso"].Equals(DBNull.Value) ? "" : result["peso"].ToString();
                        it.Especial = result["especial"].Equals(DBNull.Value) ? "" : result["especial"].ToString();
                        it.DescricaoRetrabalho =  result["descricao_retrabalho"].Equals(DBNull.Value) ? "" : result["descricao_retrabalho"].ToString();
                        it.Desenho = result["desenho"].Equals(DBNull.Value) ? "" : result["desenho"].ToString();
                        it.Produto  = result["produto"].Equals(DBNull.Value) ? "" : result["produto"].ToString();
                        it.ValorK = result["valor_k"].Equals(DBNull.Value) ? "" : result["valor_k"].ToString();
                        it.MetodoFabricacao = result["metodo_fabricacao"].Equals(DBNull.Value) ? "" : result["metodo_fabricacao"].ToString();
                        it.Dt_Cadastro = result["dt_cadastro"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_cadastro"]);
                        it.Capa =  result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();
                      
                        it.Helicoidal = result["helicoidal"].Equals(DBNull.Value) ? false : Convert.ToBoolean(result["helicoidal"]);
                        it.Sentido = result["sentido"].Equals(DBNull.Value) ? "" : result["sentido"].ToString();

                        croqui.ID_Peca = it.Id;
                        croqui.ID_Peritagem = per.Id;

                        it.Croqui = cDao.ListarCroqui(croqui);

                        it.ListDocumentos = docDao.ConsultarDocumento(it.ID_Peritagem, it.Id);


                        dis.ID_Disposicao = Convert.ToInt32(result["d_id"]);
                        dis.Nome = result["d_nome"].Equals(DBNull.Value) ? "" : result["d_nome"].ToString();

                        mat.Id = Convert.ToInt32(result["m_id"]);
                        mat.Nome = result["m_nome"].Equals(DBNull.Value) ? "" : result["m_nome"].ToString();

                        tipo.Id = Convert.ToInt32(result["t_id"]);
                        tipo.Nome = result["t_nome"].Equals(DBNull.Value) ? "" : result["t_nome"].ToString();

                        //vW = ConsultaValorW(it.Id);
                        //it.ListValorW = vW == null ? null : vW;


                        pd = ConsultaPecaDados(it.Id);
                        it.DadosPeca = pd == null ? null : pd;

                        it.Material = mat;
                        it.Disposicao = dis;
                        it.TipoPeca = tipo;

                        ListaItem.Add(it);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return ListaItem;
        }





        public int ConsultaUltima(Peca peca)
        {
            Peca it = null;
           
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;

            ConversorDeData cdd = new ConversorDeData();
            String dt_cadastro = cdd.PadraoAmericano(peca.Dt_Cadastro.ToString());

            String sql = "SELECT * FROM peca " +
                        " WHERE " +
                            " dt_cadastro = @DT_Cadastro " +
                            " and descricao = @descricao " +
                            " and id_tipo_peca = @ID_Tipo_Peca "; 

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@DT_Cadastro", dt_cadastro);
                    comand.Parameters.AddWithValue("@descricao", peca.Descricao);
                    comand.Parameters.AddWithValue("@ID_Tipo_Peca", peca.TipoPeca.Id);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        it = new Peca();
                       
                        it.Id = Convert.ToInt32(result["id"].ToString());
                      
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return it.Id;
        }




        public Peca ConsultaUM(Peca peca)
        {
            Peca it = null;
           // List<Peca_W> pw = null;
            List<Peca_Dados> pd = null;
            TipoPeca tipo = null;
            Material mat = null;
            Disposicao dis = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            List<Documento> ListDoc = new List<Documento>();
            DocumentoDAO docDao = new DocumentoDAO();
            String sql = "SELECT     *, " +
                            " d.id_disposicao as d_id_disposicao , " +
                            " d.nome as d_nome, " +
                            " m.id as m_id, " +
                            " m.nome as m_nome, " +
                            " t.id as t_id, " +
                            " t.nome as t_nome " +

                        " FROM peca as p" +

                        " INNER JOIN disposicao as d " +
                            " ON p.id_disposicao = d.id_disposicao " +

                        " INNER JOIN material as m " +
                            " ON p.id_material = m.id " +

                        " INNER JOIN tipo_peca as t " +
                            " ON p.id_tipo_peca  = t.id " +

                        " WHERE p.id = @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", peca.Id);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        it = new Peca();
                        dis = new Disposicao();
                        mat = new Material();
                        tipo = new TipoPeca();
                        pd = new List<Peca_Dados>();

                        it.Id = Convert.ToInt32(result["id"]);
                        it.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        it.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        it.Altura = result["altura"].Equals(DBNull.Value) ? "" : result["altura"].ToString();
                        it.Largura = result["largura"].Equals(DBNull.Value) ? "" : result["largura"].ToString(); it.Dureza = result["dureza"].Equals(DBNull.Value) ? "" : result["dureza"].ToString();
                        it.Furo = result["furo"].Equals(DBNull.Value) ? "" : result["furo"].ToString();
                        it.TratamentoTermico = result["tratamento_termico"].Equals(DBNull.Value) ? "" : result["tratamento_termico"].ToString();
                        it.Peso = result["peso"].Equals(DBNull.Value) ? "" : result["peso"].ToString();
                        it.Especial = result["especial"].Equals(DBNull.Value) ? "" : result["especial"].ToString();
                        it.DescricaoRetrabalho = result["descricao_retrabalho"].Equals(DBNull.Value) ? "" : result["descricao_retrabalho"].ToString();
                        it.Desenho = result["desenho"].Equals(DBNull.Value) ? "" : result["desenho"].ToString();
                        it.Produto = result["produto"].Equals(DBNull.Value) ? "" : result["produto"].ToString();
                        it.ValorK = result["valor_k"].Equals(DBNull.Value) ? "" : result["valor_k"].ToString();
                        it.MetodoFabricacao = result["metodo_fabricacao"].Equals(DBNull.Value) ? "" : result["metodo_fabricacao"].ToString();
                        it.Dt_Cadastro = result["dt_cadastro"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_cadastro"]);
                        it.Capa = result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();
                        it.Helicoidal = result["helicoidal"].Equals(DBNull.Value) ? false : Convert.ToBoolean(result["helicoidal"]);
                        it.Sentido = result["sentido"].Equals(DBNull.Value) ? "" : result["sentido"].ToString();

                        dis.ID_Disposicao = Convert.ToInt32(result["d_id_disposicao"]);
                        dis.Nome = result["d_nome"].Equals(DBNull.Value) ? "" : result["d_nome"].ToString();

                        mat.Id = Convert.ToInt32(result["m_id"]);
                        mat.Nome = result["m_nome"].Equals(DBNull.Value) ? "" : result["m_nome"].ToString();

                        tipo.Id = Convert.ToInt32(result["t_id"]);
                        tipo.Nome = result["t_nome"].Equals(DBNull.Value) ? "" : result["t_nome"].ToString();

                        it.ListDocumentos = docDao.ConsultarDocumento(it.ID_Peritagem, it.Id);

                        //pw = ConsultaValorW(it.Id);
                        //it.ListValorW = pw == null ? null : pw;

                        pd = ConsultaPecaDados(it.Id);
                        it.DadosPeca = pd == null ? null : pd;

                        it.Material = mat;
                        it.Disposicao = dis;
                        it.TipoPeca = tipo;

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return it;
        }


        public bool ExcluirPeca(Peca peca)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = " update peca set " +
                                     " ativo = 0, " +
                                     " isDeletede = 1 " +
                        " where id = @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", peca.Id);

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



        public bool AlterarCapa(int ID_Peca, string Capa)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update peca set capa = @capa where id = @id";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@capa", Capa);
                    comand.Parameters.AddWithValue("@id", ID_Peca);

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


        public bool Alterar(Peca peca)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String dt_cadastro = cdd.PadraoAmericano(DateTime.Now.ToString());

            String sql = "update peca set " +
                                            " descricao = @descricao," +
                                            " altura = @altura," +
                                            " largura = @largura," +
                                            " furo = @furo," +
                                            " tratamento_termico = @tratamento_termico," +
                                            " dureza = @dureza," +
                                            " peso = @peso," +
                                            " helicoidal = @helicoidal," +
                                            " especial = @especial," +
                                            " descricao_retrabalho = @descricao_retrabalho," +
                                            " desenho = @desenho," +
                                            " produto = @produto," +
                                            " valor_k = @valor_k," +
                                            " metodo_fabricacao = @metodo_fabricacao," +
                                            " id_disposicao = @id_disposicao," +
                                            " id_material = @id_material, " +
                                            " sentido = @sentido" +
                                " where id = @id";
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@descricao", peca.Descricao);
                    comand.Parameters.AddWithValue("@altura", peca.Altura);
                    comand.Parameters.AddWithValue("@largura", peca.Largura);
                    comand.Parameters.AddWithValue("@furo", peca.Furo);
                    comand.Parameters.AddWithValue("@tratamento_termico", peca.TratamentoTermico);
                    comand.Parameters.AddWithValue("@dureza", peca.Dureza);
                    comand.Parameters.AddWithValue("@peso", peca.Peso);
                    comand.Parameters.AddWithValue("@especial", peca.Especial);
                    comand.Parameters.AddWithValue("@descricao_retrabalho", peca.DescricaoRetrabalho);
                    comand.Parameters.AddWithValue("@desenho", peca.Desenho);
                    comand.Parameters.AddWithValue("@produto", peca.Produto);
                    comand.Parameters.AddWithValue("@valor_k", peca.ValorK);
                    comand.Parameters.AddWithValue("@metodo_fabricacao", peca.MetodoFabricacao);
                    comand.Parameters.AddWithValue("@id", peca.Id);
                    comand.Parameters.AddWithValue("@id_disposicao", peca.Disposicao.ID_Disposicao);
                    comand.Parameters.AddWithValue("@id_material", peca.Material.Id);
                    comand.Parameters.AddWithValue("@helicoidal", peca.Helicoidal);
                    comand.Parameters.AddWithValue("@sentido", peca.Sentido);


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


        public bool InserirValorW(Peca_W w)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String dt_cadastro = cdd.PadraoAmericano(DateTime.Now.ToString());

            String sql = "insert into peca_w(" +
                                                " id, " +
                                                " w, " +
                                                " valor_w, " +
                                                " id_peca ," +
                                                " ativo," +
                                                " isDeletede" +

                                      ")values(" +
                                                " next value for sequence_peca_w, " +
                                                " @W, " +
                                                " @Valor_W, " +
                                                " @ID_Peca," +
                                                " 1," +
                                                " 0" +
                                                ") ";
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@W", w.W);
                    comand.Parameters.AddWithValue("@Valor_W", w.ValorW);
                    comand.Parameters.AddWithValue("@ID_Peca", w.ID_Peca);

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



        public bool AlterarValorW(Peca_W w)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;


            String sql = "update peca_w set " +
                                                " w = @W, " +
                                                " valor_w = @Valor_W " +
                                                " where id = @ID ";
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@W", w.W);
                    comand.Parameters.AddWithValue("@Valor_W", w.ValorW);
                    comand.Parameters.AddWithValue("@ID", w.Id);

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




        public bool ExcluirValorW(Peca_W w)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;


            String sql = "update peca_w set " +
                                                " ativo = 0, " +
                                                " isDeletede = 1 " +
                                                " where id = @id ";
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@ID", w.Id);

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





        public List<Peca_W> ConsultaValorW(int ID_Peca)
        {
            Peca_W it = null;
            List<Peca_W> todos = new List<Peca_W>();
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "SELECT * FROM peca_w " +
                           
                        " WHERE id_peca = @ID_Peca and ativo = 1";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@ID_Peca",ID_Peca);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        it = new Peca_W();

                        it.Id = Convert.ToInt32(result["id"]);
                        it.ID_Peca = Convert.ToInt32(result["id_peca"]);
                        it.W = Convert.ToInt32(result["w"]);
                        it.ValorW = result["valor_w"].Equals(DBNull.Value) ? "" : result["valor_w"].ToString();

                        todos.Add(it);
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return todos;
        }



        public bool InserirPecaDados(Peca_Dados pd)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String dt_cadastro = cdd.PadraoAmericano(DateTime.Now.ToString());

            String sql = "insert into peca_dados(" +
                                                " id, " +
                                                " num_dentes, " +
                                                " angulo_helice, " +
                                                " angulo_pressao ," +
                                                " externo," +
                                                " largura_dente," +
                                                " medida_w," +
                                                " id_peca," +
                                                " ativo," +
                                                " isDeletede" +

                                      ")values(" +
                                                " next value for sequence_peca_dados, " +
                                                " @num_dentes, " +
                                                " @angulo_helice, " +
                                                " @angulo_pressao," +
                                                " @externo," +
                                                " @largura_dente," +
                                                " @medida_w," +
                                                " @id_peca," +
                                                " 1," +
                                                " 0" +
                                                ") ";
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@num_dentes", pd.NumDentes);
                    comand.Parameters.AddWithValue("@angulo_helice",pd.AnguloHelice );
                    comand.Parameters.AddWithValue("@angulo_pressao", pd.AnguloPressao);
                    comand.Parameters.AddWithValue("@externo",pd.Externo );
                    comand.Parameters.AddWithValue("@largura_dente", pd.LarguraDente );
                    comand.Parameters.AddWithValue("@medida_w", pd.LarguraDente);
                    comand.Parameters.AddWithValue("@id_peca", pd.ID_Peca);

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



        public bool AlterarPecaDados(Peca_Dados pd)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;


            String sql = "UPDATE peca_dados SET " +
                                                " num_dentes = @num_dentes, " +
                                                " angulo_helice = @angulo_helice, " +
                                                " angulo_pressao = @angulo_pressao," +
                                                " externo = @externo," +
                                                " modulo = @modulo," +
                                                " largura_dente = @largura_dente," +
                                                " medida_w = @medida_w " +
                                    " WHERE id = @id ";
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@num_dentes", pd.NumDentes );
                    comand.Parameters.AddWithValue("@angulo_helice", pd.AnguloHelice);
                    comand.Parameters.AddWithValue("@angulo_pressao", pd.AnguloPressao);
                    comand.Parameters.AddWithValue("@externo", pd.Externo);
                    comand.Parameters.AddWithValue("@modulo", pd.Modulo);
                    comand.Parameters.AddWithValue("@largura_dente", pd.LarguraDente);
                    comand.Parameters.AddWithValue("medida_w", pd.Medida_W);
                    comand.Parameters.AddWithValue("@id", pd.Id);

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




        public bool ExcluirPecaDados(Peca_Dados pd)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;


            String sql = "UPDATE peca_dados set " +
                                                " ativo = 0, " +
                                                " isDeletede = 1 " +
                                                " where id = @id ";
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", pd.Id);

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





        public List<Peca_Dados> ConsultaPecaDados(int ID_Peca)
        {
            Peca_Dados it = null;
            List<Peca_Dados> todos = new List<Peca_Dados>();
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "SELECT * FROM peca_dados " +

                        " WHERE id_peca = @ID_Peca and ativo = 1";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@ID_Peca", ID_Peca);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        it = new Peca_Dados();

                        it.Id = Convert.ToInt32(result["id"]);
                        it.ID_Peca = Convert.ToInt32(result["id_peca"]);
                        it.NumDentes = result["num_dentes"].Equals(DBNull.Value) ? "" : result["num_dentes"].ToString();
                        it.AnguloHelice = result["angulo_helice"].Equals(DBNull.Value) ? "" : result["angulo_helice"].ToString();
                        it.AnguloPressao = result["angulo_pressao"].Equals(DBNull.Value) ? "" : result["angulo_pressao"].ToString();
                        it.LarguraDente = result["largura_dente"].Equals(DBNull.Value) ? "" : result["largura_dente"].ToString();
                        it.Modulo = result["modulo"].Equals(DBNull.Value) ? "" : result["modulo"].ToString();
                        it.Externo = result["externo"].Equals(DBNull.Value) ? "" : result["externo"].ToString();
                        it.Medida_W = result["medida_w"].Equals(DBNull.Value) ? "" : result["medida_w"].ToString();


                        todos.Add(it);
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return todos;
        }


    }
}
