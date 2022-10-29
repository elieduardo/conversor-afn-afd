using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automato
{
    public class TransicaoFD
    {
        public List<int> Origem { get; set; }
        public List<int> Destino { get; set; }
        public List<char> CaracteresAceitos { get; set; }
        public TransicaoFD(List<int> origem, List<int> destino, List<char> caracteresAceitos)
        {
            Origem = origem;
            Destino = destino;
            CaracteresAceitos = caracteresAceitos;
        }

    }
}
