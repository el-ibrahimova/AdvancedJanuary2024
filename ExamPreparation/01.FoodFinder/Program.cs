using System;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace _01.FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse));

            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse));

            string pear = "pear"; //4
            string flour = "flour"; //5
            string pork = "pork";//4
            string olive = "olive";//5

            int pearLength = 4;
            int flourLength = 5;
            int porkLength = 4;
            int oliveLength = 5;

            List<string> wordCreated = new List<string>();

            while (consonants.Any())            
            {
                char currVowel = vowels.Dequeue();
                vowels.Enqueue(currVowel);
                char currConsonant = consonants.Pop();


                if (pear.Contains(currVowel))
                {
                    pear = pear.Replace(currVowel, ' ');
                    pearLength--;
                }

                if (pear.Contains(currConsonant))
                {
                    pear = pear.Replace(currConsonant, ' ');
                    pearLength--;
                }

                if (flour.Contains(currVowel))
                {
                    flour = flour.Replace(currVowel, ' ');
                    flourLength--;
                }

                if (flour.Contains(currConsonant))
                {
                    flour = flour.Replace(currConsonant, ' ');
                    flourLength--;
                }

                if (pork.Contains(currVowel))
                {
                    pork = pork.Replace(currVowel, ' ');
                    porkLength--;
                }
                
                if (pork.Contains(currConsonant))
                {
                    pork = pork.Replace(currConsonant, ' ');
                    porkLength--;
                }

                if (olive.Contains(currVowel))
                {
                    olive = olive.Replace(currVowel, ' ');
                    oliveLength--;
                }
                
                if (olive.Contains(currConsonant))
                {
                    olive = olive.Replace(currConsonant, ' ');
                    oliveLength--;
                }
            }

            if (pearLength == 0)
            {
                wordCreated.Add("pear");
            }

            if (flourLength == 0)
            {
             wordCreated.Add("flour");
            }

            if (porkLength == 0)
            {
             wordCreated.Add("pork");
            }

            if (oliveLength == 0)
            {
               wordCreated.Add("olive");
            }

            Console.WriteLine($"Words found: {wordCreated.Count}");

            wordCreated.ForEach(Console.WriteLine);
        }
    }
}
  