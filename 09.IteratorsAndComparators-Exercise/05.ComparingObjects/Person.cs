using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other) //  връща -1, 0 или 1
        {
            int result = this.Name.CompareTo(other.Name);
            
            if (result != 0)
            {
                return result;
            }

            // => Имената са различни => срявняваме по години

            result = this.Age.CompareTo(other.Age);

            if (result != 0)
            {
                return result;
            }
            // => годините са различни => срявняваме по град

            result =  this.Town.CompareTo(other.Town);

            return result;
        }
    }
}
