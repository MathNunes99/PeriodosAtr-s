using System;

namespace PeriodosAtrás.ConsoleApp1
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            Data data = new Data();
            data.memorias = new Memoria[10];
            Memoria memoria = new Memoria();
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
                    data.EscreveDatas();                    
                    continue;
                }                
                data.EscreveResultado();
                Console.Clear();
                data.ArmazenaNaMemoria();

            }
        }        
    }
}
