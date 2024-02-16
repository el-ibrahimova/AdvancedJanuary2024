using System;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace _01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guest = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> plate = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int wastedFood = 0;

            while (guest.Any() && plate.Any())
            {
                int currentPlate = plate.Peek();
                int currentGuest = guest.Peek();

                int result = currentGuest - currentPlate;

                if (result <= 0)
                {
                    wastedFood += result;
                    plate.Pop();
                    guest.Dequeue();
                }
                else //(result > 0)
                {
                    guest.Dequeue();
                    plate.Pop();

                    guest = new Queue<int>(guest.Reverse());
                    guest.Enqueue(result);
                    guest = new Queue<int>(guest.Reverse());
                }
            }

            if (guest.Count > 0) 
            {

                Console.WriteLine($"Guests: {string.Join(" ", guest)}");
            }

            if (plate.Count > 0) 
            {

                Console.WriteLine($"Plates: {string.Join(" ", plate)}");
            }

            Console.WriteLine($"Wasted grams of food: {Math.Abs(wastedFood)}");
        }
    }
}
