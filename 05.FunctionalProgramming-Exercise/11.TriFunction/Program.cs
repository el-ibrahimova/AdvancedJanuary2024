using System.Diagnostics.CodeAnalysis;

namespace _11.TriFunction
{
    /*
    350
    Rob Mary Paisley Spencer
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputSum = int.Parse(Console.ReadLine());

            string[] inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> checkEqualOrLargeNameSum =
                //(name, sum) => name.Sum(ch => ch) >= sum;
                (name, sum) =>
                {
                    int charsSum = name.Sum(ch => ch);
                    return charsSum >= sum;
                };

            Func<string[], int, Func<string, int, bool>, string> getFirstName =
                // (names, sum, match) => names.FirstOrDefault(name => match(name, sum));
                (names, sum, match) =>
                {
                    foreach (var name in names)
                    {
                        if (match(name, sum))
                        {
                            return name;
                        }
                    }
                    return default;
                };

            string foundName = getFirstName(inputNames, inputSum, checkEqualOrLargeNameSum);

            Console.WriteLine(foundName);
        }
    }
}
