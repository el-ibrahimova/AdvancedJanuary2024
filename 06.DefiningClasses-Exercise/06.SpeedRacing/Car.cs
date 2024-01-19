using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }


        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set { travelledDistance = value; }
        }

        public void Drive(int amountOfKilometer)
        {
            if (amountOfKilometer * FuelConsumptionPerKilometer <= FuelAmount)
            {
                FuelAmount -= amountOfKilometer * FuelConsumptionPerKilometer;
                TravelledDistance += amountOfKilometer;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
