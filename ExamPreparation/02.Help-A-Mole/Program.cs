using System;

namespace _02.Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];

            int moleRow = 0;
            int moleCol = 0;

            int sRow1 = 0;
            int sCol1 = 0;

            int sRow2 = 0;
            int sCol2 = 0;

            int countOfSpecialSymbol = 2;

            for (int row = 0; row < size; row++)
            {
                string rowValues = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowValues[col];

                    if (rowValues[col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }

                    if (rowValues[col] == 'S')
                    {
                        countOfSpecialSymbol--;
                        if (countOfSpecialSymbol == 0)
                        {
                            sRow2 = row;
                            sCol2 = col;
                        }
                        else
                        {
                            sRow1 = row;
                            sCol1 = col;
                        }
                    }
                }
            }

            int points = 0;
            bool isWin = false;

            string command = String.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "up" && moleRow == 0 ||
                    command == "down" && moleRow == size - 1 ||
                    command == "left" && moleCol == 0 ||
                    command == "right" && moleCol == size - 1)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    continue;
                }

                field[moleRow, moleCol] = '-';

                if (command == "up")
                {
                    moleRow--;
                }
                else if (command == "down")
                {
                    moleRow++;
                }
                else if (command == "left")
                {
                    moleCol--;
                }
                else if (command == "right")
                {
                    moleCol++;
                }

                if (char.IsDigit(field[moleRow, moleCol]))
                {
                    points += int.Parse(field[moleRow, moleCol].ToString());
                }

                if (field[moleRow, moleCol] == 'S')
                {
                    if (moleRow == sRow1 && moleCol == sCol1)
                    {
                        field[moleRow, moleCol] = '-';
                        moleRow = sRow2;
                        moleCol = sCol2;
                    }
                    else if (moleRow == sRow2 && moleCol == sCol2)
                    {
                        field[moleRow, moleCol] = '-';
                        moleRow = sRow1;
                        moleCol = sCol1;
                    }
                    points -= 3;
                }

                field[moleRow, moleCol] = 'M';

                if (points >= 25)
                {
                    isWin = true;
                    break;
                }
            }

            if (isWin == true)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{field[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}

