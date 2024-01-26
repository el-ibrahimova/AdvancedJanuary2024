namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqalityScale<int> scale = new EqalityScale<int>(5, 5);

            Console.WriteLine(scale.AreEqual());
        }
    }
}
