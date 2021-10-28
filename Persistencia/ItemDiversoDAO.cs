using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Modelo;
using Modelo.Util;

namespace Persistencia
{
    public class ItemDiversoDAO
    {

        public bool Inserir(ItemDiverso item)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String dt_cadastro = cdd.PadraoAmericano(DateTime.Now.ToString());


            String sql = "insert into item_diverso(" +
                                                "id," +
                                                "id_tipo, " +
                                                "descricao," +
                                                "id_disposicao," +
                                                "altura," +
                                                "largura," +
                                                "comprimento," +
                                                "dureza," +
                                                "produto," +
                                                "quantidade," +
                                                "rosca," +
                                                "id_norma," +
                                                "local_aplicado," +
                                                "modelo," +
                                                "passo," +
                                                "ruela_de_pressao_din_12," +
                                                "codigo," +
                                                "observacao," +
                                                "fabricante," +
                                                "labio," +
                                                "borracha," +
                                                "id_material," +
                                                "l1," +
                                                "l2," +
                                                "l3," +
                                                "marca," +
                                                "id_peritagem," +
                                                "classe," +
                                                "usuario_criador," +
                                                "dt_cadastro," +
                                                "dimensao," +
                                                "peso," +
                                                "medidas," +
                                                "ativo," +
                                                "isDeletede"+

