using Newtonsoft.Json;

namespace automato
{
    public class AutomatoNaoDeterministico
    {        
        public List<int> Estados { get; set; }
        public List<int> EstadoInicial { get; set; }
        public int EstadoFinal { get; set; }
        public List<Transicao> Transicoes {get; set;}

        public AutomatoNaoDeterministico()
        {
            this.Estados = new List<int>();
            this.EstadoInicial = new List<int>();
            this.Transicoes = new List<Transicao>();
        }

        public AutomatoNaoDeterministico LerArquivo()
        {
            using (StreamReader sr = new StreamReader("../../../Data/data.json"))
            {
                string json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<AutomatoNaoDeterministico>(json) ?? new AutomatoNaoDeterministico();
            }
        }

        public AutomatoFinitoDeterministico ConverterParaAFD()
        {
            var caracteres = CaracteresAceitos();
            var automatoAFD = new AutomatoFinitoDeterministico();
            var destinosVisitados = EstadoInicial;
            automatoAFD.EstadoInicial = EstadoInicial;
            automatoAFD.EstadoFinal.Add(EstadoFinal);

            foreach (var item in caracteres)
            {
                var destinos = new List<int>();

                EstadoInicial.ForEach(x => destinos = ObterDestinos(x, item.ToString()));

                var teste = new List<char>();
                teste.Add(item);
                
                automatoAFD.Transicoes.Add(new TransicaoFD(EstadoInicial, destinos, teste));
                automatoAFD.Estados.Add(destinos);
            }

            AdicionarTransicoesAFD(caracteres, automatoAFD);

            return automatoAFD;
        }

        private void AdicionarTransicoesAFD(List<char> caracteres, AutomatoFinitoDeterministico automatoFD)
        {
            foreach (var item in automatoFD.Transicoes.ToList())
            {
                if (!automatoFD.ExisteTransicao(item.Destino))
                {
                    foreach (var caractere in caracteres)
                    {
                        var destinos = new List<int>();
                        var teste = new List<char>();
                        teste.Add(caractere);

                        foreach (var destino in item.Destino)
                        {
                            var novosDestinos = ObterDestinos(destino, caractere.ToString());
                            foreach (var d in novosDestinos)
                            {
                                if (!destinos.Contains(d))
                                {
                                    destinos.AddRange(novosDestinos);                         
                                }
                            }
                        }
                        if (!automatoFD.Estados.Any(x => x.SequenceEqual(destinos)))
                        {
                            automatoFD.Estados.Add(destinos);

                        }
                        automatoFD.Transicoes.Add(new TransicaoFD(item.Destino, destinos, teste));
                    }
                }
            }
            if (automatoFD.ExisteTransicaoPendente())
            {
                AdicionarTransicoesAFD(caracteres, automatoFD);
            }
        }

        public void AceitaPalava(string palavra)
        {
            var caracteres = palavra.Split(";");
            var estadosAtivos = new List<int>();
            for (int i = 0; i < caracteres.Length; i++)
            {
                if(i == 0)
                {
                    EstadoInicial.ForEach(x => estadosAtivos.AddRange(ObterDestinos(x, caracteres[0])));
                }
                else
                {
                    var novosEstados = new List<int>();

                    foreach (var item in estadosAtivos)
                    {
                        novosEstados.AddRange(ObterDestinos(item, caracteres[i]));
                    }

                    estadosAtivos = novosEstados;
                }
            }
            Console.WriteLine(estadosAtivos.Contains(EstadoFinal) 
                ? $"Palavra {palavra} é aceita" 
                : $"Palavra {palavra} não é aceita");
            
        }

        public void ImprimirEstados()
        {
            Console.WriteLine("--- Estados ---");
            foreach (var item in Estados)
            {
                Console.WriteLine($"{item} -> {ObterDestinos(item)}");
            }
        }

        public List<int> ObterDestinos(int origem, string caractere)
        {
            List<int> destinos = new List<int>();

            if (caractere == "")
                return destinos;

            foreach (var item in Transicoes)
            {
                if (item.Origem.Equals(origem) && item.CaracteresAceitos.Contains(char.Parse(caractere)))
                {
                    item.Destino.ForEach(x => destinos.Add(x));
                }                    
            }

            return destinos;
        }

        public string ObterDestinos(int origem)
        {
            var conexoes = "";
            foreach (var item in Transicoes)
            {
                if (item.Origem.Equals(origem))
                    conexoes += item.Destino.ImprimirLista();
            }
            return conexoes;
        }

        public List<char> CaracteresAceitos()
        {
            List<char> caracteres =  new List<char>();
            foreach (var item in Transicoes)
            {
                foreach (var caractere in item.CaracteresAceitos)
                {
                    if(!caracteres.Contains(caractere))
                        caracteres.Add(caractere);
                }
            }
            return caracteres;
        }
    }
}
