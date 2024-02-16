using System;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace _01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<int, string> swordsResources = new ()
            {
                {70, "Gladius" },
                {80, "Shamshir"},
                {90, "Katana" },
                {110,"Sabre"},
                {150, "Broadsword" }
            };
            
            Dictionary<string, int> swordsMaded = new Dictionary<string, int>();

            while (steel.Any() && carbon.Any())
            {
                int currSteel = steel.Peek();
                int currCarbon = carbon.Peek();
                int sum = currCarbon + currSteel;
                
                if (swordsResources.ContainsKey(sum))
                {
                    steel.Dequeue();
                    carbon.Pop();

                    string currSword = swordsResources[sum];

                    if (!swordsMaded.ContainsKey(currSword))
                    {
                        swordsMaded.Add(currSword, 0);
                    }
                    swordsMaded[currSword]++;
                }
                else
                {
                    steel.Dequeue();
                    carbon.Pop();
                    currCarbon += 5;
                    carbon.Push(currCarbon);
                }
            }

           string swordsResult = swordsMaded.Count == 0
                ? "You did not have enough resources to forge a sword."               
                : $"You have forged {swordsMaded.Values.Sum()} swords.";
            string steelResult = steel.Count == 0 ? "Steel left: none" : $"Steel left: {string.Join(", ", steel)}";
            string carbonResult = carbon.Count == 0 ? "Carbon left: none" : $"Carbon left: {string.Join(", ", carbon)}";

            Console.WriteLine(swordsResult);
            Console.WriteLine(steelResult);
            Console.WriteLine(carbonResult);

            foreach (var item in swordsMaded.OrderBy(n=>n.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
