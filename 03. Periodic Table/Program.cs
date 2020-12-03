using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string [ ] args)
        {
            List<string> compounds = new List<string>();
            HashSet<string> uniqueElements = new HashSet<string>();
            int countLines = int.Parse(Console.ReadLine());
            for ( int i = 0; i < countLines; i++ )
            {
                string[] input = Console.ReadLine().Split();
                for ( int k = 0; k < input.Length; k++ )
                {
                    uniqueElements.Add(input[k] );
                }
            }
            foreach ( var item in uniqueElements )
            {
                compounds.Add( item );
            }
            Console.WriteLine(string.Join(" ",compounds.OrderBy(x => x)));
        }
    }
}

/*
 Periodic Table
Write a program that keeps all the unique chemical elements. On the first line you will be given a number n - the count of input lines that you are going to receive. On the next n lines you will be receiving chemical compounds, separated by a single space. Your task is to print all the unique ones in ascending order:
Examples
 
 Input
4
Ce O
Mo O Ce
Ee
Mo

Output
Ce Ee Mo O

===========
Input
3
Ge Ch O Ne
Nb Mo Tc
O Ne

Output
Ch Ge Mo Nb Ne O Tc
 */
