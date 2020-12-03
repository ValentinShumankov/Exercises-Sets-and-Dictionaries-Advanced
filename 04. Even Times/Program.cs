using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string [ ] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int,int> nums = new Dictionary<int, int>();
            for ( int i = 0; i < count; i++ )
            {
                int curNum = int.Parse(Console.ReadLine());
                if (nums.ContainsKey(curNum) )
                {
                    nums [ curNum ] += 1;
                }
                else
                {
                    nums.Add( curNum, 1 );
                }
            }
            foreach ( var item in nums )
            {
                if ( item.Value % 2 == 0 )
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }
        }
    }
}

/*
 Even Times
Write a program that prints a number from a collection,
which appears an even number of times in it. On the first line, 
you will be given n – the count of integers you will receive. 
On the next n lines you will be receiving the numbers. 
It is guaranteed that only one of them appears an even number of times.
Your task is to find that number and print it in the end. 
Examples
 
Input
3
2
-1
2

Output
2
=========
Input
5
1
2
3
1
5

OutPut
1
 */
