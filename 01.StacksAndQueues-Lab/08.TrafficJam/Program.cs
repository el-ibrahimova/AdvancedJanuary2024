using System.Collections.Generic;
namespace _08.TrafficJam
{
  /*
4
Hummer H2
Audi
Lada
Tesla
Renault
Trabant
Mercedes
MAN Truck
green
green
Tesla
Renault
Trabant
end
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPassedCars = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            int totalNumberOfCars = 0;

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < countOfPassedCars; i++)
                    {
                        if (cars.Count==0)
                        {
                            break;
                        }

                        Console.WriteLine($"{cars.Dequeue()} passed!"); ;
                        totalNumberOfCars++;
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"{totalNumberOfCars} cars passed the crossroads.");
        }
    }
}
