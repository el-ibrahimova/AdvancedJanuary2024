using System.ComponentModel;

namespace _01.TempleOfDoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] toolsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] substancesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> challenges = Console.ReadLine().Split().Select(int.Parse).ToList();

            Queue<int> tools = new Queue<int>(toolsInput);
            Stack<int> substances = new Stack<int>(substancesInput);


            while (tools.Any() && substances.Any())
            {
                int curTool = tools.Peek();
                int curSub = substances.Peek();

                int result = curSub * curTool;

                if (challenges.Contains(result))
                {
                    tools.Dequeue();
                    substances.Pop();
                    challenges.Remove(result);
                }
                else
                {
                    curTool++;
                    tools.Dequeue();
                    tools.Enqueue(curTool);

                    curSub--;
                    substances.Pop();

                    if (curSub != 0)
                    {
                        substances.Push(curSub);
                    }
                }
            }

            if (challenges.Count != 0)
            {
                Console.WriteLine($"Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine($"Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            if (tools.Any())
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }
            
            if (substances.Any())
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }
           
            if (challenges.Any())
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}
