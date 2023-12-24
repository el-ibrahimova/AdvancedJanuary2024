namespace _02.BasicQueueOperations
{
/*
5 2 32
1 13 45 32 4
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();  

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();  

            int valuesToPush = values[0]; // 5
            int valuesToPop = values[1];  // 2
            int lookUpValue = values[2];  // 13

            Queue<int> queue = new Queue<int>((input.Take(valuesToPush))); 

            while (queue.Any() && valuesToPop > 0)  
            {
                queue.Dequeue();
                valuesToPop--;
            }

            if (queue.Contains(lookUpValue))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else // print smallest element
            {
                Console.WriteLine(queue.Min());
            }
        }
    
    }
}
