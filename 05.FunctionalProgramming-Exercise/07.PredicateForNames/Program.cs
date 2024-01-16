using System.Threading.Channels;

namespace _07.PredicateForNames
{ 
/*
4
Karl Anna Kris Yahto
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[], Predicate<string>> print = (names, match) =>
            {
                foreach (var name in names)
                {
                    if (match(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            print(names, n => n.Length <= length);
        }
    }
}
