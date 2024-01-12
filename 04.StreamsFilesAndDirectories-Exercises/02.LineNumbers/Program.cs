﻿using System.Text;

namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new();

            string [] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i <lines.Length; i++)
            {
                int lettersCount = lines[i].Count(ch=>char.IsLetter(ch));
                int symbolsCount = lines[i].Count(ch => char.IsPunctuation(ch));

                sb.AppendLine($"Line {i + 1}: {lines[i]} ({lettersCount})({symbolsCount})");
            }

            File.WriteAllText(outputFilePath, sb.ToString().TrimEnd());
        }
    }
}