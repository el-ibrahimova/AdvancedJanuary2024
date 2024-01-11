using System.Text;

namespace EvenLines
{
    using System;
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
          StringBuilder sb = new StringBuilder();
            
            using StreamReader reader = new StreamReader(inputFilePath);
            
            string line = String.Empty;
            int count = 0;

            while (line !=null) // ако тук условието е  while (true), stringReader-а прочиата ред след ред, и когато съдържанието свърши, всеки следващ ред е със стойност null, затова условието е точно това => да прочита редове, докато има такива със съдържание
            {
                line = reader.ReadLine();

                if (count % 2 == 0)
                {
                    string replacedSymbols = ReplaceSymbols(line);
                    string reversedWords = ReverseWords(replacedSymbols);
                    sb.AppendLine(reversedWords);
                }

                count++;
            }

            return sb.ToString().TrimEnd(); // Trim - изтрива празните символи, TrimEnd - изтрива празния символ на края, ако има такъв => добре е винаги да се ползва, когато имаме StringBuilder
        }

        private static string ReplaceSymbols(string line)
        {
            StringBuilder sb = new StringBuilder(line);
            char[] symbolsToReplace = { '-', ',', '.', '!', '?' };

            foreach (char symbol in symbolsToReplace)
            {
                sb = sb.Replace(symbol, '@');
            }

            return sb.ToString();
        }

        private static string ReverseWords(string words)
        {
            string[] reversedWords = words
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            return string.Join(" ",reversedWords);
        }
    }
}
