namespace _08.ListOfPredicates
{
/*
10
1 1 1 2
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int endRange = int.Parse(Console.ReadLine());
          
            HashSet<int> dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();
          
            List<Predicate<int>> predicates = new();

            int[] numbers = Enumerable.Range(1, endRange).ToArray(); // създаваме масива от числа, за които ще се проверява дали се делят на dividers

            foreach (int divider in dividers)
            {
                predicates.Add(n => n % divider == 0);
            }

            foreach (int number in numbers)
            {
                bool isDivisible = true;

                foreach (var match in predicates)
                {
                    if (!match(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
