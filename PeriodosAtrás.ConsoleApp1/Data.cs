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
            resultado = ResultadoFinal();

            Console.WriteLine(resultado);
            Console.ReadLine();

        }
        private string ResultadoFinal()
        {
            string resultado = "";
            int dias = CalculaResposta();
            int diasCont = 0;
            int semana = 0;
            int mes = 0;
            int ano = 0;
            while (dias > 0)
            {
                if (dias >= 365)
                {
                    ano += 1;
                    dias -= 365;
                }
                else if (dias >= 30)
                {
                    mes += 1;
                    dias -= 30;
                }
                else if (dias >= 7)
                {
                    semana += 1;
                    dias -= 7;
                }
                else if (dias > 0)
                {
                    diasCont++;
                    dias--;
                }                
            }

            if (ano > 0)
            {
                resultado = ano + " Anos";
            }
            else if (mes > 0)
            {
                resultado = mes + " meses Atrás";
            }
            else if (semana > 0)
            {
                resultado = semana + " semanas Atrás";                
            }           
            else if(diasCont < 7)
            {
                resultado = diasCont + " Dias Atrás";
            }

            return resultado;
        }
        public void ArmazenaNaMemoria()
        {
            Memoria armazenador = new();

            armazenador.armazenamento = dataDigitada + " -> " + resultado;
            int posicaoVazia = PosicaoVazia();
            memorias[posicaoVazia] = armazenador;
            
        }
        public int PosicaoVazia()
        {
            int posicaoVazia;
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
        public void VerDatas()
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
