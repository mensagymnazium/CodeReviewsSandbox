using System;
using System.Text;
using System.Linq;

namespace RPN
{
    class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("Zadej výraz: ");
            var exp = Console.ReadLine();

            Console.WriteLine("Zpracovávám výraz: " + exp);
            Console.WriteLine("Převádím do pole");
            string[] exps = exp.Split(" ");
            Console.WriteLine("Zpracováno do pole o délce: " + exps.Length);

            int[] hodnoty = new int[] {};
            string[] vysledky = new string[] { };

            for (int i = 0; i < exps.Length; i++)
            {
                int number = 0;
                if (Char.IsNumber(exps[i], 0))
                {
                    hodnoty[i] = Convert.ToInt32(exps[i]);
                }
            }
            Console.WriteLine("Délka pole s hodnotami: " + hodnoty.Length);
            Console.WriteLine(hodnoty[0]);
            
            //Console.WriteLine(vysledky[0]);

        }
    }
}

/*if (exps[i] == "+")
{
    Console.WriteLine("Délka pole s hodnotami: " + hodnoty.Length);
    for (var j = 0; j < hodnoty.Length - 1; j++)
    {
        vysledky.Append(hodnoty[0] + hodnoty[1]);
    }
}*/
