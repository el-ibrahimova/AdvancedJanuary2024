namespace _02.Garden
{
    /*
   5 5
   1 1
   3 3
   Bloom Bloom Plow
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

            int[,] garden = new int[rows, cols];


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Bloom Bloom Plow")
                {
                    break;
                }

                string[] indexFlowers = command
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int flowerRow = int.Parse(indexFlowers[0]);
                int flowerCol = int.Parse(indexFlowers[1]);

                if (IsValid(flowerRow, flowerCol, garden))
                {
                    garden[flowerRow, flowerCol] = 1;

                    FillBloomingFlowers(rows, flowerRow, flowerCol, garden, cols);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                    return;
                }
            }
            

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{garden[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static void FillBloomingFlowers(int rows, int flowerRow, int flowerCol, int[,] garden, int cols)
        {
            for (int i = 1; i < rows; i++)
            {
                if (IsValid(flowerRow - i, flowerCol, garden))
                {
                    garden[flowerRow - i, flowerCol] += 1;
                }

                if (IsValid(flowerRow + i, flowerCol, garden))
                {
                    garden[flowerRow + i, flowerCol] += 1;
                }
            }

            for (int i = 1; i < cols; i++)
            {
                if (IsValid(flowerRow, flowerCol - i, garden))
                {
                    garden[flowerRow, flowerCol - i] += 1;
                }

                if (IsValid(flowerRow, flowerCol + i, garden))
                {
                    garden[flowerRow, flowerCol + i] += 1;
                }
            }
        }

        static bool IsValid(int row, int col, int[,] garden)
        {
            return row >= 0 && row < garden.GetLength(0) && col >= 0 && col < garden.GetLength(1);
        }
    }
}
