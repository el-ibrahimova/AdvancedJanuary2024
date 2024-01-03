using System.ComponentModel.Design;

namespace _09.Miner
{ /*
5
up right right up right
* * * c *
* * * e *
* * c * *
s * * c *
* * c * *
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            // имаме квадратна матрица => rows = cols

            string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            // "up right right up right" -> ["up", "right",  "right", "up", "right"]

            char[,] matrix = new char[size, size];

            int currentRow = 0; 
            int currentCol = 0; 
            int countCoal = 0; 

            // прочитаме матрицата от конзолата
            for (int row = 0; row < size; row++)
            {
                char[] symbols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = symbols[col];
                    if (symbols[col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    else if (symbols[col] == 'c')
                    {
                        countCoal++;
                    }
                }
            }

            foreach (string direction in directions)
            {
                // валидните команди са: left, right, up, down

                switch (direction)
                {
                    case "left":
                        // Колоната - 1
                        // валидираме мястото, на което ще отидем още преди да преместим

                        if (currentCol - 1 >= 0 && currentCol - 1 <= size - 1)
                        {
                            currentCol--;
                        }
                        // Проверяваме къде сме отишли (върху какво сме попаднали)

                        char currentElement = matrix[currentRow, currentCol];

                        if (currentElement == 'e')
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return; // Прекратяваме цялата програма
                        }
                        else if (currentElement == 'c')
                        {
                            matrix[currentRow, currentCol] = '*';
                            countCoal--; ;

                            if (countCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                return;
                            }

                        }
                        break;

                    case "right":
                        // Колоната + 1
                        // валидираме новия индекс
                        if (currentCol + 1 >= 0 && currentCol + 1 <= size - 1)
                        {
                            currentCol++;
                        }

                        currentElement = matrix[currentRow, currentCol];

                        if (currentElement == 'e')
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return; // Прекратяваме цялата програма
                        }
                        else if (currentElement == 'c')
                        {
                            matrix[currentRow, currentCol] = '*';
                            countCoal--; ;

                            if (countCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                return;
                            }

                        }
                        break;

                    case "up":
                        // реда - 1
                        // валидираме
                        if (currentRow - 1 >= 0 && currentRow - 1 <= size - 1)
                        {
                            currentRow--;
                        }

                        currentElement = matrix[currentRow, currentCol];

                        if (currentElement == 'e')
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return; // Прекратяваме цялата програма
                        }
                        else if (currentElement == 'c')
                        {
                            matrix[currentRow, currentCol] = '*';
                            countCoal--; ;

                            if (countCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                return;
                            }

                        }
                        break;

                    case "down":
                        // реда + 1
                        if (currentRow + 1 >= 0 && currentRow + 1 <= size - 1)
                        {
                            currentRow++;
                        }

                        currentElement = matrix[currentRow, currentCol];

                        if (currentElement == 'e')
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return; // Прекратяваме цялата програма
                        }
                        else if (currentElement == 'c')
                        {
                            matrix[currentRow, currentCol] = '*';
                            countCoal--; ;

                            if (countCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                return;
                            }

                        }
                        break;
                }
            }
            Console.WriteLine($"{countCoal} coals left. ({currentRow}, {currentCol})");
        }
    }
}

