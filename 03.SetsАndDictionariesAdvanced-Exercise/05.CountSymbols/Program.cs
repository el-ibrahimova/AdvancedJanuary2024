namespace _05.CountSymbols
{
/*
SoftUni rocks
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> countChars = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!countChars.ContainsKey(text[i]))
                {
                    countChars.Add(text[i], 0);
                }
                countChars[text[i]]++;
            }

            foreach (var chars in countChars)
            {
                Console.WriteLine($"{chars.Key}: {chars.Value} time/s");
            }
        }
    }
}
