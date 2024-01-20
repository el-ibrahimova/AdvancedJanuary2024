using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Car
    {
        private string model;

        public Car(string model, 
            int speed, 
            int power, 
            int weight, 
            string type, 
            double tyre1pressure, int type1age, 
            double tyre2pressure, int type2age,
            double tyre3pressure, int type3age, 
            double tyre4pressure, int type4age)
        {
            Model = model;
            Engine = new Engine(speed, power);
            Cargo = new Cargo(weight, type);
            Tyres = new Tyre[4];
            Tyres[0] = new Tyre(tyre1pressure, type1age);
            Tyres[1] = new Tyre(tyre2pressure, type2age);
            Tyres[2] = new Tyre(tyre3pressure, type3age);
            Tyres[3] = new Tyre(tyre4pressure, type4age);
        }
        
        
        public string Model
        {
            get { return model; }
            set { this.model = value; }
        }


        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tyre[] Tyres { get; set; }
    }
}
