namespace _05.AppliedArithmetics
{
/*
1 2 3 4 5
add
add
print
end
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<string, List<int>, List<int>> calculate = (command, numbers) =>
            {
                List<int> result = new();

                foreach (int number in numbers)
                {
                    switch (command)
                    {
                        case "add":
                            result.Add(number + 1);
                            break;
                        case "multiply":
                            result.Add(number * 2);
                            break;
                        case "subtract":
                            result.Add(number - 1);
                            break;
                    }
                }
                return result;
            };

            Action<List<int>> print = numbers => Console.WriteLine(string.Join(" ", numbers));
            
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    print(numbers); // Извикваме Action
                }
                else
                {
                    numbers = calculate(command, numbers);  // извикваме Func
                }
            }
        }
    }
}
