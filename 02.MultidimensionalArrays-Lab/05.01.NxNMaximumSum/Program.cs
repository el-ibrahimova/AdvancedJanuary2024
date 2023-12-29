using System.Data;

namespace _05._01.NxNMaximumSum
{
    internal class Program
    {
        /*
      3, 6
      3
      7, 1, 3, 3, 2, 1
      1, 3, 9, 8, 5, 6
      4, 6, 7, 9, 1, 0
      */
        static void Main(string[] args)
        {

            Console.Write("Write the size of the matrix: ");
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            Console.Write("Write the size of subMatrix: ");
            int n = int.Parse(Console.ReadLine());

            // check if n is bigger than rows or cols
            if (n > rows || n > cols)
            {
                Console.WriteLine("ERROR: The size of the submatrix can't be bigger than the size of the matrix!");
                return;
            }

            int[,] matrix = new int[rows, cols];

            // fill the matrix
            for (int row = 0; row < rows; row++)
            {
                Console.Write("Write the values of the row: ");
                int[] rowValues = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            // find maxSum
            int maxRow = 0;
            int maxCol = 0;
            int maxSum = int.MinValue;

            for (int row = 0; row <= rows - n; row++)
            {
                for (int col = 0; col <= cols - n; col++)
                {
                    int sum = 0;

                    // for-loop of the NxN submatrix
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            sum += matrix[row + i, col + j];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            // print result
            Console.Write($"Max sum of the subMatrix is: {maxSum}");
            Console.WriteLine();
            Console.WriteLine("Submatrix with max sum is located with values: ");

            for (int i = maxRow; i < maxRow + n; i++)
            {
                for (int j = maxCol; j < maxCol + n; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
