using System.Diagnostics.Contracts;

namespace _03.Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command
                    .Split(new char [] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];

                if (action == "Push")
                {
                    int[] itemsToPush = tokens
                        .Skip(1)
                        .Select(int.Parse)
                        .ToArray();

                    foreach (int item in itemsToPush)
                    {
                        stack.Push(item);
                    }
                }
                else // "Pop"
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            //по условие колекцията трябва да се разпечата два пъти

            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
