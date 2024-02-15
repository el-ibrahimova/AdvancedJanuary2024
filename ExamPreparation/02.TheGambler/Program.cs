namespace _02.TheGambler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] gameBoard = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;
            int amountOfMoney = 100;

            for (int row = 0; row < size; row++)
            {
                string rowValues = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    gameBoard[row, col] = rowValues[col];

                    if (rowValues[col] == 'G')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool isLost = false;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                gameBoard[playerRow, playerCol] = '-';

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

                if (playerCol < 0 || playerCol >= size || playerRow < 0 || playerRow >= size)
                {
                    Console.WriteLine("Game over! You lost everything!");
                    isLost = true;
                    break;
                }

                if (gameBoard[playerRow, playerCol] == 'W')
                {
                    amountOfMoney += 100;
                }
                else if (gameBoard[playerRow, playerCol] == 'P')
                {
                    amountOfMoney -= 200;
                    if (amountOfMoney <= 0)
                    {
                        Console.WriteLine("Game over! You lost everything!");
                        isLost = true;
                        break;
                    }
                }
                else if (gameBoard[playerRow, playerCol] == 'J')
                {
                    amountOfMoney += 100000;
                    Console.WriteLine($"You win the Jackpot!");
                    gameBoard[playerRow, playerCol] = 'G';
                    break;
                }

                gameBoard[playerRow, playerCol] = 'G';
            }

            if (!isLost == true)
            {
                Console.WriteLine($"End of the game. Total amount: {amountOfMoney}$");

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        Console.Write($"{gameBoard[row, col]}");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
