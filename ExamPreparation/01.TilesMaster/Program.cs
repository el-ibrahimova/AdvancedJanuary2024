namespace _01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTiles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int[] greyTiles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            Queue<int> greyTilesQueue = new Queue<int>(greyTiles);
            Stack<int> whiteTilesStack = new Stack<int>(whiteTiles);

            Dictionary<string, int> location = new Dictionary<string, int>();

            while (greyTilesQueue.Any() && whiteTilesStack.Any())
            {
                int currentWhite = whiteTilesStack.Peek();
                int currentGrey = greyTilesQueue.Peek();

                if (currentGrey==currentWhite)
                {
                    int newArea = currentGrey + currentWhite;

                    if (newArea == 40)
                    {
                        if (!location.ContainsKey("Sink"))
                        {
                            location.Add("Sink", 0);
                        }
                        location["Sink"]++;

                        whiteTilesStack.Pop();
                        greyTilesQueue.Dequeue();
                    }
                    else if (newArea == 50)
                    {
                        if (!location.ContainsKey("Oven"))
                        {
                            location.Add("Oven", 0);
                        }
                        location["Oven"]++;

                        whiteTilesStack.Pop();
                        greyTilesQueue.Dequeue();
                    }
                    else if (newArea == 60)
                    {
                        if (!location.ContainsKey("Countertop"))
                        {
                            location.Add("Countertop", 0);
                        }
                        location["Countertop"]++;

                        whiteTilesStack.Pop();
                        greyTilesQueue.Dequeue();
                    }
                    else if (newArea == 70)
                    {
                        if (!location.ContainsKey("Wall"))
                        {
                            location.Add("Wall", 0);
                        }
                        location["Wall"]++;

                        whiteTilesStack.Pop();
                        greyTilesQueue.Dequeue();
                    }
                    else
                    {
                        if (!location.ContainsKey("Floor"))
                        {
                            location.Add("Floor", 0);
                        }
                        location["Floor"]++;

                        whiteTilesStack.Pop();
                        greyTilesQueue.Dequeue();
                    }
                }
                else
                {
                    currentWhite /= 2;
                    whiteTilesStack.Pop();
                    whiteTilesStack.Push(currentWhite);

                    greyTilesQueue.Dequeue();
                    greyTilesQueue.Enqueue(currentGrey);
                }
            }

            if (whiteTilesStack.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTilesStack)}");
            }

            if (greyTilesQueue.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTilesQueue)}");
            }

            foreach (var item in location.OrderByDescending(n=>n.Value).ThenBy(n=>n.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
