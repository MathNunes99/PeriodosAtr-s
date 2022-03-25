using System;

namespace PeriodosAtrás.ConsoleApp1
{
    internal class Program
    {        
        static void Main()
        {
            Data data = new();
            data.memorias = new Memoria[10];
            
            string opcao = "";
            while (opcao != "sair")
            {
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("'ENTER' para continuar ou 'SAIR' para encerrar o programa");
                Console.WriteLine("'VER' para mostrar resultados anteriores");
                Console.WriteLine("-------------------------------------------------------");
                opcao = Console.ReadLine();
                if (opcao == "sair")
                {
                    break;
                }
                else if (opcao == "ver")
                {
                    data.VerDatas();                    
                    continue;
                }                
                data.EscreveResultado();
                Console.Clear();
                data.ArmazenaNaMemoria();

            }
        }        
    }
}
