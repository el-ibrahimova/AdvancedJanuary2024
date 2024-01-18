using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public string Name  // записано по един начин
        {
            get =>this.name; 
            set => this.name = value; 
        }

        public int Age // записано по друг начин
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

    }
}
