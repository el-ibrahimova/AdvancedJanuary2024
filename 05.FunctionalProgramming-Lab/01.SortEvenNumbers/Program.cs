namespace _01.SortEvenNumbers
{
    /*
   4, 2, 1, 3, 5, 7, 1, 4, 2, 12
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> evenNumbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(x=>x%2 == 0)
                .OrderBy(x=>x)
                .ToList();

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
