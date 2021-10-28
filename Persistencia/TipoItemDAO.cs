using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Persistencia
{
    public class TipoItemDAO
    {
        public List<TipoItem> ListaTipoItem()
        {
            List<TipoItem> Lista = new List<TipoItem>();
            TipoItem to = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from tipo_item";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        to = new TipoItem();
                        to.Id = Convert.ToInt32(result["id"]);
                        to.Nome = result["nome"].ToString();
                        to.Especifico = Convert.ToBoolean(result["especifico"]);
                        Lista.Add(to);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            return Lista;
        }
    }
}
