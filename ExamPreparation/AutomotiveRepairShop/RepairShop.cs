﻿using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        private int capacity;
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new();
        }

        public List<Vehicle> Vehicles { get; private set; }

        public int Capacity { get; private set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin) =>
            Vehicles.Remove(Vehicles.FirstOrDefault(v => v.VIN == vin));

        public int GetCount() => Vehicles.Count;

        public Vehicle GetLowestMileage() =>
            Vehicles.MinBy(v => v.Mileage);

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine("Vehicles in the preparatory:");

            foreach (var vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
