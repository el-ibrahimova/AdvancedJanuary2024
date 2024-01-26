using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T element) // ако този метод не е static, в StartUp ще трябва първо да направим инстанция на класа ArrayCreator, тогава да извикаме този метод. По този начин директно имаме достъп до него
        {
            T[]array = new T[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = element;
            }

            return array;
        }
    }
}
