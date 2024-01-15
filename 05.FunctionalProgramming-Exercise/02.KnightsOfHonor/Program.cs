namespace _02.KnightsOfHonor
{
    /*
  Eathan Lucas Noah Arthur
  */
    internal class Program
    {
        static void Main(string[] args)
        {
           string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);  
           
           Action<string, string[]> printNamesWithAddedTitle = (title,names) =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine($"{title} {name}");
                }
            };
           
           printNamesWithAddedTitle("Sir", names);
        }
    }
}
