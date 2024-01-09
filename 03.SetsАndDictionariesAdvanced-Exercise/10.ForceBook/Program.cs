using System.Threading.Channels;

namespace _10.ForceBook
{
    /*
   Light | George
   Dark | Peter
   Lumpawaroo
   */
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> sideUsers = new();

            string command;
            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                if (command.Contains('|'))
                {
                    string[] tokens = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = tokens[0];
                    string user = tokens[1];

                    if (!sideUsers.Values.Any(u => u.Contains(user))) // не се съдържа User в никоя от страните
                    {
                        if (!sideUsers.ContainsKey(side))
                        {
                            sideUsers.Add(side, new SortedSet<string>());
                        }

                        sideUsers[side].Add(user);
                    }
                }
                else // contains " -> "
                {
                    string[] tokens = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string user = tokens[0];
                    string side = tokens[1];

                    foreach (var sideUser in sideUsers)
                    {
                        if (sideUser.Value.Contains(user))
                        {
                            sideUser.Value.Remove(user);
                            break;
                        }
                    }

                    if (!sideUsers.ContainsKey(side))
                    {
                        sideUsers.Add(side, new SortedSet<string>());
                    }
                    sideUsers[side].Add(user);

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            foreach (var sideUser in sideUsers.OrderByDescending(su => su.Value.Count))
            {
                if (sideUser.Value.Any())
                {
                    Console.WriteLine($"Side: {sideUser.Key}, Members: {sideUser.Value.Count}");

                    foreach (var user in sideUser.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
