namespace _01.WormsAndHoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] wormsArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int[] holesArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            Stack<int> worms = new Stack<int>(wormsArr);
            Queue<int> holes = new Queue<int>(holesArr);

            int initialCountOfWorms = worms.Count;
            int matches = 0;

            while (worms.Any() && holes.Any())
            {
                int currentWorm = worms.Peek();
                int currentHole = holes.Peek();

                if (currentWorm == currentHole)
                {
                    matches++;
                    worms.Pop();
                    holes.Dequeue();
                }
                else
                {
                    holes.Dequeue();
                    currentWorm -= 3;

                    if (currentWorm > 0)
                    {
                        worms.Pop();
                        worms.Push(currentWorm);
                    }
                    else
                    {
                        worms.Pop();
                    }
                }
            }

            if (matches > 0)
            {
                Console.WriteLine($"Matches: {matches}");
            }
            else
            {
                Console.WriteLine("There are no matches.");
            }

            if (worms.Count == 0 && initialCountOfWorms == matches)
            {
                Console.WriteLine("Every worm found a suitable hole!");
            }
            else if (worms.Count == 0)
            {
                Console.WriteLine("Worms left: none");
            }
            else
            {
                Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
            }

            if (holes.Count == 0)
            {
                Console.WriteLine("Holes left: none");
            }
            else
            {
                Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
            }
        }
    }
}
