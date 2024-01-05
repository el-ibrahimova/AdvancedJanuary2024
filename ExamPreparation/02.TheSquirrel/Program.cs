using System.Data;

namespace _02.TheSquirrel
{
    /*
   5
   left, left, up, right, up, up
   **h**
   t****
   *h***
   *h*s*
   *****
   */
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int hazelnuts = 0;

            int squirrelRow = 0;
            int squirrelCol = 0;

            string[] directions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string inputRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = inputRow[col];

                    if (field[row, col] == 's')
                    {
                        squirrelRow = row;
                        squirrelCol = col;
                    }

                    if (field[row, col] == 'h')
                    {
                        hazelnuts++;
                    }
                }
            }

            int newRow = squirrelRow;
            int newCol = squirrelCol;

            int countCommands = 0;

            foreach (string direction in directions)
            {
                switch (direction)
                {
                    case "left":
                        newCol--;
                        break;

                    case "right":
                        newCol++;
                        break;

                    case "up":
                        newRow--;
                        break;

                    case "down":
                        newRow++;
                        break;
                }

                countCommands++;

                if (IsValid(newRow, newCol, field))
                {
                    char nextCell = field[newRow, newCol];

                    if (nextCell == 'h')
                    {
                        hazelnuts--;
                        nextCell = '*';

                        if (hazelnuts == 0)
                        {
                            Console.WriteLine("Good job! You have collected all hazelnuts!");
                            break;
                        }
                    }

                    if (nextCell == '*')
                    {
                        field[squirrelRow, squirrelCol] = '*';
                        field[newRow, newCol] = 's';
                    }

                    if (nextCell == 't')
                    {
                        Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                        break;
                    }

                    if (countCommands == directions.Length)
                    {
                        if (hazelnuts > 0)
                        {
                            Console.WriteLine("There are more hazelnuts to collect.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The squirrel is out of the field.");
                    break;
                }
            }

            Console.WriteLine($"Hazelnuts collected: {3 - hazelnuts}");
        }

        static bool IsValid(int row, int col, char[,] field)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }

    }
}
