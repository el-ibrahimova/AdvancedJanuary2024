namespace _04.ProductShop
{
    /*
  lidl, juice, 2.30
  fantastico, apple, 1.20
  kaufland, banana, 1.10
  fantastico, grape, 2.20
  Revision
  */
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shop = new SortedDictionary<string, Dictionary<string, double>>();

            string command = Console.ReadLine();

            while (command != "Revision")
            {
                string[] input = command
                               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                               .ToArray();

                string shopName = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);


                if (!shop.ContainsKey(shopName))
                {
                    shop.Add(shopName, new Dictionary<string, double>());
                }
                shop[shopName].Add(product, price);

                command = Console.ReadLine();
            }

            foreach (var entry in shop)
            {
                Console.WriteLine($"{entry.Key}->");
                foreach (var kvp in entry.Value)
                {
                    Console.WriteLine($"Product: {kvp.Key}, Price: {kvp.Value}");
                }
            }
        }
    }
}
