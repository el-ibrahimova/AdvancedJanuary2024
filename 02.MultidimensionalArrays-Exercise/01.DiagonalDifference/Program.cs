namespace _01.DiagonalDifference
{
    /*
    3
    11 2 4
    4 5 6
    10 8 -12
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine()); // row = col

            int[,] matrix = new int[size, size];

            // прочитане на матрица от конзолата
            for (int row = 0; row < size; row++) // Обхождаме всички редове от първия до последния
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            // сума от числата на главния диагонал => номер на реда е равен на колоната
            int primarySum = 0;


            // сума от числата на второстепенния диагонал => номер на колона = size -1 - номер на реда
            int secondarySum = 0;

           
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int element = matrix[row, col]; // текущ елемент
                    if (row == col)  // елементът е на главния диагонал
                    {
                        primarySum += element;
                    }

                    if (col == size - 1 - row) // елементът е на второстепенния диагонал
                    {
                        secondarySum += element;
                    }
                }
            }

           // кратко решение за намиране на сумата на диагоналите
          //  for (int row = 0; row < size; row++)
           // {
           //     primarySum += matrix[row, row];
           //     secondarySum += matrix[size - row -1, row];
           // }



            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
