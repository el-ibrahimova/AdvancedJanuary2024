namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
          //   List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
          // вместо да изписваме листа, директно го записваме new Stack<int> (..........);

            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        }
    }
}
