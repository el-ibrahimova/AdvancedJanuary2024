namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new();

            Console.WriteLine($"{person.Name}: {person.Age}");
        }
    }
}
