using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Image = System.Drawing.Image;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Modelo.Util
{
    public class TratarImagem
    {
        private static IConfigurationRoot configuration { get; set; }

        public TratarImagem()
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json");

            configuration = builder.Build();
        }


        public String ConverterImagemBase64(String caminho)
        {

            byte[] imageArray = System.IO.File.ReadAllBytes("./wwwroot/" +  caminho);
            string ImageBase64 = Convert.ToBase64String(imageArray);

            return ImageBase64;
        }

        public String GravarMiniatura(IFormFile img, string NomeCliente, int numNota)
        {

            NomeCliente = NomeCliente.Replace("/", "");
            NomeCliente = NomeCliente.Replace("*", "");
            NomeCliente = NomeCliente.Replace("-", " ");
            NomeCliente = NomeCliente.Replace(" ", "_");
            NomeCliente = NomeCliente.Replace("'", "");
            NomeCliente = NomeCliente.Replace("//", "");

            String caminhoInterno =  configuration["Caminho:caminhoInterno"];
            String caminhoExterno = configuration["Caminho:caminhoExterno"];
            String caminhoCompleto = caminhoInterno + caminhoExterno;

            try
            {

                if (!Directory.Exists(caminhoCompleto + NomeCliente + "/" + numNota + "/imagens/miniatura/"))
                {
                    Directory.CreateDirectory(caminhoCompleto + NomeCliente + "/" + numNota + "/imagens/miniatura/");
                }


                Image originalImage;
                originalImage = Image.FromFile(caminhoCompleto + NomeCliente + "/" + numNota + "/imagens/" + img.FileName);

                int width = 60;
                int heigth = (width * originalImage.Height) / originalImage.Width;

                Image resizedImage;
                resizedImage = originalImage.GetThumbnailImage(width, heigth, null, IntPtr.Zero);
                resizedImage.Save(caminhoCompleto + NomeCliente + "/" + numNota + "/imagens/miniatura/" + img.FileName);

                return (caminhoExterno + NomeCliente + "/" + numNota + "/imagens/miniatura/" + img.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------------" + ex.Message.ToString());

            }

            return null;
        }

       

        public String GravarImagem(IFormFile img, string NomeCliente, int numNota)
        {


            NomeCliente = NomeCliente.Replace("/", "");
            NomeCliente = NomeCliente.Replace("*", "");
            NomeCliente = NomeCliente.Replace("-", " ");
            NomeCliente = NomeCliente.Replace(" ", "_");
            NomeCliente = NomeCliente.Replace("'", "");
            NomeCliente = NomeCliente.Replace("//", "");


            String caminhoInterno = configuration["Caminho:caminhoInterno"];
            String caminhoExterno = configuration["Caminho:caminhoExterno"];
            String caminhoCompleto = caminhoInterno +  caminhoExterno ;
            try
            {
                if (!Directory.Exists(caminhoCompleto  + NomeCliente + "/" + numNota + "/imagens/"))
                {
                    Directory.CreateDirectory(caminhoCompleto + NomeCliente + "/" + numNota + "/imagens/");
                }

                using (FileStream fileStream = File.Create(caminhoCompleto  + NomeCliente + "/" + numNota + "/imagens/" + img.FileName))
                {
                    img.CopyTo(fileStream);
                    fileStream.Flush();
                    return (caminhoExterno + NomeCliente + "/" + numNota + "/imagens/"  + img.FileName);
                }
            }
            catch( Exception ex)
            {
                Console.WriteLine( "-----------------------" + ex.Message.ToString());
            }
            return null;
        }


        public string GravarCroqui(IFormFile img, int id_peca, int id_carcaca, int id_peritagem, int numNota)
        {
            String caminhoInterno = configuration["Caminho:caminhoInterno"];
            String caminhoExterno = configuration["Caminho:caminhoExterno"];
            String caminhoCompleto = caminhoInterno + caminhoExterno;
            try
            {
                if (id_peca != 0)
                {

                    if (!Directory.Exists(caminhoCompleto + id_peritagem + "/" + numNota + "/croqui/peca/" + id_peca + "/"))
                    {
                        Directory.CreateDirectory(caminhoCompleto + id_peritagem + "/" + numNota + "/croqui/peca/" + id_peca + "/");
                    }

                    using (FileStream fileStream = File.Create(caminhoCompleto + id_peritagem + "/" + numNota + "/croqui/peca/" + id_peca + "/" + img.FileName))
                    {
                        img.CopyTo(fileStream);
                        fileStream.Flush();
                        return (caminhoExterno + id_peritagem + "/" + numNota + "/croqui/peca/" + id_peca + "/" + img.FileName);
                    }
                }

                if(id_carcaca != 0)
                {
                    if (!Directory.Exists(caminhoCompleto + id_peritagem + "/" + numNota + "/croqui/carcaca/" + id_carcaca + "/"))
                    {
                        Directory.CreateDirectory(caminhoCompleto + id_peritagem + "/" + numNota + "/croqui/carcaca/" + id_carcaca + "/");
                    }

                    using (FileStream fileStream = File.Create(caminhoCompleto + id_peritagem + "/" + numNota + "/croqui/carcaca/" + id_carcaca+ "/" + img.FileName))
                    {
                        img.CopyTo(fileStream);
                        fileStream.Flush();
                        return (caminhoExterno + id_peritagem + "/" + numNota + "/croqui/carcaca/" + id_carcaca + "/" + img.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------------" + ex.Message.ToString());
            }
            return null;
        }



        public String GravarLogo(IFormFile img)
        {
            String caminhoInterno = configuration["Caminho:caminhoInterno"];
            String caminhoExterno = configuration["Caminho:caminhoExterno"];
            String caminhoCompleto =  caminhoInterno + caminhoExterno;
            try
            {
                if (!Directory.Exists(caminhoCompleto + "imagens/logo/"))
                {
                    Directory.CreateDirectory(caminhoCompleto + "imagens/logo/");
                }

                using (FileStream fileStream = File.Create(caminhoCompleto + "imagens/logo/" + img.FileName))
                {
                    img.CopyTo(fileStream);
                    fileStream.Flush();
                    return (caminhoExterno + "imagens/logo/" + img.FileName);
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }


        public int  PegarWith(string caminho)
        {
            int width = 0;
            String caminhoInterno = configuration["Caminho:caminhoInterno"];
            try
            { 
                Image originalImage;
                originalImage = Image.FromFile(caminhoInterno + caminho);
                width  = originalImage.Width;
            }
            catch (Exception ex)
            {
            }
            return width;
        }

        public int PegarHeigth(string caminho)
        {
            String caminhoInterno = configuration["Caminho:caminhoInterno"];
            int height = 0;
            try
            {
                Image originalImage;
                originalImage = Image.FromFile(caminhoInterno + caminho);
                height = originalImage.Height;
            }catch(Exception ex)
            {
            }
            return height;
        }




    }
}
