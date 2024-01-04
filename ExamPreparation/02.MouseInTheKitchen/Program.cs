using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace _02.MouseInTheKitchen
{
    /*
     5,5
       **M**
       T@@**
       CC@**
       **@@*
       **CC*
       left
       down
       left
       down
       down
       down
       right
       danger

     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(",");
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            // Read cupboard matrix
            char[,] cupboard = new char[rows, cols];

            int mouseRow = 0, mouseCol = 0;
            int cheeseCount = 0;

            for (int row = 0; row < rows; row++)
            {
                string values = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    cupboard[row, col] = values[col];

                    if (cupboard[row, col] == 'M')
                    {
                        mouseRow = row;
                        mouseCol = col;
                    }
                    else if (cupboard[row, col] == 'C')
                    {
                        cheeseCount++;
                    }
                }
            }

            // Process mouse movements
            string command;
            while ((command = Console.ReadLine()) != "danger")
            {
                MoveMouse(cupboard, ref mouseRow, ref mouseCol, command, ref cheeseCount);

                if (cheeseCount == 0)
                {
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                    PrintCupboard(cupboard);
                    return;
                }
            }

            Console.WriteLine("Mouse will come back later!");
            Console.WriteLine("No more cheese for tonight!");
            PrintCupboard(cupboard);
        }

        static void MoveMouse(char[,] cupboard, ref int mouseRow, ref int mouseCol, string direction, ref int cheeseCount)
        {
            int newRow = mouseRow;
            int newCol = mouseCol;

            switch (direction)
            {
                case "up":
                    newRow--;
                    break;
                case "down":
                    newRow++;
                    break;
                case "left":
                    newCol--;
                    break;
                case "right":
                    newCol++;
                    break;
            }

            if (IsValid(cupboard, newRow, newCol))
            {
                char nextCell = cupboard[newRow, newCol];

                if (nextCell == '@')
                {
                    // Wall, do nothing
                }
                else if (nextCell == 'C')
                {
                    cupboard[newRow, newCol] = '*';
                    cheeseCount--;

                    if (cheeseCount == 0)
                    {
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        PrintCupboard(cupboard);
                        Environment.Exit(0);
                    }
                }
                else if (nextCell == 'T')
                {
                    cupboard[mouseRow, mouseCol] = '*';
                    cupboard[newRow, newCol] = 'M';
                    Console.WriteLine("Mouse is trapped!");
                    PrintCupboard(cupboard);
                    Environment.Exit(0);
                }
                else
                {
                    cupboard[mouseRow, mouseCol] = '*';
                    cupboard[newRow, newCol] = 'M';
                    mouseRow = newRow;
                    mouseCol = newCol;
                }
            }
        }

        static bool IsValid(char[,] cupboard, int row, int col)
        {
            return row >= 0 && row < cupboard.GetLength(0) && col >= 0 && col < cupboard.GetLength(1);
        }

        static void PrintCupboard(char[,] cupboard)
        {
            for (int i = 0; i < cupboard.GetLength(0); i++)
            {
                for (int j = 0; j < cupboard.GetLength(1); j++)
                {
                    Console.Write(cupboard[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}