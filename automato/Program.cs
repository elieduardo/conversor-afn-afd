using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace automato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.InicarAplicacao();
        }
    }
}