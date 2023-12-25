using System.Diagnostics;

namespace _03.MaximumAndMinimumElement
{
/*
9
1 97
2
1 20
2
1 26
1 20
3
1 91
4
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] commandInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (commandInfo[0] == 1)
                {
                    stack.Push(commandInfo[1]); 
                }
                else if (commandInfo[0] == 2)
                {
                    stack.Pop(); 
                }
                else if (commandInfo[0] == 3 && stack.Any())
                {
                    Console.WriteLine(stack.Max());
                }
                else if (commandInfo[0] == 4 && stack.Any())
                {
                    Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
