using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string [ ] args)
        {
            HashSet<string> names = new HashSet<string>();
            Queue<string> namesList = new Queue<string>();
            int countInput =int.Parse(Console.ReadLine());
            for ( int i = 0; i < countInput; i++ )
            {
                string curInput = Console.ReadLine();
                if (! names.Contains(curInput) )
                {
                    namesList.Enqueue( curInput );
                }
                names.Add( curInput );
            }
            foreach ( var item in namesList )
            {
                Console.WriteLine(item);
            }
        }
    }
}

/*
Unique Usernames
Write a program that reads from the console a sequence 
of N usernames and keeps a collection only of the unique ones. 
On the first line you will be given an integer N.
On the next N lines you will receive one username per line. 
Print the collection on the console in order of insertion:
Examples 
Input
6
Ivan
Ivan
Ivan
Pesho
Ivan
NiceGuy1234

Output
Ivan
Pesho
NiceGuy1234


 */