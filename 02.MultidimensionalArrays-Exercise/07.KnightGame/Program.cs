using System.Data;
using System.Numerics;

namespace _07.KnightGame
{
    /*
    5 
    0K0K0
    K000K
    00K00
    K000K 
    0K0K0
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            // Квадратна матрица

            int size = int.Parse(Console.ReadLine());

            // По условие, размерът е от 0 до 30. Но ако размерът на матрицата е < 3, то няма къде конят да се движи. 

            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            int countRemovedKnights = 0;

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] symbols = Console.ReadLine().ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            // обхождаме полето и премахваме коне, докато не останем само с добри коне = атакуват 0 други коне
            while (true)
            {
                int maxAttack = 0; 
                int rowMaxAttack = 0;
                int colMaxAttack = 0; 

                for (int row = 0; row < size; row++) // целта е да намеря най-атакуващия кон
                {
                    for (int col = 0; col < size; col++)
                    {
                        char currentElement = matrix[row, col];
                        if (currentElement == 'K')
                        {
                            // 1. при движение колко коня настъпва
                            int countAttackedKnights = CalculateAttackedKnight(row, col, size, matrix);

                            // 2. проверка дали е най-атакуващия кон
                            if (countAttackedKnights > maxAttack) // кой е коня с най-много атаки
                            {
                                maxAttack = countAttackedKnights;
                                rowMaxAttack = row;
                                colMaxAttack = col;
                            }
                        }
                    }
                }

                if (maxAttack == 0) // ако няма коне, които да атакуват
                {
                    break;
                }
                else
                {
                    // Имам кон за премахване
                    matrix[rowMaxAttack, colMaxAttack] = '0';
                    countRemovedKnights++;
                }
            }
            Console.WriteLine(countRemovedKnights);

        }

        static int CalculateAttackedKnight(int row, int col, int size, char[,] matrix)
        {
            int count = 0;

            //2 нагоре и 1 надясно -> ред - 2, колона + 1
            if (IsValid(row - 2, col + 1, size))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    count++;
                }
            }

            //2 нагоре и 1 наляво -> ред - 2, кол - 1
            if (IsValid(row - 2, col - 1, size))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    count++;
                }
            }

            //2 надолу и 1 наляво -> ред + 2, колона - 1
            if (IsValid(row + 2, col - 1, size))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    count++;
                }
            }

            //2 надолу и 1 надясно -> ред + 2, колона + 1
            if (IsValid(row + 2, col + 1, size))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    count++;
                }
            }

            //2 надясно и 1 надолу 0 -> ред + 1, колона + 2
            if (IsValid(row + 1, col + 2, size))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    count++;
                }
            }

            //2 надясно и 1 нагоре->ред - 1, колона + 2
            if (IsValid(row - 1, col + 2, size))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    count++;
                }
            }

            // 2 наляво и 1 нагоре -> ред - 1, колона - 2
            if (IsValid(row - 1, col - 2, size))
            {
              if (matrix[row - 1, col - 2] == 'K')
                {
                    count++;
                }
            }

            // 2 наляво и 1 надолу -> ред + 1, колона - 2
            if (IsValid(row + 1, col - 2, size))
            {
               if (matrix[row + 1, col - 2] == 'K')
                {
                    count++;
                }
            }

            return count;
        }

        static bool IsValid(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}
