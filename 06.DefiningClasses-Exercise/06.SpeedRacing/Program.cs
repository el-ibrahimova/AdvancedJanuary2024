namespace _06.SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> carsByNames = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new()
                {
                    Model = carInfo[0],
                    FuelAmount = double.Parse(carInfo[1]),
                    FuelConsumptionPerKilometer = double.Parse(carInfo[2])
                };

                carsByNames.Add(car.Model, car);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] driveInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = driveInfo[1];
                int amountOfKilometers = int.Parse(driveInfo[2]);

                Car car = carsByNames[carModel];

                car.Drive(amountOfKilometers);
            }

            foreach (var item in carsByNames.Values)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TravelledDistance}");
            }
        }
    }
}

