using System.Threading.Channels;

namespace _01.OffroadChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] initialFuel = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int[] addConsumptIndex = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int[] amountOfFuelNeeded = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            Stack<int> fuelQuantity = new Stack<int>(initialFuel);
            Queue<int> addConsumpt = new Queue<int>(addConsumptIndex);
            Queue<int> neededFuel = new Queue<int>(amountOfFuelNeeded);

            List<string> reachedAltitudes = new List<string>();

            int altitudeCounter = 0;

            while (fuelQuantity.Any() && addConsumpt.Any() && neededFuel.Any())
            {
                altitudeCounter++;
                int currentFuel = fuelQuantity.Peek();
                int currentConsumption = addConsumpt.Peek();
                int currentNeededFuel = neededFuel.Peek();

                if (currentFuel - currentConsumption >= currentNeededFuel)
                {
                    fuelQuantity.Pop();
                    addConsumpt.Dequeue();
                    neededFuel.Dequeue();

                    Console.WriteLine($"John has reached: Altitude {altitudeCounter}");
                    reachedAltitudes.Add($"Altitude {altitudeCounter}");
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {altitudeCounter}");
                    break;
                }

                if (neededFuel.Count == 0)
                {
                    Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
                    Environment.Exit(0);
                }
            }

            if (reachedAltitudes.Count > 0)
            {
                Console.WriteLine($"John failed to reach the top.");
                Console.WriteLine($"Reached altitudes: {string.Join(", ", reachedAltitudes)}");
            }
            else if (reachedAltitudes.Count == 0)
            {
                Console.WriteLine("John failed to reach the top.");
                Console.WriteLine("John didn't reach any altitude.");
            }
        }
    }
}
