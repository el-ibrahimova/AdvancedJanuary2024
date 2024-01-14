namespace _04.AddVAT
{
    /*
     1.38, 2.56, 4.4
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, decimal> parser = s => decimal.Parse(s);
           Func<decimal, decimal> vat = n => n * 1.2m;
           
           List< decimal> prices = Console.ReadLine()
                .Split(", " , StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .Select(vat)
                .ToList();

           foreach (var price in prices)
           {
               Console.WriteLine($"{price:f2}");
           }
        }
    }
}
