namespace _01.ApocalypsePreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textile = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> created = new Dictionary<string, int>();

            while (textile.Any() && medicaments.Any())
            {
                int currTextile = textile.Peek();
                int currMedicament = medicaments.Peek();
                int result = currMedicament + currTextile;

                if (result == 30)
                {
                    if (!created.ContainsKey("Patch"))
                    {
                        created.Add("Patch", 0);
                    }
                    created["Patch"]++;

                    textile.Dequeue();
                    medicaments.Pop();
                }
                else if (result == 40)
                {
                    if (!created.ContainsKey("Bandage"))
                    {
                        created.Add("Bandage", 0);
                    }
                    created["Bandage"]++;

                    textile.Dequeue();
                    medicaments.Pop();
                }
                else if (result == 100)
                {
                    if (!created.ContainsKey("MedKit"))
                    {
                        created.Add("MedKit", 0);
                    }
                    created["MedKit"]++;

                    textile.Dequeue();
                    medicaments.Pop();
                }
                else if (result > 100)
                {
                    if (!created.ContainsKey("MedKit"))
                    {
                        created.Add("MedKit", 0);
                    }
                    created["MedKit"]++;

                    textile.Dequeue();
                    medicaments.Pop();

                    int toAdd = result - 100;
                    int itemToAdd = medicaments.Peek();
                    itemToAdd += toAdd;
                    medicaments.Pop();
                    medicaments.Push(itemToAdd);
                }
                else
                {
                    textile.Dequeue();
                    currMedicament += 10;
                    medicaments.Pop();
                    medicaments.Push(currMedicament);
                }
            }

            if (medicaments.Count == 0 && textile.Count !=0)
            {
                Console.WriteLine("Medicaments are empty.");
            }

            if (textile.Count == 0 && medicaments.Count!=0)
            {
                Console.WriteLine("Textiles are empty.");
            }

            if (textile.Count == 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }

            if (created.Count > 0)
            {
                foreach (var item in created.OrderByDescending(x => x.Value).ThenBy(n => n.Key))
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }

            if (medicaments.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }
            if (textile.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textile)}");
            }
        }
    }
}
