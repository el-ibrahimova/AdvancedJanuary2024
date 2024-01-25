namespace _03.GenericSwapMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = new();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                items.Add(input);
            }

            int[] indices = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indices[0];
            int secondIndex = indices[1];

            Swap(firstIndex, secondIndex, items);

            foreach (var item in items)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        static void Swap<T>(int firstIndex, int secondIndex, List<T> items)
        {
            T temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;

            // друг вариант на обръщане на стойностите, когато променливите са инициализирани

            // (items[secondIndex], items[firstIndex]) = (items[firstIndex], items[secondIndex]);
        }
    }
}
