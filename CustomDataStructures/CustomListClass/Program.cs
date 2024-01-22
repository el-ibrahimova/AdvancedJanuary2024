namespace CustomListClass
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new();

            list.Add(100);
            list.Add(123);
            list.Add(234);
            list.Add(345);
            list.Add(456);
            
            Console.WriteLine(list[2]);

            //Console.WriteLine(list.RemoveAt(-1)); грешка
            Console.WriteLine(list.RemoveAt(1));
            Console.WriteLine(list.RemoveAt(1));

           // list.InsertAt(2, -5); грешка
            list.InsertAt(1, -5);
            list.InsertAt(1, 6);

            Console.WriteLine(list.Contains(234));
            Console.WriteLine(list.Contains(100));

            list.Swap(0,1);
            Console.WriteLine();

            list.AddRange(new int[] {1,2,3,4});
        }
    }
}
