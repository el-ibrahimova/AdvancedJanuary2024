namespace _03.PrimaryDiagonal
{
/*
3
11 2 4
4 5 6
10 8 -12
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowValues = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            // намиране на сумата на елементите по диагонал
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            Console.WriteLine(sum);

            // намиране на сумата на елементите по обратен диагонал
            // for (int i = 0; i < matrix.GetLength(0); i++)
            // {
            //      sum += matrix[i, matrix.GetLength(1) - i - 1];
            // }

        }
    }
}
