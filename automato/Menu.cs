using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automato
{
    public class Menu
    {
        public void InicarAplicacao()
        {
            using (StreamReader sr = new StreamReader("../../../Data/data.json"))
            {
                string json = sr.ReadToEnd();
                var automato = JsonConvert.DeserializeObject<Automato>(json);

                Console.WriteLine(automato?.ToString());
            }
        }

    }
}
