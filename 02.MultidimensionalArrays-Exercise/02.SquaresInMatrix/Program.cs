namespace _02.SquaresInMatrix
{
    /*
    3 4
    A B B D
    E B B B
    I J B B
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] symbols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            int counter = 0;
            for (int row = 0; row < rows - 1; row++) // не включваме елементите от последния ред
            {
                for (int col = 0; col < cols - 1; col++) // не включваме елементите от последната колона
                {
                    char currentSymbol = matrix[row, col]; // тук типа данни може да е и int

                    if (matrix[row, col + 1] == currentSymbol &&
                        matrix[row + 1, col] == currentSymbol &&
                        matrix[row + 1, col + 1] == currentSymbol)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
