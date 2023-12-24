namespace _01.BasicStackOperations
{
    /*
    5 2 13
    1 13 45 32 4
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();  // 5 2 13  == x, y, z

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();  // 1 13 45 32 4

            int valuesToPush = values[0]; // 5
            int valuesToPop = values[1];  // 2
            int lookUpValue = values[2];  // 13

            Stack<int> stack = new Stack<int>(input.Take(valuesToPush)); // кратък запис на следващия код

         //   for (int i = 0; i < valuesToPush; i++)
         // {
         //   stack.Push(input[i]);
         // }

         
            while (stack.Any() && valuesToPop > 0)   // stack.Any() == stack.Count>0
            {
                stack.Pop();
                valuesToPop--;
            }

            if (stack.Contains(lookUpValue))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else // print smallest element
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
