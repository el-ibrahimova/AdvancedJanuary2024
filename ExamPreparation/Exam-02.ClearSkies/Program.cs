namespace Exam_02.ClearSkies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int jetRow = 0;
            int jetCol = 0;
            int countOfEnemy = 0;

            for (int row = 0; row < size; row++)
            {
                string rowValues = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowValues[col];

                    if (rowValues[col] == 'J')
                    {
                        jetRow = row;
                        jetCol = col;
                    }

                    if (rowValues[col] == 'E')
                    {
                        countOfEnemy++;
                    }
                }
            }

            int armorValue = 300;
            bool isNeutralized = false;

            while (true)
            {
                string command = Console.ReadLine();

                matrix[jetRow, jetCol] = '-';

                if (command == "up")
                {
                    jetRow--;
                }
                else if (command == "down")
                {
                    jetRow++;
                }
                else if (command == "left")
                {
                    jetCol--;
                }
                else if (command == "right")
                {
                    jetCol++;
                }

                if (matrix[jetRow, jetCol] == 'E')
                {
                    matrix[jetRow, jetCol] = '-';
                    countOfEnemy--;

                    if (countOfEnemy == 0)
                    {
                        isNeutralized = true;
                        matrix[jetRow, jetCol] = 'J';
                        Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                        break;
                    }
                    else
                    {
                        armorValue -= 100;
                        if (armorValue <= 0)
                        {
                            matrix[jetRow, jetCol] = 'J';
                            Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{jetRow}, {jetCol}]!");
                            break;
                        }
                    }
                }
                else if (matrix[jetRow, jetCol] == 'R')
                {
                    armorValue =300;
                }
                matrix[jetRow, jetCol] = 'J';
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
