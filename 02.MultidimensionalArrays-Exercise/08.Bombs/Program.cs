using System.ComponentModel.Design;

namespace _08.Bombs
{
    /*
    4
    8 3 2 5
    6 4 7 9
    9 9 3 6
    6 8 1 2
    1,2 2,1 2,0
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] values = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            string[] coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    for (int i = 0; i < coordinates.Length; i++)
                    {
                        string[] index = coordinates[i].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
                        int bombRow = int.Parse(index[0]);
                        int bombCol = int.Parse(index[1]);

                        CalculateNewValues(matrix, bombRow, bombCol, n);
                    }
                }
            }

            int count = 0;
            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        count++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        static void CalculateNewValues(int[,] matrix, int bombRow, int bombCol, int n)
        {
            int bombStrength = matrix[bombRow, bombCol];

            if (bombStrength > 0)
            {
                if (IsValid(n, bombRow - 1, bombCol - 1))
                {
                    if (matrix[bombRow - 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= bombStrength;
                    }
                }

                if (IsValid(n, bombRow - 1, bombCol))
                {
                    if (matrix[bombRow - 1, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= bombStrength;
                    }
                }

                if (IsValid(n, bombRow - 1, bombCol + 1))
                {
                    if (matrix[bombRow - 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= bombStrength;
                    }
                }

                if (IsValid(n, bombRow, bombCol - 1))
                {
                    if (matrix[bombRow, bombCol - 1] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= bombStrength;
                    }
                }

                if (IsValid(n, bombRow, bombCol + 1))
                {
                    if (matrix[bombRow, bombCol + 1] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= bombStrength;
                    }
                }

                if (IsValid(n, bombRow + 1, bombCol - 1))
                {
                    if (matrix[bombRow + 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= bombStrength;
                    }
                }

                if (IsValid(n, bombRow + 1, bombCol))
                {
                    if (matrix[bombRow + 1, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= bombStrength;
                    }
                }


                if (IsValid(n, bombRow + 1, bombCol + 1))
                {
                    if (matrix[bombRow + 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= bombStrength;
                    }
                }

                if (IsValid(n, bombRow, bombCol))
                {
                    if (matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow, bombCol] = 0;
                    }
                }
            }
        }

        static bool IsValid(int n, int bombRow, int bombCol)
        {
            return bombRow >= 0 && bombRow < n && bombCol >= 0 && bombCol < n;
        }
    }
}