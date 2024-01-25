namespace _02.GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<int> boxOfInt = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());
                boxOfInt.Add(input);
            }

            Console.WriteLine(boxOfInt.ToString());
        }
    }
}
