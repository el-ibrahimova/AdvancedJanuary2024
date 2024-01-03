using System.Numerics;

namespace _10.RadioactiveMutantVampireBunnies
{
    /*
5 8
.......B
...B....
....B..B
........
..P.....
ULLL
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                    
                    if (input[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[playerRow, playerCol] = '.';
                    }
                }
            }

            string directions = Console.ReadLine();

            foreach (char direction in directions)
            {
                int oldPlayerRow = playerRow;
                int oldPlayerCol = playerCol;

                switch (direction)
                {
                    case 'L':
                        playerCol--;
                        break;

                    case 'R':
                        playerCol++;
                        break;

                    case 'U':
                        playerRow--;
                        break;

                    case 'D':
                        playerRow++;
                        break;
                }

                matrix = SpreadBunnies();

                // проверяваме дали играча не е излезнал от полето
                if (playerRow < 0
                    || playerRow >= rows
                    || playerCol < 0
                    || playerCol >=cols)
                {
                    PrintResult(oldPlayerRow, oldPlayerCol, "won");
                    break;
                }

                // ако на индекса на играча е стъпил заек, то играча е умрял
                if (matrix[playerRow, playerCol] == 'B') 
                {
                    PrintResult(playerRow, playerCol, "dead");
                    break;
                }
            }
            
            char[,] SpreadBunnies()
            {
                char[,] newMatrix = new char[rows, cols];

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        newMatrix[row, col] = matrix[row, col];
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'B') // ако на индекса има заек, тогава го разпространяваме
                        {
                            if (row > 0) //up
                            {
                                newMatrix[row - 1, col] = 'B';
                            }

                            if (row < rows - 1) //down
                            {
                                newMatrix[row + 1, col] = 'B';
                            }

                            if (col > 0) //left
                            {
                                newMatrix[row, col - 1] = 'B';
                            }

                            if (col < cols - 1) //right
                            {
                                newMatrix[row, col + 1] = 'B';
                            }
                        }
                    }
                }
                return newMatrix;
            }


            void PrintResult(int playerRow, int playerCol, string result)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine($"{result}: {playerRow} {playerCol}");
            }
        }
    }
}
