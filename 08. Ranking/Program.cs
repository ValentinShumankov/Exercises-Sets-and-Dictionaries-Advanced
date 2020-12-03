using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string [ ] args)
        {
            var dataOfCourses = new Dictionary<string, string>();

            while ( true )
            {
                string input = Console.ReadLine();

                if ( input == "end of contests" )
                {
                    break;
                }

                string[] toknes = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contest = toknes[0];
                string password = toknes[1];

                dataOfCourses.Add( contest, password ); //not cheking key contest
            }

            var users = new Dictionary<string, Dictionary<string, int>>();
            //key=userName, key = contest, value = points

            while ( true )
            {
                string input = Console.ReadLine();

                if ( input == "end of submissions" )
                {
                    break;
                }

                string[] tokens = input.Split("=>"); //"{contest}=>{password}=>{username}=>{points}" 
                string contest = tokens[0];
                string password = tokens[1];
                string userName = tokens[2];
                int points = int.Parse(tokens[3]);

                if ( dataOfCourses.ContainsKey( contest ) )
                {
                    if ( dataOfCourses [ contest ] == password )
                    {
                        if ( users.ContainsKey( userName ) == false )
                        {
                            users.Add( userName, new Dictionary<string, int>( ) );
                        }

                        if ( users [ userName ].ContainsKey( contest ) == false )
                        {
                            users [ userName ].Add( contest, points );
                        }
                        else
                        {
                            if ( users [ userName ] [ contest ] < points )
                            {
                                users [ userName ] [ contest ] = points;
                            }
                        }
                    }
                }
            }

            KeyValuePair<string, int> bestUser = BestUser(users);
            Console.WriteLine( $"Best candidate is {bestUser.Key} with total {bestUser.Value} points." );
            Console.WriteLine( "Ranking:" );

            foreach ( var kvp in users.OrderBy( x => x.Key ) )
            {
                Console.WriteLine( kvp.Key );

                foreach ( var contest in kvp.Value.OrderByDescending( x => x.Value ) )
                {
                    Console.WriteLine( $"#  {contest.Key} -> {contest.Value}" );
                }
            }
        }

        private static KeyValuePair<string, int> BestUser(Dictionary<string, Dictionary<string, int>> users)
        {
            int bestSum = 0;
            string userOfBest = string.Empty;

            foreach ( var kvp in users )
            {
                string userName = kvp.Key;
                int sumOfPoints = kvp.Value.Values.Sum();

                if ( bestSum < sumOfPoints )
                {
                    bestSum = sumOfPoints;
                    userOfBest = userName;
                }
            }

            KeyValuePair<string, int> bestUser = new KeyValuePair<string, int>(userOfBest, bestSum);
            return bestUser;
        }
    }
}

/*
 *Ranking
Write a program that ranks candidate-interns, depending on the points from the interview tasks and their exam results in SoftUni.
You will receive some lines of input in the format "{contest}:{password for contest}" until you receive "end of contests". 
Save that data because you will need it later. 
After that you will receive other type of inputs in 
format "{contest}=>{password}=>{username}=>{points}" until you
receive "end of submissions". Here is what you need to do:
Check if the contest is valid (if you received it in the first type of input)
Check if the password is correct for the given contest
Save the user with the contest they take part in (a user can take part in many contests)
and the points the user has in the given contest. If you receive the same contest and
the same user, update the points only if the new ones are more than the older ones.
At the end you have to print the info for the user with the most points in the format:
"Best candidate is {user} with total {total points} points.". After that print all 
students ordered by their names. For each user, print each contest with the points in descending order in the following format:
"{user1 name}
#  {contest1} -> {points}
#  {contest2} -> {points}
{user2 name}
…"

Input
You will be receiving strings in formats described above, until the appropriate commands, also described above, are given.
Output
On the first line print the best user in the format described above. 
On the next lines print all students ordered as mentioned above in format.
Constraints
There will be no case with two equal contests.
The strings may contain any ASCII character except from (:, =, >).
The numbers will be in range [0 - 10000].
The second input is always valid.
There will be no case with 2 or more users with same total points.
Examples
 
Input
Part One Interview:success
Js Fundamentals:Pesho
C# Fundamentals:fundPass
Algorithms:fun
end of contests
C# Fundamentals=>fundPass=>Tanya=>350
Algorithms=>fun=>Tanya=>380
Part One Interview=>success=>Nikola=>120
Java Basics Exam=>pesho=>Petkan=>400
Part One Interview=>success=>Tanya=>220
OOP Advanced=>password123=>BaiIvan=>231
C# Fundamentals=>fundPass=>Tanya=>250
C# Fundamentals=>fundPass=>Nikola=>200
Js Fundamentals=>Pesho=>Tanya=>400
end of submissions

Output
Best candidate is Tanya with total 1350 points.
Ranking:
Nikola
#  C# Fundamentals -> 200
#  Part One Interview -> 120
Tanya
#  Js Fundamentals -> 400
#  Algorithms -> 380
#  C# Fundamentals -> 350
#  Part One Interview -> 220
===============================================
Input 
Java Advanced:funpass
Part Two Interview:success
Math Concept:asdasd
Java Web Basics:forrF
end of contests
Math Concept=>ispass=>Monika=>290
Java Advanced=>funpass=>Simona=>400
Part Two Interview=>success=>Drago=>120
Java Advanced=>funpass=>Petyr=>90
Java Web Basics=>forrF=>Simona=>280
Part Two Interview=>success=>Petyr=>0
Math Concept=>asdasd=>Drago=>250
Part Two Interview=>success=>Simona=>200
end of submissions


Output

Best candidate is Simona with total 880 points.
Ranking: 
Drago
#  Math Concept -> 250
#  Part Two Interview -> 120
Petyr
#  Java Advanced -> 90
#  Part Two Interview -> 0
Simona
#  Java Advanced -> 400
#  Java Web Basics -> 280
#  Part Two Interview -> 200

 */