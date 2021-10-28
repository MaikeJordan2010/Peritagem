using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Util
{
    public class ConverterGeral
    {
        public float ConverterStringFloat(string valor)
        {
            if (valor != null)
            {
                valor = valor.Replace(".", "");
                valor = valor.Replace(",", ".");

                float v = Convert.ToSingle(valor);
                return v;
            }

            return Convert.ToSingle("0");
        }
    }
}
