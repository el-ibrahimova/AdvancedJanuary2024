namespace ListyIteratorType
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1) // Пропусни първия елемент(знаем че първата команда е Create и я пропускаме, за да не я изписваме всеки път)
                .ToList();

            ListyIterator<string> listyIterator = new(items); // изписваме и типа string, защото класа ни е Generic

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "PrintAll":
                        foreach (var item in listyIterator)
                        {
                            Console.Write($"{item} ");
                        }
                        Console.WriteLine(); 
                        break;
                }
            }
        }
    }
}