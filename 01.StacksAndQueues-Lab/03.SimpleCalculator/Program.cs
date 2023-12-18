using System.Collections.Generic;
namespace _03.SimpleCalculator
{ 
/*
2 + 5 + 10 - 2 - 1
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack< string> expression = new Stack<string>(input.Reverse());
            // налага се да обърнем елементите, за да може да почнем да смятаме от първия елемент, т.е. от последно добавения в стека

            int result = int.Parse(expression.Pop()); //2

            while (expression.Any()) //докато в expression има някакви елементи
            {
                string sign = expression.Pop();
                int number = int.Parse(expression.Pop());

                if (sign == "+")
                {
                    result += number;
                }
                else // sign == "-"
                {
                    result -= number;
                }
            }

            Console.WriteLine(result);
        }
    }
}
