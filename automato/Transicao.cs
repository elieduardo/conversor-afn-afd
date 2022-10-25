using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automato
{
    public class Transicao
    {
        public Transicao(int estadoOrigem, int estadoDestino, List<char> caracteresAceitos)
        {
            this.estadoOrigem = estadoOrigem;
            this.estadoDestino = estadoDestino;
            this.caracteresAceitos = caracteresAceitos;
        }
        public int estadoOrigem { get; set; }
        public int estadoDestino { get; set; }
        List<Char> caracteresAceitos { get; set; }
    }
}
