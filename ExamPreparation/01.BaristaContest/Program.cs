namespace _01.BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coffees = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] milks = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> coffeeQueue = new Queue<int>(coffees);
            Stack<int> milkStack = new Stack<int>(milks);

            Dictionary<string, int> drinks = new Dictionary<string, int>();

            while (coffeeQueue.Any() && milkStack.Any())
            {
                int currentCoffee = coffeeQueue.Peek();
                int currentMilk = milkStack.Peek();

                int result = currentMilk + currentCoffee;

                if (result == 50)
                {
                    if (!drinks.ContainsKey("Cortado"))
                    {
                        drinks.Add("Cortado", 0);
                    }
                    drinks["Cortado"]++;

                    coffeeQueue.Dequeue();
                    milkStack.Pop();
                }
                else if (result == 75)
                {
                    if (!drinks.ContainsKey("Espresso"))
                    {
                        drinks.Add("Espresso", 0);
                    }
                    drinks["Espresso"]++;

                    coffeeQueue.Dequeue();
                    milkStack.Pop();
                }
                else if (result == 100)
                {
                    if (!drinks.ContainsKey("Capuccino"))
                    {
                        drinks.Add("Capuccino", 0);
                    }
                    drinks["Capuccino"]++;

                    coffeeQueue.Dequeue();
                    milkStack.Pop();
                }
                else if (result == 150)
                {
                    if (!drinks.ContainsKey("Americano"))
                    {
                        drinks.Add("Americano", 0);
                    }
                    drinks["Americano"]++;

                    coffeeQueue.Dequeue();
                    milkStack.Pop();
                }
                else if (result == 200)
                {
                    if (!drinks.ContainsKey("Latte"))
                    {
                        drinks.Add("Latte", 0);
                    }
                    drinks["Latte"]++;

                    coffeeQueue.Dequeue();
                    milkStack.Pop();
                }
                else
                {
                    coffeeQueue.Dequeue();
                    milkStack.Pop();
                    currentMilk -= 5;
                    milkStack.Push(currentMilk);
                }
            }

            if (coffeeQueue.Count == 0 && milkStack.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeeQueue.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffeeQueue)}");
            }

            if (milkStack.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milkStack)}");
            }

            foreach (var item in drinks.OrderBy(k=>k.Value).ThenByDescending(n=>n.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
