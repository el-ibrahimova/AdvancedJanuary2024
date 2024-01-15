namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        /*
        1 10
        odd
           
         */
        static void Main(string[] args)
        {
            int[] ranges = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Func<int, int, List<int>> generateRange = (start, end) =>
            {
                List<int> range = new();

                for (int i = start; i <= end; i++)
                {
                    range.Add(i);
                }

                return range;
            };

            Func<string, int, bool> EvenOddMatch = (condition, number) =>
            {
                if (condition == "even")
                {
                    return number % 2 == 0;
                }
                else // "odd"
                {
                    return number % 2 != 0;
                }
            };
            
            List<int> numbers = generateRange(ranges[0], ranges[1]);

            foreach (var number in numbers)
            {
                if (EvenOddMatch(command, number))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
