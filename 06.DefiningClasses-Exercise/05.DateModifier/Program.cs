﻿namespace _05.DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
           string start = Console.ReadLine();
           string end = Console.ReadLine();
            
            int differenceInDays = DateModifier.GetDifferenceInDays(start, end);

           Console.WriteLine(differenceInDays);
        }

    }
}
