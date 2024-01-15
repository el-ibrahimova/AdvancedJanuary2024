using System.Globalization;

namespace _03.CustomMinFunction
{
    /*
     1 4 3 2 1 7 13
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();

            Func<HashSet<int>, int> min = numbers =>
            {
                //  return numbers.Min();  ==> това е с Linq = най-лесния начин

                // по този начин ние ще си напишем Linq
                int min = int.MaxValue;
                foreach (int number in numbers)
                {
                    if (number < min)
                    {
                        min = number;
                    }
                }
                return min;
            };

            Console.WriteLine(min(numbers));
        }
    }
}
