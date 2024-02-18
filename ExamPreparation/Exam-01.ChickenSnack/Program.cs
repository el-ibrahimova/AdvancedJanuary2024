namespace Exam_01.ChickenSnack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] stack = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int[] queue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            Stack<int> money = new Stack<int>(stack);
            Queue<int> priceOfFood = new Queue<int>(queue);

            int eatenFood = 0;

            while (money.Any() && priceOfFood.Any())
            {
                int currentMoney = money.Peek();
                int currentPrice = priceOfFood.Peek();

                if (currentPrice == currentMoney)
                {
                    eatenFood++;
                    money.Pop();
                    priceOfFood.Dequeue();
                }
                else if (currentMoney > currentPrice)
                {
                    int result = currentMoney - currentPrice;
                    money.Pop();

                    if (money.Count == 0)
                    {
                        money.Push(result);
                    }
                    else
                    {
                        int add = money.Peek() + result;
                        money.Pop();
                        money.Push(add);
                    }

                    priceOfFood.Dequeue();
                    eatenFood++;
                }
                else
                {
                    money.Pop();
                    priceOfFood.Dequeue();
                }
            }

            if (eatenFood >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {eatenFood} foods.");
            }
            else if (eatenFood >= 1)
            {
                if (eatenFood == 1)
                {
                    Console.WriteLine($"Henry ate: {eatenFood} food.");
                }

                if (eatenFood > 1)
                {
                    Console.WriteLine($"Henry ate: {eatenFood} foods.");
                }
            }
            else if (eatenFood == 0)
            {
                Console.WriteLine($"Henry remained hungry. He will try next weekend again.");
            }
        }
    }
}
