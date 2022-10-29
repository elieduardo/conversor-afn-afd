namespace automato
{
    public class AutomatoFinitoDeterministico
    {        
        public List<List<int>> Estados { get; set; }
        public List<int> EstadoInicial { get; set; }
        public List<int> EstadoFinal { get; set; }
        public List<TransicaoFD> Transicoes {get; set;}
        
        public AutomatoFinitoDeterministico()
        {
            this.Estados = new List<List<int>>();
            this.EstadoInicial = new List<int>();
            this.EstadoFinal = new List<int>();
            this.Transicoes = new List<TransicaoFD>();            
        }
        
        public bool ExisteTransicaoPendente()
        {
            bool existeTransicaoPendente = false;

            foreach (var transicao in Transicoes)
            {
                if(!Transicoes.Any(x => x.Origem.SequenceEqual(transicao.Destino)))
                {
                    existeTransicaoPendente = true;
                };
            }

            return existeTransicaoPendente;
        }

        public bool ExisteTransicao(List<int> destino)
        {
            return Transicoes.Any(x => x.Origem.SequenceEqual(destino));
        }

        public void AceitaPalava(string palavra)
        {
            var caracteres = palavra.Split(";");
            var estadoAtivo = new List<int>();
            for (int i = 0; i < caracteres.Length; i++)
            {
                if (i == 0)
                {
                    estadoAtivo = ObterDestino(EstadoInicial, caracteres[i]);
                }
                else
                {
                    estadoAtivo = ObterDestino(estadoAtivo, caracteres[i]);

                }
            }

            Console.WriteLine(EstadoFinal.Any(x => estadoAtivo.Contains(x)) 
                ? $"Palavra {palavra} é aceita" 
                : $"Palavra {palavra} não é aceita");
        }

        public List<int> ObterDestinos(List<int> origem, List<char> caracteres)
        {
            List<int> destinos = new List<int>();

            foreach (var item in Transicoes)
            {
                if (item.Origem.Equals(origem) && item.CaracteresAceitos.Equals(caracteres))
                {
                    item.Destino.ForEach(x => destinos.Add(x));
                }
            }

            return destinos;
        }

        public List<int> ObterDestino(List<int> origem, string caractere)
        {
            List<int> destinos = new List<int>();
            if (caractere == null)
                return destinos;

            foreach (var item in Transicoes)
            {
                if (item.Origem.SequenceEqual(origem) && item.CaracteresAceitos.Contains(char.Parse(caractere)))
                {
                    item.Destino.ForEach(x => destinos.Add(x));
                }
            }

            return destinos;
        }
        public void ImprimirEstados()
        {
            Console.WriteLine("--- Estados ---");
            foreach (var item in Estados)
            {
                Console.WriteLine($"{item.ImprimirLista()} -> {ObterDestinos(item)}");
            }
        }

        public string ObterDestinos(List<int> origem)
        {
            var conexoes = "";
            foreach (var item in Transicoes)
            {
                if (item.Origem.SequenceEqual(origem))
                {
                    conexoes += item.Destino.ImprimirLista();
                    return conexoes;
                }
            }
            return conexoes;
        }

        
    }
}
