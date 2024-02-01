namespace _05.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] personProps = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new()
                {
                    Name = personProps[0],
                    Age = int.Parse(personProps[1]),
                    Town = personProps[2]
                };

                people.Add(person);
            }

            int compareIndex = int.Parse(Console.ReadLine()) - 1; // по условие започваме да сравняваме от 1-ви индекс => за да не пропуснем човека на нулев индекс изваждаме -1

            Person personToCompare = people[compareIndex];

            int equalCount = 0;
            int diffCount = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare)==0) // еднакви са
                {
                    equalCount++;
                }
                else
                {
                    diffCount++;
                }
            }

            if (equalCount == 1) // текущия се е сравнил 1 път със себе си => няма други равни на него => т.е. count трявба да е поне 2
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {diffCount} {people.Count}");
            }
        }
    }
}
