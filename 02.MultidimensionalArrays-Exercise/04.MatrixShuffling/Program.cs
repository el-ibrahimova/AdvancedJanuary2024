using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace _04.MatrixShuffling
{
    /*
    2 3
    1 2 3
    4 5 6
    swap 0 0 1 1
    swap 10 9 8 7
    swap 0 1 1 0
    END
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            // read the commands
            string command = Console.ReadLine();

            while (command != "END")
            {
                if (isValidCommand(command, rows, cols))
                {
                    // валидна команда -> изпълняваме я

                    string[] splittedCommand = command.Split();

                    string element1 = matrix[int.Parse(splittedCommand[1]), int.Parse(splittedCommand[2])];
                    string element2 = matrix[int.Parse(splittedCommand[3]), int.Parse(splittedCommand[4])];

                    matrix[int.Parse(splittedCommand[1]), int.Parse(splittedCommand[2])] = element2;
                    matrix[int.Parse(splittedCommand[3]), int.Parse(splittedCommand[4])] = element1;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }

            static bool isValidCommand(string command, int rows, int cols)
            {
                // command = "swap 1 2 0 3"

                string[] commandParts = command.Split(" "); // ["swap", "1", "2", "0", "3"]
                

                //1. валидираме името
                bool isValidName = commandParts[0] == "swap";

                //2. валидираме броя на елементите
                bool isValidCountParts = commandParts.Length == 5;

                bool isValidRowsAndCols = false;

                if (isValidName && isValidCountParts)
                {
                    int row1 = int.Parse(commandParts[1]);
                    int col1 = int.Parse(commandParts[2]);
                    int row2 = int.Parse(commandParts[3]);
                    int col2 = int.Parse(commandParts[4]);
                   
                    //3. валидни ли са редовете и колоните
                    isValidRowsAndCols = row1 >= 0 && row1 < rows
                                                   && col1 >= 0 && col1 < cols
                                                   && row2 >= 0 && row2 < rows
                                                   && col2 >= 0 && col2 < cols;
                }

                return isValidRowsAndCols && isValidCountParts && isValidName;
            }


            static void PrintMatrix(string[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
