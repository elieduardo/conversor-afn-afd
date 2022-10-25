using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automato
{
    public class Automato
    {        
        public List<int> estados { get; set; }
        public int estadoInicial { get; set; }
        public int estadoFinal { get; set; }
        public List<Transicao> transicoes {get; set;}

        public Automato(List<int> estados, int estadoInicial, int estadoFinal, List<Transicao> transicoes)
        {
            this.estados = estados;
            this.estadoInicial = estadoInicial;
            this.estadoFinal = estadoFinal;
            this.transicoes = transicoes;
        }
        
        public Automato()
        {

        }

    }
}
