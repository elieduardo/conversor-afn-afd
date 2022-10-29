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

            int opcao;
            string palavra;

            //inicia AutomatoNaoDeterministico e realiza leitura do arquivo
            var AutomatoNaoDeterministico = new AutomatoNaoDeterministico();
            AutomatoNaoDeterministico = AutomatoNaoDeterministico.LerArquivo();

            //inicia o AutomatoFinitoDeterministico a partir do AutomatoNaoDeterministico
            var AutomatoFinitoDeterministico = AutomatoNaoDeterministico?.ConverterParaAFD();

            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("-------------- Conversor AFN para AFD ----------------");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("1 - Imprimir estados AFN");
                Console.WriteLine("2 - Imprimir estados AFD");
                Console.WriteLine("3 - Conferir se palavra é aceita pelo AFN");
                Console.WriteLine("4 - Conferir se palavra é aceita pelo AFD");
                Console.WriteLine("0 - Sair");

                while (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Digite uma opçao válida");
                }

                switch (opcao)
                {
                    case 1:
                        AutomatoNaoDeterministico?.ImprimirEstados();
                        break;
                    case 2:
                        AutomatoFinitoDeterministico?.ImprimirEstados();
                        break;
                    case 3:                        
                        palavra = Console.ReadLine();
                        if(palavra != null)
                        {
                            AutomatoNaoDeterministico?.AceitaPalava(palavra);
                        }
                        break;
                    case 4:
                        palavra = Console.ReadLine();
                        if (palavra != null)
                        {                            
                            AutomatoFinitoDeterministico?.AceitaPalava(palavra);
                        }
                        break;
                    case 0:                        
                        break;
                    default:
                        Console.WriteLine("Método não implementado");
                        break;
                }

                Console.WriteLine("Pressione uma tecla para continua ...");
                Console.ReadLine();

            } while (opcao != 0);           
        }
    }
}
