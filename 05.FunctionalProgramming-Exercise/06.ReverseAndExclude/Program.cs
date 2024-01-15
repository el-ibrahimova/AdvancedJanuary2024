namespace _06.ReverseAndExclude
{ 
 /*
 1 2 3 4 5 6
 2
 */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divider = int.Parse(Console.ReadLine());


            Func<List<int>, List<int>> reverse = numbers =>
            {
                List<int> result = new List<int>();

                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    result.Add(numbers[i]);
                }
                return result;
            };

            Func<List<int>, Predicate<int>, List<int>> exclude = (numbers, match) =>
            {
                List<int> result = new();

                foreach (int number in numbers)
                {
                    if (!match(number))
                    {
                        result.Add(number);
                    }
                }
                return result;
            };
            
            Predicate<int> checkEven = number =>
                number % divider == 0;

            numbers = exclude(numbers, checkEven);
            numbers = reverse(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