                                      ")values(" +
                                                "next value for sequence_item_diverso," +
                                                "@id_tipo, " +
                                                "@descricao," +
                                                "@id_disposicao," +
                                                "@altura," +
                                                "@largura," +
                                                "@comprimento," +
                                                "@dureza," +
                                                "@produto," +
                                                "@quantidade," +
                                                "@rosca," +
                                                "@id_norma," +
                                                "@local_aplicado," +
                                                "@modelo," +
                                                "@passo," +
                                                "@ruela_de_pressao_din_12," +
                                                "@codigo," +
                                                "@observacao," +
                                                "@fabricante," +
                                                "@labio," +
                                                "@borracha," +
                                                "@id_material," +
                                                "@l1," +
                                                "@l2," +
                                                "@l3," +
                                                "@marca," +
                                                "@id_peritagem," +
                                                "@classe," +
                                                "@usuario_criador," +
                                                "@dt_cadastro," +
                                                "@dimensao," +
                                                "@peso," +
                                                "@medidas," +
                                                "1," +
                                                "0" +
                                                ") ";
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_tipo", item.TipoItem.Id);
                    comand.Parameters.AddWithValue("@descricao", item.Descricao);
                    comand.Parameters.AddWithValue("@id_disposicao", item.Disposicao.ID_Disposicao);
                    comand.Parameters.AddWithValue("@altura", item.Altura);
                    comand.Parameters.AddWithValue("@largura", item.Largura);
                    comand.Parameters.AddWithValue("@comprimento", item.Comprimento);
                    comand.Parameters.AddWithValue("@dureza", item.Dureza);
                    comand.Parameters.AddWithValue("@produto", item.Produto);
                    comand.Parameters.AddWithValue("@quantidade", item.Quantidade);
                    comand.Parameters.AddWithValue("@rosca", item.Rosca);
                    comand.Parameters.AddWithValue("@id_norma", item.Norma.Id);
                    comand.Parameters.AddWithValue("@local_aplicado", item.LocalAplicado);
                    comand.Parameters.AddWithValue("@modelo", item.Modelo);
                    comand.Parameters.AddWithValue("@passo", item.Passo);
                    comand.Parameters.AddWithValue("@ruela_de_pressao_din_12", item.RuelaDePressaDin12);
                    comand.Parameters.AddWithValue("@codigo", item.Codigo);
                    comand.Parameters.AddWithValue("@observacao", item.Observacao);
                    comand.Parameters.AddWithValue("@fabricante", item.Fabricante);
                    comand.Parameters.AddWithValue("@labio", item.Labio);
                    comand.Parameters.AddWithValue("@borracha", item.Borracha);
                    comand.Parameters.AddWithValue("@id_material", item.Material.Id);
                    comand.Parameters.AddWithValue("@l1", item.L1);
                    comand.Parameters.AddWithValue("@l2", item.L2);
                    comand.Parameters.AddWithValue("@l3", item.L3);
                    comand.Parameters.AddWithValue("@marca", item.Marca);
                    comand.Parameters.AddWithValue("@id_peritagem", item.ID_Peritagem);
                    comand.Parameters.AddWithValue("@classe", item.Classe);
                    comand.Parameters.AddWithValue("@usuario_criador", item.UsuarioCriador.Id);
                    comand.Parameters.AddWithValue("@dt_cadastro", dt_cadastro);
                    comand.Parameters.AddWithValue("@dimensao", item.Dimensao);
                    comand.Parameters.AddWithValue("@peso", item.Peso);
                    comand.Parameters.AddWithValue("@medidas", item.Medidas);
                    comand.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------" + ex.ToString());
            }
            conn.Close();
            return false;
            //return "inserido";
        }

        public bool ExcluirItemDiverso(ItemDiverso item)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String sql = " update item_diverso set " +
                                     " ativo = 0, " +
                                     " isDeletede = 1 " +
                        " where id = @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id", item.Id);

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


        public bool Alterar(ItemDiverso item)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            ConversorDeData cdd = new ConversorDeData();
            String dt_cadastro = cdd.PadraoAmericano(DateTime.Now.ToString());


            String sql = " update item_diverso set " +
                                                " descricao = @descricao," +
                                                " id_disposicao = @id_disposicao," +
                                                " altura = @altura," +
                                                " largura = @largura," +
                                                " comprimento = @comprimento," +
                                                " dureza = @dureza," +
                                                " produto = @produto," +
                                                " quantidade = @quantidade," +
                                                " rosca = @rosca," +
                                                " id_norma = @id_norma," +
                                                " local_aplicado = @local_aplicado," +
                                                " modelo = @modelo," +
                                                " passo = @passo," +
                                                " ruela_de_pressao_din_12 = @ruela_de_pressao_din_12," +
                                                " codigo = @codigo," +
                                                " observacao = @observacao," +
                                                " fabricante = @fabricante," +
                                                " labio = @labio," +
                                                " borracha = @borracha," +
                                                " id_material = @id_material," +
                                                " l1 = @l1," +
                                                " l2 = @l2," +
                                                " l3 = @l3," +
                                                " marca = @marca," +
                                                " classe = @classe," +
                                                " dimensao = @dimensao," +
                                                " peso = @peso," +
                                                " medidas = @medidas " +
                                     "  where id = @id_item ";
                                               
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@descricao", item.Descricao);
                    comand.Parameters.AddWithValue("@id_disposicao", item.Disposicao.ID_Disposicao);
                    comand.Parameters.AddWithValue("@altura", item.Altura);
                    comand.Parameters.AddWithValue("@largura", item.Largura);
                    comand.Parameters.AddWithValue("@comprimento", item.Comprimento);
                    comand.Parameters.AddWithValue("@dureza", item.Dureza);
                    comand.Parameters.AddWithValue("@produto", item.Produto);
                    comand.Parameters.AddWithValue("@quantidade", item.Quantidade);
                    comand.Parameters.AddWithValue("@rosca", item.Rosca);
                    comand.Parameters.AddWithValue("@id_norma", item.Norma.Id);
                    comand.Parameters.AddWithValue("@local_aplicado", item.LocalAplicado);
                    comand.Parameters.AddWithValue("@modelo", item.Modelo);
                    comand.Parameters.AddWithValue("@passo", item.Passo);
                    comand.Parameters.AddWithValue("@ruela_de_pressao_din_12", item.RuelaDePressaDin12);
                    comand.Parameters.AddWithValue("@codigo", item.Codigo);
                    comand.Parameters.AddWithValue("@observacao", item.Observacao);
                    comand.Parameters.AddWithValue("@fabricante", item.Fabricante);
                    comand.Parameters.AddWithValue("@labio", item.Labio);
                    comand.Parameters.AddWithValue("@borracha", item.Borracha);
                    comand.Parameters.AddWithValue("@id_material", item.Material.Id);
                    comand.Parameters.AddWithValue("@l1", item.L1);
                    comand.Parameters.AddWithValue("@l2", item.L2);
                    comand.Parameters.AddWithValue("@l3", item.L3);
                    comand.Parameters.AddWithValue("@marca", item.Marca);
                    comand.Parameters.AddWithValue("@classe", item.Classe);
                    comand.Parameters.AddWithValue("@dimensao", item.Dimensao);
                    comand.Parameters.AddWithValue("@peso", item.Peso);
                    comand.Parameters.AddWithValue("@medidas", item.Medidas);
                    comand.Parameters.AddWithValue("@id_item", item.Id);

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



        public List<ItemDiverso> ConsultaTodos(ItemDiverso item)
        {
            List<ItemDiverso> ListaItem = new List<ItemDiverso>();
            ItemDiverso it = null;
            Disposicao dis = null;
            TipoItem tipo = null;
            Material mat = null;
            Norma nor = null;

            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql =" select *, " +
                            " d.nome as d_nome, d.id_disposicao as d_id_disposicao, " +
                            " t.id as t_id, t.nome as t_nome, " +
                            " m.nome as m_nome, m.id as m_id, " +
                            " n.nome as n_nome, n.id as n_id " +

                    " from item_diverso as i " +

                        " inner join disposicao as d " +
                        " on i.id_disposicao = d.id_disposicao " +

                        " inner join tipo_item as t " +
                        " on i.id_tipo = t.id " +

                        " inner join material as m " +
                        " on i.id_material = m.id " +
                        
                        " inner join norma as n " +
                        " on i.id_norma = n.id  " +
                    " where i.id_peritagem = @id_peritagem and i.ativo = 1 " +
                    " order by i.dt_cadastro desc";
                        
            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_peritagem",item.ID_Peritagem);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        it = new ItemDiverso();
                        dis = new Disposicao();
                        tipo = new TipoItem();
                        nor = new Norma();
                        mat = new Material();

                        it.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        it.Id = Convert.ToInt32(result["id"]);
                        it.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        it.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        it.Altura = result["altura"].Equals(DBNull.Value) ? "" : result["altura"].ToString();
                        it.Largura = result["largura"].Equals(DBNull.Value) ? "" : result["largura"].ToString();
                        it.Comprimento = result["comprimento"].Equals(DBNull.Value) ? "" : result["comprimento"].ToString();
                        it.Fabricante= result["fabricante"].Equals(DBNull.Value) ? "" : result["fabricante"].ToString();
                        it.Borracha = result["borracha"].Equals(DBNull.Value) ? "" : result["borracha"].ToString();
                        it.Dureza = result["dureza"].Equals(DBNull.Value) ? "" : result["dureza"].ToString();
                        it.Codigo = result["codigo"].Equals(DBNull.Value) ? "" : result["codigo"].ToString();
                        it.L1 = result["l1"].Equals(DBNull.Value) ? "" : result["l1"].ToString();
                        it.L2 = result["l2"].Equals(DBNull.Value) ? "" : result["l2"].ToString();
                        it.L3 = result["l3"].Equals(DBNull.Value) ? "" : result["l3"].ToString();
                        it.Modelo = result["modelo"].Equals(DBNull.Value) ? "" : result["modelo"].ToString();
                        it.Observacao = result["observacao"].Equals(DBNull.Value) ? "" : result["observacao"].ToString();
                        it.Passo = result["passo"].Equals(DBNull.Value) ? "" : result["passo"].ToString();
                        it.Produto = result["produto"].Equals(DBNull.Value) ? "" : result["produto"].ToString();
                        it.Quantidade = Convert.ToInt32(result["quantidade"]);
                        it.Rosca = result["rosca"].Equals(DBNull.Value) ? "" : result["rosca"].ToString();
                        it.RuelaDePressaDin12 = Convert.ToBoolean(result["ruela_de_pressao_din_12"]);
                        it.Dt_Cadastro = result["dt_cadastro"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_cadastro"]);
                        it.Dimensao = result["dimensao"].Equals(DBNull.Value) ? "" : result["dimensao"].ToString();
                        it.LocalAplicado  = result["local_aplicado"].Equals(DBNull.Value) ? "" : result["local_aplicado"].ToString();
                        it.Peso = result["peso"].Equals(DBNull.Value) ? "" :result["peso"].ToString();
                        it.Medidas = result["medidas"].Equals(DBNull.Value) ? "" : result["medidas"].ToString();
                        it.Capa = result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();
                        it.Labio = result["labio"].Equals(DBNull.Value) ? "" : result["labio"].ToString();
                        it.Marca = result["marca"].Equals(DBNull.Value) ? "" : result["marca"].ToString();
                        
                        it.Classe = result["classe"].Equals(DBNull.Value) ? "" : result["classe"].ToString();

                        nor.Nome = result["n_nome"].Equals(DBNull.Value) ? "" : result["n_nome"].ToString();
                        nor.Id = Convert.ToInt32(result["n_id"]);

                        mat.Nome = result["m_nome"].Equals(DBNull.Value) ? "" : result["m_nome"].ToString();
                        mat.Id = Convert.ToInt32(result["m_id"]);

                        dis.ID_Disposicao = Convert.ToInt32(result["d_id_disposicao"]);
                        dis.Nome = result["d_nome"].Equals(DBNull.Value) ? "" : result["d_nome"].ToString();

                        
                        tipo.Id = Convert.ToInt32(result["t_id"]);
                        tipo.Nome = result["t_nome"].Equals(DBNull.Value) ? "" : result["t_nome"].ToString();

                        it.Disposicao = dis;
                        it.Material = mat;
                        it.Norma = nor;

                        it.TipoItem = tipo;

                        ListaItem.Add(it);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("------------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return ListaItem;
        }


        public ItemDiverso ConsultaUm(int ID_Item)
        {
            ItemDiverso it = null;
            Disposicao dis = null;
            TipoItem tipo = null;
            Material mat = null;
            Norma nor = null;

            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = " select *, " +
                            " d.nome as d_nome, d.id_disposicao as d_id_disposicao, " +
                            " t.id as t_id, t.nome as t_nome, " +
                            " m.nome as m_nome, m.id as m_id, " +
                            " n.nome as n_nome, n.id as n_id " +

                    " from Item_diverso as i " +

                        " inner join disposicao as d " +
                        " on i.id_disposicao = d.id_disposicao " +

                        " inner join tipo_item as t " +
                        " on i.id_tipo = t.id " +
                        
                        " inner join material as m " +
                        " on i.id_material = m.id " +


                        " inner join norma as n " +
                        " on i.id_norma = n.id" +
                    " where i.id = @id_item";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@id_item", ID_Item);
                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        it = new ItemDiverso();
                        dis = new Disposicao();
                        tipo = new TipoItem();
                        nor = new Norma();
                        mat = new Material();

                        it.Nome = result["nome"].Equals(DBNull.Value) ? "" : result["nome"].ToString();
                        it.Id = Convert.ToInt32(result["id"]);
                        it.Descricao = result["descricao"].Equals(DBNull.Value) ? "" : result["descricao"].ToString();
                        it.ID_Peritagem = Convert.ToInt32(result["id_peritagem"]);
                        it.Altura = result["altura"].Equals(DBNull.Value) ? "" : result["altura"].ToString();
                        it.Largura = result["largura"].Equals(DBNull.Value) ? "" : result["largura"].ToString();
                        it.Comprimento = result["comprimento"].Equals(DBNull.Value) ? "" : result["comprimento"].ToString();
                        it.Fabricante = result["fabricante"].Equals(DBNull.Value) ? "" : result["fabricante"].ToString();
                        it.Borracha = result["borracha"].Equals(DBNull.Value) ? "" : result["borracha"].ToString();
                        it.Dureza = result["dureza"].Equals(DBNull.Value) ? "" : result["dureza"].ToString();
                        it.Codigo = result["codigo"].Equals(DBNull.Value) ? "" : result["codigo"].ToString();
                        it.L1 = result["l1"].Equals(DBNull.Value) ? "" : result["l1"].ToString();
                        it.L2 = result["l2"].Equals(DBNull.Value) ? "" : result["l2"].ToString();
                        it.L3 = result["l3"].Equals(DBNull.Value) ? "" : result["l3"].ToString();
                        it.Modelo = result["modelo"].Equals(DBNull.Value) ? "" : result["modelo"].ToString();
                        it.Observacao = result["observacao"].Equals(DBNull.Value) ? "" : result["observacao"].ToString();
                        it.Passo = result["passo"].Equals(DBNull.Value) ? "" : result["passo"].ToString();
                        it.Produto = result["produto"].Equals(DBNull.Value) ? "" : result["produto"].ToString();
                        it.Quantidade = Convert.ToInt32(result["quantidade"]);
                        it.Rosca = result["rosca"].Equals(DBNull.Value) ? "" : result["rosca"].ToString();
                        it.RuelaDePressaDin12 = Convert.ToBoolean(result["ruela_de_pressao_din_12"]);
                        it.Dt_Cadastro = result["dt_cadastro"].Equals(DBNull.Value) ? Convert.ToDateTime("0001-01-01 00:00:00") : Convert.ToDateTime(result["dt_cadastro"]);
                        it.Dimensao = result["dimensao"].Equals(DBNull.Value) ? "" : result["dimensao"].ToString();
                        it.LocalAplicado = result["local_aplicado"].Equals(DBNull.Value) ? "" : result["local_aplicado"].ToString();
                        it.Peso = result["peso"].Equals(DBNull.Value) ? "" : result["peso"].ToString();
                        it.Medidas = result["medidas"].Equals(DBNull.Value) ? "" : result["medidas"].ToString();
                        it.Marca = result["marca"].Equals(DBNull.Value) ? "" : result["marca"].ToString();
                        it.Capa = result["capa"].Equals(DBNull.Value) ? "" : result["capa"].ToString();
                        it.Labio = result["labio"].Equals(DBNull.Value) ? "" : result["labio"].ToString();

                        it.Classe = result["classe"].Equals(DBNull.Value) ? "" : result["classe"].ToString();

                        nor.Nome = result["n_nome"].Equals(DBNull.Value) ? "" : result["n_nome"].ToString();
                        nor.Id = Convert.ToInt32(result["n_id"]);

                        mat.Nome = result["m_nome"].Equals(DBNull.Value) ? "" : result["m_nome"].ToString();
                        mat.Id = Convert.ToInt32(result["m_id"]);

                        dis.ID_Disposicao = Convert.ToInt32(result["d_id_disposicao"]);
                        dis.Nome = result["d_nome"].Equals(DBNull.Value) ? "" : result["d_nome"].ToString();
                        
                        tipo.Id = Convert.ToInt32(result["t_id"]);
                        tipo.Nome = result["t_nome"].Equals(DBNull.Value) ? "" : result["t_nome"].ToString();

                        it.Disposicao = dis;
                        it.Material = mat;
                        it.Norma = nor;

                        it.TipoItem = tipo;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("------------------------------" + ex.Message.ToString());
            }
            conn.Close();
            return it;
        }


        public bool AlterarCapa(int ID_ItemDiverso, string Capa)
        {
            SqlConnection conn = null;
            SqlCommand comand = null;
            String sql = "update item_diverso set capa = @capa where id= @id ";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();

                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);
                    comand.Parameters.AddWithValue("@capa", Capa);
                    comand.Parameters.AddWithValue("@id", ID_ItemDiverso);

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
