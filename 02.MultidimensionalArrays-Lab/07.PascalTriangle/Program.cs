namespace _07.PascalTriangle
{
    /*
     4
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] pascal = new long[rows][];

            pascal[0] = new long[1] { 1 };

            // find values of each cell
            for (int row = 1; row < rows; row++)
            {
                pascal[row] = new long[row + 1];

                for (int col = 0; col < pascal[row].Length; col++)
                {
                    if (col < pascal[row - 1].Length)
                    {
                        pascal[row][col] += pascal[row - 1][col];
                    }

                    if (col > 0)
                    {
                        pascal[row][col] += pascal[row - 1][col - 1];
                    }
                }
            }

            // print result
            for (int row = 0; row < pascal.Length; row++)
            {
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write($"{pascal[row][col]} ");
                }

                Console.WriteLine();
            }

            //  print result with foreach
           //  foreach (long[] row in pascal)
           //  {
           //     Console.WriteLine(string.Join(" ", row));
           //  }

        }
    }
}
