using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T> // за да може да сравняваме стрингове, задаваме constraints where T: IComparable<T>
    {
        private List<T> items;

        public Box()
        {
            items = new();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public int CountMethod(T itemToCompare)
        {
            int count = 0;
            foreach (T item in items)
            {
                if (item.CompareTo(itemToCompare) > 0) // ако не е по-голямо връща -1, т.е. ако връща положително число то стринга е по-голям. Ако върне 0, значи са еднакви
                {
                    count++;
                }
            }
            return count;
        }
    }
}
