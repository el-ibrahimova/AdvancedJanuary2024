namespace _08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] personTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] drinkTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[]  bankTokens= Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            CustomThreeuple<string, string, string> nameAddress = 
                new($"{personTokens[0]} {personTokens[1]}", personTokens[2], string.Join(" ",personTokens[3..])); // string.Join(" ",personTokens[3..] - отпечатай от 3тия елемент на масива до края

            CustomThreeuple<string, int, bool> drinks = 
                new(drinkTokens[0], int.Parse(drinkTokens[1]), drinkTokens[2]== "drunk");

            CustomThreeuple<string, double, string> numbers = 
                new(bankTokens[0], double.Parse(bankTokens[1]), bankTokens[2]);


            Console.WriteLine(nameAddress);
            Console.WriteLine(drinks);
            Console.WriteLine(numbers);
        }
    }
}
