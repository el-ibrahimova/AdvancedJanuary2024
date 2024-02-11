using System.Diagnostics.Metrics;

namespace _04.SearchingAlgorithms_BinarySearch
{
    internal class Program
    {
        class Counter
        {
            public static int Count = 0;
        }
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            int element = int.Parse(Console.ReadLine());
         // Console.WriteLine($"List count: {list.Count}");

            Console.WriteLine(BinarySearch(list, 0, list.Count, element));

            int BinarySearch(List<int> list, int start, int end, int element)
            {
               //дъно на рекурсията
                if (end < -1 || start >= list.Count || end < start)
                {
                    return -1;
                }

                int middle = (start + end) / 2;

                if (list[middle] == element)
                {
                    return middle;
                }

                Console.WriteLine($"Operation {++Counter.Count}");

                if (list[middle] > element)
                {
                    return BinarySearch(list, start, middle - 1, element);
                }
                else
                {
                    return BinarySearch(list, middle + 1, end, element);
                }
            }
        }
    }
}