using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.VisualBasic;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsimption;
        private Engine engine;
        private Tire[] tires;

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
        {
            Make = make;
            Model = model;
            Year = year;
            Engine = engine;
            Tires = tires;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsimption; }
            set { fuelConsimption = value; }
        }
       
        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public double Drive(double distance)
        {
            FuelQuantity -= distance * FuelConsumption / 100;
            return FuelQuantity;
        }
    }
}