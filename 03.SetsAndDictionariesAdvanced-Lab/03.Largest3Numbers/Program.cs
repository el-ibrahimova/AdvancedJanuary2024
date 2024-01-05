namespace _03.Largest3Numbers
{
    /*
    10 30 15 20 50 5
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            //{10 30 15 20 50 5}

            List<int> lagrest3numbers = numbers
               .OrderByDescending(x=>x) // {50, 30, 20, 15, 10, 5}
               .Take(3)  // {50, 30, 20}
               .ToList();

            Console.WriteLine(string.Join(" ", lagrest3numbers));

            // По-кратко решение

          // List<int> numbers = Console.ReadLine()
          //     .Split()
          //     .Select(int.Parse)
          //     .OrderByDescending(x=>x)
          //     .Take(3)
          //     .ToList();
          //   Console.WriteLine(string.Join(" ", numbers);
        }
    }
}
