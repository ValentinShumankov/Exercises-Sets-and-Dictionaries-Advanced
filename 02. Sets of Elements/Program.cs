using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string [ ] args)
        {
            int[] numsAB = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int a = numsAB[0];
            int b = numsAB[1];
            HashSet<int> numsA = new HashSet<int>(); 
            HashSet<int> numsB = new HashSet<int>();
            for ( int i = 0; i < a; i++ )
            {
                numsA.Add( int.Parse( Console.ReadLine( ) ) );
            }
            for ( int i = 0; i < b; i++ )
            {
                numsB.Add( int.Parse( Console.ReadLine( ) ) );
            }

            foreach ( var item in numsA )
            {
                if ( numsB.Contains(item) )
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}

/*
 Sets of Elements
Write a program that prints a set of elements. 
On the first line you will receive two numbers - n and m,
which represent the lengths of two separate sets.
On the next n + m lines you will receive n numbers,
which are the numbers in the first set, and m numbers, 
which are in the second set. Find all the unique elements 
that appear in both of them and print them in the order in
which they appear in the first set - n.
For example:
Set with length n = 4: {1, 3, 5, 7}
Set with length m = 3: {3, 4, 5}
Set that contains all the elements that repeat in both sets -> {3, 5}

Examples
 
Input
4 3
1
3
5
7
3
4
5

Output
3 5

 */

