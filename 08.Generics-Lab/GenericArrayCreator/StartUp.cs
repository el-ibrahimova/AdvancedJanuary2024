namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string [] list = ArrayCreator.Create(10, "Hello");

            Console.WriteLine(String.Join(" ", list));
        }
    }
}
