namespace _05.FashionBoutique
{
/*
5 4 8 6 3 8 7 7 9
16
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray(); // 5 4 8 6 3 8 7 7 9
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> racks = new Stack<int>(input);

            int totalUsedRacks = 1;
            int currentCapacity = 0;

            while (racks.Count > 0)
            {
                int currentValue = racks.Pop();

                if (currentValue + currentCapacity <= capacity)
                {
                    currentCapacity += currentValue;
                }
                else
                {
                    totalUsedRacks++;
                    currentCapacity = currentValue;
                }
            }

            Console.WriteLine(totalUsedRacks);
        }
    }
}
