namespace _01.RubberDuckDebuggers
{
/*
10 15 12 18 22 6
12 16 5 6 9 1
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] time = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] tasks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> programmerTime = new Queue<int>(time);
            Stack< int> task = new Stack< int>(tasks);

            int dartVaderCount = 0;
            int thorCount = 0;
            int bigBlueRubberCount = 0;
            int smallYellowRubberCount = 0;
            
            while (programmerTime.Any() && task.Any())
            {
                int currentTime = programmerTime.Peek();
                int currentTask = task.Peek();

                int result = currentTask * currentTime;
               
                if (result > 0 && result <= 60)
                {
                    dartVaderCount++;
                    programmerTime.Dequeue();
                    task.Pop();
                }
                else if (result > 60 && result <= 120)
                {
                    thorCount++;
                    programmerTime.Dequeue();
                    task.Pop();
                }
                else if (result > 120 && result <= 180)
                {
                    bigBlueRubberCount++;
                    programmerTime.Dequeue();
                    task.Pop();
                }
                else if (result > 180 && result <= 240)
                {
                    smallYellowRubberCount++;
                    programmerTime.Dequeue();
                    task.Pop();
                }
                else
                {
                    currentTask -= 2;
                    task.Pop();
                    task.Push(currentTask);
                    programmerTime.Dequeue();
                    programmerTime.Enqueue(currentTime);
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {dartVaderCount}");
            Console.WriteLine($"Thor Ducky: {thorCount}");
            Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueRubberCount}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {smallYellowRubberCount}");
        }
    }
}
