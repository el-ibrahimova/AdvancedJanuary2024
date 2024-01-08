namespace _06.Wardrobe
{
    /*
   4
   Blue -> dress,jeans,hat
   Gold -> dress,t-shirt,boxers
   White -> briefs,tanktop
   Blue -> gloves
   Blue dress
   */
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe =
                new Dictionary<string, Dictionary<string, int>>();


            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = tokens[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 1; j < tokens.Length; j++)
                {
                    string currentWear = tokens[j];

                    if (!wardrobe[color].ContainsKey(currentWear))
                    {
                        wardrobe[color].Add(currentWear, 0);
                    }

                    wardrobe[color][currentWear]++;
                }
            }

            string[] searchingWear = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string searchColor = searchingWear[0];
            string searchDress = searchingWear[1];


            foreach (var colorClothes in wardrobe)
            {
                Console.WriteLine($"{colorClothes.Key} clothes:");

                foreach (var wearCount in colorClothes.Value)
                {
                    string printItem = $"* {wearCount.Key} - {wearCount.Value}";

                    if (colorClothes.Key == searchColor && wearCount.Key== searchDress)
                    {
                        printItem += " (found!)";
                    }

                    Console.WriteLine(printItem);
                }
            }
        }
    }
}
