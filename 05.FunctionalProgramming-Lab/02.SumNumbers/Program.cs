namespace _02.SumNumbers
{
    /*
  4, 2, 1, 3, 5, 7, 1, 4, 2, 12
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = n => int.Parse(n); // Func за парсване на числата, прочетени от конзолата, към тип int
            
            int[] numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
