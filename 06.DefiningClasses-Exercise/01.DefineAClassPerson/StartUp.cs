﻿namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           Person person = new();

           person.Name = "Peter";
           person.Age = 20;

           Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}
