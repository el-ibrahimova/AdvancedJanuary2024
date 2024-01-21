using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> enginesList = new List<Engine>();

            List<Car> cars = new List<Car>();



            string command;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] infoTires = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int year1 = int.Parse(infoTires[0]);
                double pressure1 = double.Parse(infoTires[1]);
                int year2 = int.Parse(infoTires[2]);
                double pressure2 = double.Parse(infoTires[3]);
                int year3 = int.Parse(infoTires[4]);
                double pressure3 = double.Parse(infoTires[5]);
                int year4 = int.Parse(infoTires[6]);
                double pressure4 = double.Parse(infoTires[7]);


                Tire tire1 = new(year1, pressure1);
                Tire tire2 = new(year2, pressure2);
                Tire tire3 = new(year3, pressure3);
                Tire tire4 = new(year4, pressure4);
                Tire[] tires = new Tire[4] { tire1, tire2, tire3, tire4 };

                tiresList.Add(tires);
            }

            string command2;
            while ((command2 = Console.ReadLine()) != "Engines done")
            {
                string[] infoEngines = command2.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int horsePower = int.Parse(infoEngines[0]);
                double cubicCapacity = double.Parse(infoEngines[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                enginesList.Add(engine);
            }


            string command3;
            while ((command3 = Console.ReadLine()) != "Show special")
            {
                string[] input = command3.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = input[0];
                string model = input[1];
                int year = int.Parse(input[2]);
                double fuelQuantity = double.Parse(input[3]);
                double fuelConsumption = double.Parse(input[4]);
                Engine engine = enginesList[int.Parse(input[5])];
                Tire[] tires = tiresList[int.Parse(input[6])];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);
                cars.Add(car);
            }


            //specialCars = cars.Where(car => car.Year >= 2017 && car.Engine.HorsePower > 330 && car.Tires.Sum(y => y.Pressure) >= 9 && car.Tires.Sum(y => y.Pressure) <= 10).ToList();

            foreach (var car in cars)
            {
                double totalPressure = car.Tires.Sum(c => c.Pressure);

                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && totalPressure >= 9 &&
                    totalPressure <= 10)
                {
                    StringBuilder builder = new StringBuilder();

                    car.Drive(20);

                    builder.AppendLine($"Make: {car.Make}");
                    builder.AppendLine($"Model: {car.Model}");
                    builder.AppendLine($"Year: {car.Year.ToString()}");
                    builder.AppendLine($"HorsePowers: {car.Engine.HorsePower.ToString()}");
                    builder.AppendLine($"FuelQuantity: {car.FuelQuantity.ToString()}");

                    Console.Write(builder);
                }
            }
        }
    }
}