namespace _04.FastFood
{ 
/*
348
20 54 30 16 7 9
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue< int> foodOrders = new Queue< int>(orders);

            Console.WriteLine(foodOrders.Max());

            while (foodOrders.Count > 0 && foodQuantity > 0)
            {
                int currentOrder = foodOrders.Peek();

                if (foodQuantity - currentOrder >= 0)
                {
                    foodOrders.Dequeue();
                    foodQuantity -= currentOrder;
                }
                else
                {
                    break;
                }
            }

            if (foodOrders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", foodOrders)}");
            }
        }
    }
}
