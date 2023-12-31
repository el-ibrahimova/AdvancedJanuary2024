﻿using System;
using System.Linq;
using System.Collections.Generic;
namespace _04.EvenTimes
{
    /*
   3
   2
   -1
   2
   */
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 0);
                }
                numbers[number]++;
            }

            int result = numbers.Single(x => x.Value % 2 == 0).Key;
            Console.WriteLine(result);


            //  foreach (var num in numbers)
            //  {
            //      if (num.Value % 2 == 0)
            //      {
            //          Console.WriteLine(num.Key);
            //      }
            //  }
            
        }
    }
}
