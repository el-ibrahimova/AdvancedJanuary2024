namespace _02.SetsOfElements
{
    /*
    4 3
    1
    3
    5
    7
    3
    4
    5
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] counts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int first = counts[0];
            int second = counts[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < first; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < second; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            // метод от библиотеката HashSet, който избира общите елементи от два сета (в случая по реда, в който се появяват в първия сет)
            firstSet.IntersectWith(secondSet);

            // други методи от библиотеката HashSet - връщат като резултат сет
           
            // first.UnionWith(second);  => обединява елементите от двата сета
            // first.ExceptWith(second); => вземи елементите, които са уникални за първия сет и не се припокриват с втория
            // first.SymmetricExceptWith(second); => Обратно на IntersectWith
            
            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
