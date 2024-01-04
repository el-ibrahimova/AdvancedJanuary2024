namespace _02.Survivor
{
    /*
   6
       T T - T T - T
       - T - -
       T - T - T T - -
       - T - T - T
       T T
       T T T - T
       Find 2 2
       Find 4 1
       Opponent 3 1 up
       Find 4 3
       Find 5 0
       Find 4 0
       Opponent 2 0 down
       Gong

     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] beach = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                char [] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                beach[row] = tokens;
            }

            int countOfCollected = 0;
            int countOfOpponentCollected = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Gong")
                {
                    break;
                }

                string[] arguments = command.Split();
                int row = int.Parse(arguments[1]);
                int col = int.Parse(arguments[2]);

                if (arguments[0] == "Find")
                {
                    if (IsValid(row, col, beach))
                    {
                        char element = beach[row][col];
                        if (element == 'T')
                        {
                            countOfCollected++;
                            beach[row][col] = '-';
                        }
                    }
                }
                else if (arguments[0] == "Opponent")
                {
                    string direction = arguments[3];

                    if (IsValid(row, col, beach))
                    {
                        char element = beach[row][col];
                        if (element == 'T')
                        {
                            countOfOpponentCollected++;
                            beach[row][col] = '-';

                            if (direction == "up") // 3 steps up => row -
                            {
                                ValidateDirections(row-1, col, beach, ref countOfOpponentCollected);
                                ValidateDirections(row - 2, col, beach, ref countOfOpponentCollected);
                                ValidateDirections(row - 3, col, beach, ref countOfOpponentCollected);
                            }
                            else if (direction == "down") // 3 steps down => row +
                            {
                                ValidateDirections(row + 1, col, beach, ref countOfOpponentCollected);
                                ValidateDirections(row + 2, col, beach, ref countOfOpponentCollected);
                                ValidateDirections(row + 3, col, beach, ref countOfOpponentCollected);
                            }
                            else if (direction == "left") // 3 steps left => col -
                            {
                                ValidateDirections(row, col-1, beach, ref countOfOpponentCollected);
                                ValidateDirections(row, col-2, beach, ref countOfOpponentCollected);
                                ValidateDirections(row, col -3, beach, ref countOfOpponentCollected);
                            }
                            else // "right" => 3 steps right => col +
                            {
                                ValidateDirections(row, col + 1, beach, ref countOfOpponentCollected);
                                ValidateDirections(row, col + 2, beach, ref countOfOpponentCollected);
                                ValidateDirections(row, col + 3, beach, ref countOfOpponentCollected);
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < beach[row].Length; col++)
                {
                    Console.Write($"{beach[row][col]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Collected tokens: {countOfCollected}");
            Console.WriteLine($"Opponent's tokens: {countOfOpponentCollected}");
        }

       static void ValidateDirections(int row, int col, char[][] beach, ref int countOfOpponentCollected)
        {
            if (IsValid(row, col, beach))
            {
                if (beach[row][col] == 'T')
                {
                    countOfOpponentCollected++;
                    beach[row][col] = '-';
                }
            }
            else
            {
                return;
            }
        }

        static bool IsValid(int row, int col, char[][] beach)
        {
            return row >= 0 && row < beach.GetLength(0) && col >= 0 && col < beach[row].Length;
        }
    }
}
