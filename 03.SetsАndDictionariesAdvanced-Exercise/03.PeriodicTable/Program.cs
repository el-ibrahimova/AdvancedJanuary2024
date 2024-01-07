namespace _03.PeriodicTable
{
 /*
4
Ce O
Mo O Ce
Ee
Mo
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> periodicElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                periodicElements.UnionWith(elements);  // обединява елементите, като запазва тяхната уникалност, т.е. няма повтарящи се
            }

            Console.WriteLine(string.Join(" ", periodicElements));
        }
    }
}
