using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automato
{
    public static class Extensions
    {
        public static string ImprimirLista<T>(this List<T> lista)
        {
            var valor = "";
            foreach (var item in lista)
            {
                valor += $"{item},";
            }
            return valor;
        }
    }
}
