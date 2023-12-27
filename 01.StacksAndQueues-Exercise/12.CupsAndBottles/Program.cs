namespace _12.CupsAndBottles
{ 
/*
4 2 10 5
3 15 15 11 6
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputCups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue< int> cups = new Queue< int>(inputCups);
            Stack<int> bottles = new Stack<int>(inputBottles);

            int wastedWater = 0;
          
            while (cups.Count >0 && bottles.Count >0)
            {
                int currentBottle = bottles.Pop();
                int currentCup = cups.Dequeue();

                if (currentCup <= currentBottle)
                {
                    wastedWater += currentBottle-currentCup;
                    continue;
                }
                else
                {
                    currentCup -= currentBottle;

                    while (currentCup > 0)
                    {
                        currentCup -= bottles.Pop();

                        if (currentCup < 0)
                        {
                            // 2 < -4 => 2 - 4 = - 2
                            wastedWater += currentCup * -1;
                        }
                    }
                }
            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
