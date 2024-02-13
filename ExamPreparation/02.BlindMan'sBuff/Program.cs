namespace _02.BlindMan_sBuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int rows = dimension[0];
            int cols = dimension[1];

            char[,] playground = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] rowValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    playground[row, col] = rowValues[col];

                    if (rowValues[col] == 'B')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            int touchedOpponents = 0;
            int movesMaded = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Finish")
            {
                if (command == "left" && playerCol == 0 ||
                    command == "right" && playerCol == cols - 1 ||
                    command == "up" && playerRow == 0 ||
                    command == "down" && playerRow == rows - 1)
                {
                    continue;
                }

                if (command == "left" && playground[playerRow, playerCol - 1] == 'O' ||
                    command == "right" && playground[playerRow, playerCol + 1] == 'O' ||
                    command == "up" && playground[playerRow - 1, playerCol] == 'O' ||
                    command == "down" && playground[playerRow + 1, playerCol] == 'O')
                {
                    continue;
                }
                
                playground[playerRow, playerCol] = '-';

                if (command == "up")
                {
                    playerRow--;
                }
                else if (command == "down")
                {
                    playerRow++;
                }
                else if (command == "left")
                {
                    playerCol--;
                }
                else if (command == "right")
                {
                    playerCol++;
                }

                movesMaded++;

                if (playground[playerRow, playerCol] == 'P')
                {
                    touchedOpponents++;
                    if (touchedOpponents == 3)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMaded}");
        }
    }
}
