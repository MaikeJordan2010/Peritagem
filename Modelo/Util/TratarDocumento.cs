using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Modelo.Util
{
    public class TratarDocumento
    {
        private static IConfigurationRoot configuration { get; set; }

        public TratarDocumento()
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json");

            configuration = builder.Build();
        }

        public String GravarDocumento(IFormFile Documento, string NomeCliente, int ID_Peca, int numNota)
        {

            NomeCliente = NomeCliente.Replace("/", "");
            NomeCliente = NomeCliente.Replace("*", "");
            NomeCliente = NomeCliente.Replace("-", " ");
            NomeCliente = NomeCliente.Replace(" ", "_");
            NomeCliente = NomeCliente.Replace("'", "");
            NomeCliente = NomeCliente.Replace("//", "");




            String caminho = "";

            if (ID_Peca == 0)
            {
                caminho = configuration["Caminho:caminhoExterno"] + NomeCliente + "/" + numNota + "/documento/";

            }
            else{
                caminho = configuration["Caminho:caminhoExterno"] + NomeCliente + "/" + numNota +  "/documento/" + ID_Peca + "/";

            }
            String caminhoCompleto = configuration["Caminho:caminhoInterno"];

            try
            {

                if (!Directory.Exists(caminhoCompleto + caminho))
                {
                    Directory.CreateDirectory(caminhoCompleto + caminho);
                }


                using (FileStream fileStream = File.Create(caminhoCompleto + caminho + Documento.FileName))
                {

                    Documento.CopyTo(fileStream);
                    fileStream.Flush();
                    return (caminho + Documento.FileName);
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            return null;
        }
    }
}
