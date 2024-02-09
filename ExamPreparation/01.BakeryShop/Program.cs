namespace _01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] waterArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse)
                .ToArray(); 
            
            double[] flourArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse)
                .ToArray();
            
            Stack<double> flour = new Stack<double>(flourArr);
            Queue<double> water = new Queue<double>(waterArr);

            Dictionary<string, int> product = new Dictionary<string, int>
            {
                {"Croissant", 0 },
                {"Muffin", 0 },
                {"Baguette", 0 },
                {"Bagel", 0 }
            };
            
            while (flour.Any() && water.Any())
            {
                double currentFlour = flour.Peek();
                double currenWater = water.Peek();

                double result = currenWater + currentFlour;
                double fl = (currentFlour / result) * 100;
                double wt = (currenWater / result) * 100;

                if (fl == 50 && wt ==50)
                {
                    product["Croissant"]++;
                    flour.Pop();
                    water.Dequeue();
                }
                else if (fl== 60 && wt == 40)
                {
                    product["Muffin"]++;
                    flour.Pop();
                    water.Dequeue();
                }
                else if (fl == 70 && wt == 30)
                {
                    product["Baguette"]++;
                    flour.Pop();
                    water.Dequeue();
                }
                else if (fl == 80 && wt ==20)
                {
                    product["Bagel"]++;
                    flour.Pop();
                    water.Dequeue();
                }
                else
                {
                    double currFlour = flour.Pop();
                    double currWater = water.Dequeue();
                    double flourReduced = currFlour - currWater;
                    product["Croissant"]++;
                    flour.Push(flourReduced);
                }
            }

            foreach (var item in product.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

            string flourLeft = flour.Count == 0 ? "None" : string.Join(", ", flour);
            string waterLeft = water.Count == 0 ? "None" : string.Join(", ", water);

            Console.WriteLine($"Water left: {waterLeft}");
            Console.WriteLine($"Flour left: {flourLeft}");
        }
    }
}



