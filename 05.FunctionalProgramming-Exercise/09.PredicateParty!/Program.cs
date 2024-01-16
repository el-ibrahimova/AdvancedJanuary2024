using System.Dynamic;

namespace _09.PredicateParty_
{
/*
Peter Misha Stephen
Remove StartsWith P
Double Length 5
Party!
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Remove")
                {
                    people.RemoveAll(GetPredicate(filter, value));
                }
                else // "Double"
                {
                    List<string> peopleToDouble = people.FindAll(GetPredicate(filter, value));

                    foreach (var person in peopleToDouble)
                    {
                        int index = people.FindIndex(p => p == person); // намираме индекса на този човек, за да може да го дублираме веднага, а не на края на листа
                        people.Insert(index,person);
                    }
                }
            }

            if (people.Any())
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "StartsWith":
                    return p => p.StartsWith(value);
                case "EndsWith":
                    return p => p.EndsWith(value);
                case "Length":
                    return p => p.Length == int.Parse(value);
                default:
                    return default;  // ако няма адекватен отговор, да се върне дефолтната стойност(ако е int =0, ако е string = null)
             }
        }
    }
}
