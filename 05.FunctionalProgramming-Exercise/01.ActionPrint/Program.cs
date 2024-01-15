namespace _01.ActionPrint
{
    /*
  Lucas Noah Tea
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> print = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            print(names);
            
            //  string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //  Action<string[]> print = (string[] names) =>
            //  {
            //      foreach (string s in names)
            //       {
            //           Console.WriteLine(s);
            //       }
            //  };
            //  print(names);
        }
    }
}
