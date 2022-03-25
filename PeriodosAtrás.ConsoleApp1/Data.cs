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

            if (dias == 0)
            {               
                    TimeSpan diferenca = DateTime.UtcNow.AddHours(-3) - Convert.ToDateTime(dataDigitada);
                resultado = diferenca.Hours + " Horas atrás";
                return resultado;
            }
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
            string convertido;
            
            
            if (ano > 0)
            {
                convertido = RetornaString(ano);
                resultado = convertido + " Anos atrás";
                if (mes > 0)
                {
                    convertido = RetornaString(mes);
                    resultado += " e " + convertido + " Meses";
                }
            }
            else if (mes > 0)
            {
                convertido = RetornaString(mes);
                resultado = convertido + " Meses atrás";
                if (semana > 0)
                {
                    convertido = RetornaString(semana);
                    resultado += " e " + convertido + " Semanas";
                }
            }
            else if (semana > 0)
            {
                convertido = RetornaString(semana);
                resultado = convertido + " Semanas atrás";
                if (diasCont > 0)
                {
                    convertido = RetornaString(diasCont);
                    resultado += " e " + convertido + " Dias";
                }
            }           
            else if(diasCont < 7)
            {
                convertido = RetornaString(diasCont);
                resultado = convertido + " Dias atrás";
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
        public string RetornaString(int conversor)
        {
            string converterString = "";            
            switch (conversor)
            {
                case 1:
                    converterString = "Um";
                    break;
                case 2:
                    converterString = "Dois";
                    break;
                case 3:
                    converterString = "Três";
                    break;
                case 4:
                    converterString = "Quatro";
                    break;
                case 5:
                    converterString = "Cinco";
                    break;
                case 6:
                    converterString = "Seis";
                    break;
                case 7:
                    converterString = "Sete";
                    break;
                case 8:
                    converterString = "Oito";
                    break;
                case 9:
                    converterString = "Nove";
                    break;
                case 10:
                    converterString = "Dez";
                    break;
            }
            return converterString;
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
