namespace _02.DeliveryBoy
{
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

            char[,] area = new char[rows, cols];

            int boyRow = 0;
            int boyCol = 0;

            int boyInitialRow = 0;
            int boyInitialCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string values = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    area[row, col] = values[col];

                    if (values[col] == 'B')
                    {
                        boyRow = row;
                        boyCol = col;
                        boyInitialRow = row;
                        boyInitialCol = col;
                    }
                }
            }

            bool isOutsideArea = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "left")
                {
                    if (boyCol == 0)
                    {
                        if (area[boyRow, boyCol] == '-')
                        {
                            area[boyRow, boyCol] = '.';
                        }

                        isOutsideArea = true;
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        break;
                    }

                    if (area[boyRow, boyCol - 1] == '*')
                    {
                        continue;
                    }

                    if (area[boyRow, boyCol] != 'R')
                    {
                        area[boyRow, boyCol] = '.';
                    }

                    boyCol--;
                }
                else if (command == "right")
                {
                    if (boyCol == cols - 1) // най-дясната колона
                    {
                        if (area[boyRow, boyCol] == '-')
                        {
                            area[boyRow, boyCol] = '.';
                        }

                        isOutsideArea = true;
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        break;
                    }

                    if (area[boyRow, boyCol + 1] == '*')
                    {
                        continue;
                    }

                    if (area[boyRow, boyCol] != 'R')
                    {
                        area[boyRow, boyCol] = '.';
                    }

                    boyCol++;
                }
                else if (command == "up")
                {
                    if (boyRow == 0)
                    {
                        if (area[boyRow, boyCol] == '-')
                        {
                            area[boyRow, boyCol] = '.';
                        }

                        isOutsideArea = true;
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        break;
                    }

                    if (area[boyRow - 1, boyCol] == '*')
                    {
                        continue;
                    }

                    if (area[boyRow, boyCol] != 'R')
                    {
                        area[boyRow, boyCol] = '.';
                    }

                    boyRow--;
                }
                else if (command == "down")
                {
                    if (boyRow == rows - 1)
                    {
                        if (area[boyRow, boyCol] == '-')
                        {
                            area[boyRow, boyCol] = '.';
                        }

                        isOutsideArea = true;
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        break;
                    }

                    if (area[boyRow + 1, boyCol] == '*')
                    {
                        continue;
                    }

                    if (area[boyRow, boyCol] != 'R')
                    {
                        area[boyRow, boyCol] = '.';
                    }

                    boyRow++;
                }

                if (area[boyRow, boyCol] == 'P')
                {
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");

                    area[boyRow, boyCol] = 'R';
                    continue;
                }

                if (area[boyRow, boyCol] == 'A')
                {
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    area[boyRow, boyCol] = 'P';
                    break;
                }
            }


            if (isOutsideArea)
            {
                area[boyInitialRow, boyInitialCol] = ' ';
            }
            else
            {
                area[boyInitialRow, boyInitialCol] = 'B';
            }


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(area[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}