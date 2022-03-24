using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodosAtrás.ConsoleApp1
{
    internal class Data
    {
        public string dataDigitada, resultado;
        public Memoria[] memorias;

        public void RecebeData()
        {   
            Console.Write("Escreva a Data desejada no formato -> dd/mm/aaaa:  ");
            dataDigitada = Console.ReadLine();
            Convert.ToDateTime(dataDigitada);                        
        }
        public int CalculaResposta()
        {
            TimeSpan diferenca = DateTime.Today - Convert.ToDateTime(dataDigitada);            

            return diferenca.Days;
        }
        public void EscreveResultado()
        {
            
            Console.Clear();
            RecebeData();            
            int resposta = CalculaResposta();

            Console.WriteLine(resposta + " Dias Atrás");
            resultado = resposta + " Dias Atrás";
            Console.ReadLine();
        }        
        public void ArmazenaNaMemoria()
        {             
            Memoria armazenador = new Memoria();
            armazenador.armazenamento = dataDigitada + " -> " + resultado;
            int posicaoVazia = PosicaoVazia();
            memorias[posicaoVazia] = armazenador;
            
        }
        public int PosicaoVazia()
        {
            int posicaoVazia = 0;
            for (int i = 0; i < memorias.Length; i++)
            {
                if (memorias[i] == null)
                {
                    posicaoVazia = i;
                    return posicaoVazia;
                }
            }
            return -1;
        }
        public void EscreveDatas()
        {
            Console.Clear();
            for (int i = 0; i < memorias.Length; i++)
            {
                if(memorias[i] != null)
                Console.WriteLine(memorias[i].armazenamento);

            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
