using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Util
{
    public class ConversorDeData
    {

        public String PadraoAmericano(String Data)
        {
           // if(Data == "01")

            String[] partes;

            String Dia, Mes, Ano, hora;

            partes = Data.Split("/");

            Dia = partes[0];    
            Mes = partes[1];
            Ano = partes[2].Split(" ")[0];
            hora = partes[2].Split(" ")[1];

            if( Ano == "0001")
            {
                Ano = "1900";
            }

            return (Ano + Mes + Dia + " " + hora);

        }


        public String PadraoBrasileiro(String Data)
        {
            String[] partes;

            String Dia, Mes, Ano, hora;

            partes = Data.Split("-");

            Ano = partes[0];
            Mes = partes[1];
            Dia = partes[2].Split("T")[0];
            hora = partes[2].Split("T")[1];


            return (Dia + "/" + Mes + "/" + Ano + " " + hora);

        }

        public String PegarDataHoraAtual()
        {
            String Agora = DateTime.Now.ToString();

            return Agora;
        }


    }
}
