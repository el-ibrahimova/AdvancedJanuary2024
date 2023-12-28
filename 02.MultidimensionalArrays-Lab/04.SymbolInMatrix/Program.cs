namespace _04.SymbolInMatrix
{
/*
3
ABC
DEF
X!@
!
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] rowValues = Console.ReadLine().ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isFind = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFind = true;
                        return;
                    }
                }
            }

            if (isFind== false)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
