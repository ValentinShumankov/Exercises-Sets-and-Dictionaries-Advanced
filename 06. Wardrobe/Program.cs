using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string [ ] args)
        {
            var clothes =  new Dictionary<string, Dictionary<string, int>>();
            string color = string.Empty;
            int countInput = int.Parse(Console.ReadLine());
            for ( int i = 0; i < countInput; i++ )
            {
                string[] curInput = Console.ReadLine().Split(new string[]{ ","," -> " },StringSplitOptions.RemoveEmptyEntries);
                color = curInput [ 0 ];
                for ( int k = 1; k < curInput.Length; k++ )
                {
                    if ( clothes.ContainsKey( color ) )
                    {
                        if ( clothes [ color ].ContainsKey( curInput [ k ] ) )
                        {
                            clothes [ color ] [ curInput [ k ] ] += 1;
                        }
                        else
                        {
                            clothes [ color ].Add( curInput [ k ], 1 );
                        }
                    }
                    else
                    {
                        clothes.Add( color, new Dictionary<string, int>( ) { { curInput [ k ], 1 } } );
                    }
                }
            }

            string[] itemsTofind = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            color = itemsTofind [ 0 ];
            var dress = itemsTofind[ 1 ];
            foreach ( var colors in clothes )
            {
                if ( colors.Value.Count > 0 )
                {
                    Console.WriteLine( $"{colors.Key } clothes:" );
                    foreach ( var dresses in colors.Value )
                    {
                        if ( color == colors.Key && dresses.Key == dress )
                        {
                            Console.WriteLine( $"* {dresses.Key} - {dresses.Value} (found!)" );
                        }
                        else
                        {
                            Console.WriteLine( $"* {dresses.Key} - {dresses.Value}" );
                        }
                    }
                }
            }
        }
    }
}
/*
 
 Wardrobe
Write a program that helps you decide what clothes to wear from your wardrobe. You will receive the clothes, which are currently in your wardrobe, sorted by their color in the following format:
"{color} -> {item1},{item2},{item3}…"
If you receive a certain color, which already exists in your wardrobe, just add the clothes to its records. You can also receive repeating items for a certain color and you have to keep their count.
In the end, you will receive a color and a piece of clothing, which you will look for in the wardrobe, separated by a space in the following format:
"{color} {clothing}"
Your task is to print all the items and their count for each color in the following format: 
"{color} clothes:
* {item1} - {count}
* {item2} - {count}
* {item3} - {count}
…
* {itemN} - {count}"
If you find the item you are looking for, you need to print "(found!)" next to it:
"* {itemN} - {count} (found!)"
Input
On the first line, you will receive n –  the number of lines of clothes, which you will receive.
On the next n lines, you will receive the clothes in the format described above.
Output
Print the clothes from your wardrobe in the format described above


Examples

Input
4
Blue -> dress,jeans,hat
Gold -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
Blue dress
 

Output
Blue clothes:
* dress - 1 (found!)
* jeans - 1
* hat - 1
* gloves - 1
Gold clothes:
* dress - 1
* t-shirt - 1
* boxers - 1
White clothes:
* briefs - 1
* tanktop - 1
 
 */