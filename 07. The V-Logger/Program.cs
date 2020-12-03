﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Vlogger
{
    class Vlogger
    {
        static void Main(string [ ] args)
        {
            var database = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            var input = string.Empty;
            while ( (input = Console.ReadLine()) != "Statistics" )
            {
                string[] data = input.Split();
                string vlogger = data[0];
                string command = data[1];

                if ( command == "joined" )
                {
                    if ( database.ContainsKey( vlogger ) == false )
                    {
                        database.Add( vlogger, new Dictionary<string, HashSet<string>>( ) {
                            { "followers" , new HashSet<string>()},
                            { "following" , new HashSet<string>()}
                        } );
                    }
                }
                else if ( command == "followed" )
                {
                    string member = data[2];

                    if ( vlogger != member && database.ContainsKey( vlogger ) && database.ContainsKey( member ) )
                    {
                        database [ vlogger ] [ "following" ].Add( member );
                        database [ member ] [ "followers" ].Add( vlogger );
                    }
                }
            }

            int number = 1;
            Console.WriteLine( $"The V-Logger has a total of {database.Count} vloggers in its logs." );

            foreach ( var vlogger in database.OrderByDescending( v => v.Value [ "followers" ].Count ).ThenBy( v => v.Value [ "following" ].Count ) )
            {
                Console.WriteLine( $"{number}. {vlogger.Key} : {vlogger.Value [ "followers" ].Count} followers, {vlogger.Value [ "following" ].Count} following" );

                if ( number == 1 )
                {
                    foreach ( string follower in vlogger.Value [ "followers" ].OrderBy( f => f ) )
                    {
                        Console.WriteLine( $"*  {follower}" );
                    }
                }
                number++;
            }
        }
    }
}