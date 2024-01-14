namespace _03.CountUppercaseWords
{
    /*
     The following example shows how to use Function
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> checker = n => n[0] == n.ToUpper()[0];  // Func, който проверява дали всяка първа буква от думата е главна. Връща true ако е главна

            // Func<string, bool> checker = n => n[0] == n.ToUpper()[0];  - така се записва със Func

            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => checker(w))
                .ToArray();

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
