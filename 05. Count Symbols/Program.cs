using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string [ ] args)
        {
            string input = Console.ReadLine( );
            Dictionary<char,int> listChars = new Dictionary<char, int>();
            for ( int i = 0; i < input.Length; i++ )
            {
                if ( listChars.ContainsKey(input[i]) )
                {
                    listChars [ input [ i ] ] += 1;
                }
                else
                {
                    listChars.Add( input [ i ], 1 );
                }
            }
            foreach ( var item in listChars.OrderBy(x => x.Key).ThenBy(x => x.Key) )
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
/*
 Input
SoftUni rocks

 Output
 : 1 time/s
S: 1 time/s
U: 1 time/s
c: 1 time/s
f: 1 time/s
i: 1 time/s
k: 1 time/s
n: 1 time/s
o: 2 time/s
r: 1 time/s
s: 1 time/s
t: 1 time/s
============
Input
 Did you know Math.Round rounds to the nearest even integer?

Output
 : 9 time/s
.: 1 time/s
?: 1 time/s
D: 1 time/s
M: 1 time/s
R: 1 time/s
a: 2 time/s
d: 3 time/s
e: 7 time/s
g: 1 time/s
h: 2 time/s
i: 2 time/s
k: 1 time/s
n: 6 time/s
o: 5 time/s
r: 3 time/s
s: 2 time/s
t: 5 time/s
u: 3 time/s
v: 1 time/s
w: 1 time/s
y: 1 time/s

 */
