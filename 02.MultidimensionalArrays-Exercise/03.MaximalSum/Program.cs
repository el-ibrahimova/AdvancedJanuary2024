namespace _03.MaximalSum
{
/*
4 5
1 5 5 2 4
2 1 4 14 3
3 7 11 2 8
4 8 12 16 4
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }
           
            int maxRow = 0;
            int maxCol = 0;
            int maxSum = int.MinValue;

            for (int row = 0; row < rows-2; row++) // не включваме елементите от последните n редoве
            {
                for (int col = 0; col < cols-2; col++) // не включваме елементите от последните n колони
                {
                    int currentSum =
                        matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row +1, col] + matrix[row+1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row+2, col] + matrix[row +2, col + 1] + matrix[row +2, col + 2];

                    if (currentSum  > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxRow; i < maxRow + 3; i++)
            {
                for (int j = maxCol; j < maxCol + 3; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
