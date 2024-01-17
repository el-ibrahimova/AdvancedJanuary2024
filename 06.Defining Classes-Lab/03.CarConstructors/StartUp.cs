namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car("BMW", "X3", 2006, 500, 300);
            Car car2= new Car("BMW", "X3", 2006);
            Car car3= new Car();

            car.Drive(5);

            Console.WriteLine(car.WhoAmI());
        }
    }
}