using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.Conexao
{
    public class Conexao
    {
        private string server = "";
        private string database = "";
        private string user = "";
        private string senha = "";

        public Conexao(string _database)
        {
            database = _database;
        }

        public Conexao()
        {
        }


        private static IConfigurationRoot configuration { get; set; }

        public SqlConnection abrirConexao()
        {

            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json");

            configuration = builder.Build();

            server = configuration["ConnectionStrings:server"];
            user = configuration["ConnectionStrings:Uid"];
            senha = configuration["ConnectionStrings:pwd"];

            if (database == "")
            {
                database = configuration["ConnectionStrings:database"];
            }


            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("server=" + server + ";database =" + database + ";Uid=" + user + ";pwd=" + senha);
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível se conectar ao banco de dados!");
            }
           
            return conn;
        }
    }
}
