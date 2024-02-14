namespace _02.NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] battlefield = new char[size, size];

            int submarineRow = 0;
            int submarineCol = 0;

            for (int row = 0; row < size; row++)
            {
                string rowValues = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    battlefield[row, col] = rowValues[col];

                    if (rowValues[col] == 'S')
                    {
                        submarineRow = row;
                        submarineCol = col;
                    }
                }
            }

            int mine = 0;
            int battleCruiserCount = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "up" && submarineRow == 0 ||
                    command == "down" && submarineRow == size - 1 ||
                    command == "left" && submarineCol == 0 ||
                    command == "right" && submarineCol == size - 1)
                {
                    continue;
                }

                battlefield[submarineRow, submarineCol] = '-';

                if (command == "up")
                {
                    submarineRow--;
                }
                else if (command == "down")
                {
                    submarineRow++;
                }
                else if (command == "left")
                {
                    submarineCol--;
                }
                else if (command == "right")
                {
                    submarineCol++;
                }

                if (battlefield[submarineRow, submarineCol] == '*')
                {
                    mine++;

                    if (mine == 3)
                    {
                        battlefield[submarineRow, submarineCol] = 'S';
                        Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
                        break;
                    }
                }

                if (battlefield[submarineRow, submarineCol] == 'C')
                {
                    battleCruiserCount++;

                    if (battleCruiserCount == 3)
                    {
                        battlefield[submarineRow, submarineCol] = 'S';
                        Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                        break;
                    }
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{battlefield[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
