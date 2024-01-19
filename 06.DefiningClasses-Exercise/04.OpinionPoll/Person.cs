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


        public Person()  // дефолтен конструктор. Ако няма друг конструктор, на който да са подадени стойности, тогава се изпълнява този
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int age) : this() // връщаме се към дефолтния конструктор, за да сетнем Name
        {
            this.Age = age;
        }

        public Person(string name, int age) : this(age) // връщаме се към горния конструктор, за да сетнем Age, защото там вече е зададено и да не повтаряме същия код в този конструктор
        {
            this.Name = name;
        }


        public string Name  // записано по един начин
        {
            get => this.name;
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
