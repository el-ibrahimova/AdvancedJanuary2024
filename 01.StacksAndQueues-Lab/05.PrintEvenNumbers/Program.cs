namespace _05.PrintEvenNumbers
{
/*
1 2 3 4 5 6
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queueNum = new Queue<int>(numbers);

            string result = string.Empty;

            while (queueNum.Count > 0)
            {
                int number = queueNum.Dequeue();

                if (number % 2 == 0)
                {
                    result += $"{number}, ";
                }
            }

            Console.WriteLine(result.TrimEnd(' ', ',')); // премахваме празното място и запетаята след последния елемент
        }
    }
}
