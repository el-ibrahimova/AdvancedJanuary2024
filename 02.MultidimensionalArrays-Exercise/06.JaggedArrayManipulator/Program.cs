namespace _06.JaggedArrayManipulator
{
    /*
    5
    10 20 30
    1 2 3
    2
    2
    10 10
    End
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];

            // попълавме матрицата
            for (int row = 0; row < rows; row++)
            {
                double[] cols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedArray[row] = cols;
            }

            // проверяваме дали дължината на редовете е еднаква
            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;

                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            // изпълняваме командите
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (true)
                {
                    if (tokens[0] == "Add")
                    {
                        int row = int.Parse(tokens[1]);
                        int col = int.Parse(tokens[2]);
                        int value = int.Parse(tokens[3]);

                        if (IsValidCoordinates(row, col, jaggedArray))
                        {
                            jaggedArray[row][col] += value;
                        }
                    }
                    else // "substract"
                    {
                        int row = int.Parse(tokens[1]);
                        int col = int.Parse(tokens[2]);
                        int value = int.Parse(tokens[3]);

                        if (IsValidCoordinates(row, col, jaggedArray))
                        {
                            jaggedArray[row][col] -= value;
                        }
                    }
                }
            }

            for (int row = 0; row < rows; row++) // Отпечатваме резултата 
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }

                Console.WriteLine();
            }
        }

        static bool IsValidCoordinates(int row, int col, double[][] jaggedArray)
        {
            return row >= 0 && 
                   row < jaggedArray.Length && 
                   col >= 0 && 
                   col < jaggedArray[row].Length;
        }
    }
}

