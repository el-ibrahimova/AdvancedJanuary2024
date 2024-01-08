using System;
using System.Collections.Generic;

namespace _07.TheV_Logger
{
/*
EmilConrad joined The V-Logger
VenomTheDoctor joined The V-Logger
Saffrona joined The V-Logger
Saffrona followed EmilConrad
Saffrona followed VenomTheDoctor
EmilConrad followed VenomTheDoctor
VenomTheDoctor followed VenomTheDoctor
Saffrona followed EmilConrad
Statistics
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,List<string>> vloggers = new();
            Dictionary<string, int[]> userNumberOfFollows = new();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] details = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string userName = details[0];
                string command = details[1];
                string userToFollow = details[2];

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(userName))
                    {
                        vloggers[userName]= new List<string>();
                        userNumberOfFollows[userName] = new int [2];
                    }
                }
                else if (command == "followed")
                {
                    if (vloggers.ContainsKey(userName) && vloggers.ContainsKey(userToFollow) )
                    {
                        if (!vloggers[userToFollow].Contains(userName) && userName != userToFollow)
                        {
                            vloggers[userToFollow].Add(userName);
                            userNumberOfFollows[userToFollow][0]++;
                            userNumberOfFollows[userName][1]++;
                        }
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

           // подреждаме по хора, които са най-много последвани, след това по брой хора, които те са последвали => връщаме като Dictionary
            Dictionary< string, int[]> orderUsersAndFollowers = userNumberOfFollows
                .OrderByDescending(u => u.Value[0])
                .ThenBy(u => u.Value[1])
                .ToDictionary(x=>x.Key, x=>x.Value);

            int count = 1;
            string userToRemove = "";

            foreach (var kvp in orderUsersAndFollowers)
            {
                userToRemove = kvp.Key;

                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value[0]} followers, {kvp.Value[1]} following");
                count++;

                if (vloggers[kvp.Key].Count > 0)
                {
                    foreach (var follower in vloggers[kvp.Key].OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                break;
            }

            orderUsersAndFollowers.Remove(userToRemove);

            foreach (KeyValuePair<string, int[]> kvp in orderUsersAndFollowers)
            {
                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value[0]} followers, {kvp.Value[1]} following");
                count++;
            }
        }
    }
}
