namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> personOver30 = new List<Person>();
            
            int count = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new(name, age);

                if (person.Age > 30)
                {
                    personOver30.Add(person);
                }
            }

            foreach (var person in personOver30.OrderBy(p=>p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}