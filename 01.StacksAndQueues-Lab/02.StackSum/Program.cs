namespace _02.StackSum
{
/*
1 2 3 4
adD 5 6
REmove 3
eNd
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            //   List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            // вместо да изписваме листа, директно го записваме new Stack<int> (..........);

            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] splitted = command.Split();

                // add 5 6
                if (command.Contains("add"))
                {
                    int first = int.Parse(splitted[1]);
                    int second = int.Parse(splitted[2]);
                    stack.Push(first);
                    stack.Push(second);
                }
                // remove 3
                else if (command.Contains("remove"))
                {
                    int n = int.Parse(splitted[1]);
                    if (n <= stack.Count)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }

            int sum = 0;
            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
