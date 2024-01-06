namespace _06.RecordUniqueNames
{
/*
8
John
Alex
John
Sam
Alex
Alice
Peter
Alex
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                names.Add(name); // добавя само име, което все още го няма
            }

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
