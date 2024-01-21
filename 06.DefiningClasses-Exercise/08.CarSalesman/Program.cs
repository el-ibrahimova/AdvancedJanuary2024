using System;
using System.Collections.Generic;

namespace _08.CarSalesman;

public class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new();
        List<Engine> engines = new();

        int countEngines = int.Parse(Console.ReadLine());

        for (int i = 0; i < countEngines; i++)
        {
            string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Engine engine = CreateEngine(engineInfo);

            engines.Add(engine);
        }

        int countCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < countCars; i++)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = CreateCar(carInfo, engines);

            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }

    static Engine CreateEngine(string[] engineInfo)
    {
        Engine engine = new(engineInfo[0], int.Parse(engineInfo[1]));

        if (engineInfo.Length > 2)
        {
            int displacement;

            bool isDigit = int.TryParse(engineInfo[2], out displacement); // ако не е число = int= displacement, тогава е string= efficiency

            if (isDigit)
            {
                engine.Displacement = displacement;
            }
            else
            {
                engine.Efficiency = engineInfo[2];
            }

            if (engineInfo.Length > 3)
            {
                engine.Efficiency = engineInfo[3];
            }
        }

        return engine;
    }

    static Car CreateCar(string[] carInfo, List<Engine> engines)
    {
        Engine engine = engines.Find(x => x.Model == carInfo[1]);

        Car car = new(carInfo[0], engine);

        if (carInfo.Length > 2)
        {
            int weight;

            bool isDigit = int.TryParse(carInfo[2], out weight);

            if (isDigit)
            {
                car.Weight = weight;
            }
            else
            {
                car.Color = carInfo[2];
            }

            if (carInfo.Length > 3)
            {
                car.Color = carInfo[3];
            }
        }

        return car;
    }
}