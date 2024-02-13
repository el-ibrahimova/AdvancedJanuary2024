namespace _02.Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] atack = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

            int playerOneCountOfShips = 0;
            int playerTwoCountOfShips = 0;


            char[,] field = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] rowValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowValues[col];

                    if (rowValues[col] == '<')
                    {
                        playerOneCountOfShips++;
                    }
                    if (rowValues[col] == '>')
                    {
                        playerTwoCountOfShips++;
                    }
                }
            }

            int maxShips = playerOneCountOfShips + playerTwoCountOfShips;

            bool isWin = false;

            for (int i = 0; i < atack.Length; i++)
            {
                string playerMove = atack[i];
                int[] coordinates = playerMove.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                int row = coordinates[0];
                int col = coordinates[1];

                if (col < 0 || col >= size || row < 0 || row >= size)
                {
                    continue;
                }

                if (field[row, col] == '#')
                {
                    field[row, col] = 'X';

                    if (isValid(row + 1, col, size))
                    {
                        if (field[row + 1, col] == '<')
                        {
                            playerOneCountOfShips--;
                            field[row + 1, col] = 'X';
                        }

                        if (field[row + 1, col] == '>')
                        {
                            playerTwoCountOfShips--;
                            field[row + 1, col] = 'X';
                        }
                    }

                    if (isValid(row - 1, col, size))
                    {
                        if (field[row - 1, col] == '<')
                        {
                            playerOneCountOfShips--;
                            field[row - 1, col] = 'X';
                        }

                        if (field[row - 1, col] == '>')
                        {
                            playerTwoCountOfShips--;
                            field[row - 1, col] = 'X';
                        }
                    }

                    if (isValid(row, col + 1, size))
                    {
                        if (field[row, col + 1] == '<')
                        {
                            playerOneCountOfShips--;
                            field[row, col + 1] = 'X';
                        }

                        if (field[row, col + 1] == '>')
                        {
                            playerTwoCountOfShips--;
                            field[row, col + 1] = 'X';
                        }
                    }

                    if (isValid(row, col - 1, size))
                    {
                        if (field[row, col - 1] == '<')
                        {
                            playerOneCountOfShips--;
                            field[row, col - 1] = 'X';
                        }

                        if (field[row, col - 1] == '>')
                        {
                            playerTwoCountOfShips--;
                            field[row, col - 1] = 'X';
                        }
                    }

                    if (isValid(row - 1, col - 1, size))
                    {
                        if (field[row - 1, col - 1] == '<')
                        {
                            playerOneCountOfShips--;
                            field[row - 1, col - 1] = 'X';
                        }

                        if (field[row - 1, col - 1] == '>')
                        {
                            playerTwoCountOfShips--;
                            field[row - 1, col - 1] = 'X';
                        }
                    }

                    if (isValid(row + 1, col - 1, size))
                    {
                        if (field[row + 1, col - 1] == '<')
                        {
                            playerOneCountOfShips--;
                            field[row + 1, col - 1] = 'X';
                        }

                        if (field[row + 1, col - 1] == '>')
                        {
                            playerTwoCountOfShips--;
                            field[row + 1, col - 1] = 'X';
                        }
                    }

                    if (isValid(row - 1, col + 1, size))
                    {
                        if (field[row - 1, col + 1] == '<')
                        {
                            playerOneCountOfShips--;
                            field[row - 1, col + 1] = 'X';
                        }

                        if (field[row - 1, col + 1] == '>')
                        {
                            playerTwoCountOfShips--;
                            field[row - 1, col + 1] = 'X';
                        }
                    }

                    if (isValid(row + 1, col + 1, size))
                    {
                        if (field[row + 1, col + 1] == '<')
                        {
                            playerOneCountOfShips--;
                            field[row + 1, col + 1] = 'X';
                        }

                        if (field[row + 1, col + 1] == '>')
                        {
                            playerTwoCountOfShips--;
                            field[row + 1, col + 1] = 'X';
                        }
                    }
                    continue;
                }

                if (i % 2 == 0)
                {
                    if (field[row, col] == '>')
                    {
                        playerTwoCountOfShips--;

                        if (playerTwoCountOfShips == 0)
                        {
                            Console.WriteLine(
                                $"Player One has won the game! {maxShips - (playerOneCountOfShips + playerTwoCountOfShips)} ships have been sunk in the battle.");
                            isWin = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (field[row, col] == '<')
                    {
                        playerOneCountOfShips--;

                        if (playerOneCountOfShips == 0)
                        {
                            Console.WriteLine(
                                $"Player Two has won the game! {maxShips - (playerOneCountOfShips + playerTwoCountOfShips)} ships have been sunk in the battle.");
                            isWin = true;
                            break;
                        }
                    }
                }
            }

            if (isWin == false)
            {
                Console.WriteLine(
                    $"It's a draw! Player One has {playerOneCountOfShips} ships left. Player Two has {playerTwoCountOfShips} ships left.");
            }
        }

        static bool isValid(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}
