using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }
        public List<Drink> Drinks { get; private set; }
        public int ButtonCapacity { get; private set; }

        public int GetCount => Drinks.Count;


        public void AddDrink(Drink drink)
        {
            if (ButtonCapacity > Drinks.Count)
            {
                Drinks.Add(drink);
            }
        }
        public bool RemoveDrink(string name) =>
            Drinks.Remove(Drinks.FirstOrDefault(d => d.Name == name));

        public Drink GetLongest() =>
            Drinks.MaxBy(d => d.Volume);

        public Drink GetCheapest() =>
            Drinks.MinBy(d => d.Price);

        public string BuyDrink(string name) =>
            Drinks.FirstOrDefault(n => n.Name == name).ToString();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Drinks available:");

            foreach (var drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
