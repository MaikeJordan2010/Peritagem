using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Persistencia
{
    public class TipoPecaDAO
    {
        public List<TipoPeca> ListaTipoPeca()
        {
            List<TipoPeca> Lista = new List<TipoPeca>();
            TipoPeca tp = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from tipo_peca";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        tp = new TipoPeca();
                        tp.Id = Convert.ToInt32(result["id"]);
                        tp.Nome = result["nome"].ToString();
                        tp.Descricao = result["descricao"].ToString();
                        Lista.Add(tp);
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
