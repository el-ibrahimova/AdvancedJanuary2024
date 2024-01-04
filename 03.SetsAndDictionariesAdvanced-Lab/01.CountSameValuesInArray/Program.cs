namespace _01.CountSameValuesInArray
{
    /*
  -2.5 4 3 -2.5 -5.5 4 3 3 -2.5 3
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            Dictionary<double, int> numbersCount = new Dictionary<double, int>();

            foreach (double number in numbers)
            {

                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount.Add(number, 1);
                }
                else
                {
                    numbersCount[number]++;
                }
            }

            foreach (var entry in numbersCount)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value} times");
            }
        }
    }
}
