using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] pond = new char[size, size];

            int beaverRow = 0;
            int beaverCol = 0;
            int countOfBranches = 0;

            for (int row = 0; row < size; row++)
            {
                char[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = values[col];

                    if (values[col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }

                    if (char.IsLower(values[col]))
                    {
                        countOfBranches++;
                    }
                }
            }

            List<char> branches= new List<char>();
            bool isCollected = false;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (IsValid(command, beaverRow, size, beaverCol, branches, ref countOfBranches)) continue;

                pond[beaverRow, beaverCol] = '-';

                if (command == "up")
                {
                    beaverRow--;

                    if (pond[beaverRow, beaverCol] == 'F')
                    {
                        pond[beaverRow, beaverCol] = '-';
                        if (beaverRow == 0)
                        {
                            beaverRow = size - 1;
                        }
                    }
                }
                else if (command == "down")
                {
                    beaverRow++;

                    if (pond[beaverRow, beaverCol] == 'F')
                    {
                        pond[beaverRow, beaverCol] = '-';
                        if (beaverRow == size - 1)
                        {
                            beaverRow = 0;
                        }
                    }
                }
                else if (command == "left")
                {
                    beaverCol--;

                    if (pond[beaverRow, beaverCol] == 'F')
                    {
                        pond[beaverRow, beaverCol] = '-';
                        if (beaverCol == 0)
                        {
                            beaverCol = size - 1;
                        }
                    }
                }
                else if (command == "right")
                {
                    beaverCol++;

                    if (pond[beaverRow, beaverCol] == 'F')
                    {
                        pond[beaverRow, beaverCol] = '-';
                        if (beaverCol == size - 1)
                        {
                            beaverCol = 0;
                        }
                    }
                }

                if (char.IsLower(pond[beaverRow, beaverCol]))
                {
                    branches.Add(pond[beaverRow, beaverCol]);
                    if (branches.Count == countOfBranches)
                    {
                        isCollected = true;
                        countOfBranches--;
                        pond[beaverRow, beaverCol] = 'B';
                        break;
                    }
                }
                pond[beaverRow, beaverCol] = 'B';
            }

            if (isCollected == true)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countOfBranches - branches.Count} branches left.");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{pond[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValid(string? command, int beaverRow, int size, int beaverCol, List<char> branches,
            ref int countOfBranches)
        {
            if (command == "up" && beaverRow == 0 ||
                command == "down" && beaverRow == size - 1 ||
                command == "left" && beaverCol == 0 ||
                command == "right" && beaverCol == size - 1)
            {
                if (branches.Count>0)
                {
                    branches.RemoveAt(branches.Count - 1);
                    countOfBranches--;
                }

                return true;
            }

            return false;
        }
    }
}
