using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Persistencia.Conexao;
using Modelo;

namespace Persistencia
{
    public class DisposicaoDAO
    {
        public List<Disposicao> ListaDisposicao()
        {
            List<Disposicao> Lista = new List<Disposicao>();
            Disposicao dis = null;
            SqlConnection conn = null;
            SqlCommand comand = null;
            SqlDataReader result = null;
            String sql = "select * from disposicao";

            try
            {
                conn = new Conexao.Conexao().abrirConexao();
                if (conn != null)
                {
                    comand = new SqlCommand(sql, conn);

                    result = comand.ExecuteReader();

                    while (result.Read())
                    {
                        dis = new Disposicao();
                        dis.ID_Disposicao = Convert.ToInt32(result["id_disposicao"]);
                        dis.Nome = result["nome"].ToString();
                        Lista.Add(dis);
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
