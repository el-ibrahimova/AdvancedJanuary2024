namespace _10.Crossroads
{
/*
10
5
Mercedes
green
Mercedes
BMW
Skoda
green
END
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());
           
            Queue<string> cars = new Queue<string>();

            int passedCars = 0;
            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                    command = Console.ReadLine();
                    continue;
                }

                int currentGreenLightSeconds = greenLightSeconds;

                while (cars.Count>0 && currentGreenLightSeconds >0)
                {
                    string currentCar = cars.Dequeue();  

                    if (currentGreenLightSeconds - currentCar.Length>=0) // 10-8>0
                    {
                       currentGreenLightSeconds -= currentCar.Length;
                       passedCars++;
                        continue;
                    }
                    else if (currentGreenLightSeconds + freeWindowSeconds - currentCar.Length>= 0) // 2 + 5 - 3 >0
                    {
                        passedCars++;
                        break;
                    }
                    else // crash
                    {
                        char hittedSymbol = currentCar[currentGreenLightSeconds + freeWindowSeconds];
                        
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {hittedSymbol}.");

                        Environment.Exit(0);
                        // return;
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
