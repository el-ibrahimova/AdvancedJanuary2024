namespace _01.GenericBoxOfString
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<string> boxOfString = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                boxOfString.Add(input);
            }

            Console.WriteLine(boxOfString.ToString());
        }
    }
}
