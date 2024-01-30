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

            ListyIterator<string> listIterator = new(items); // изписваме и типа string, защото класа ни е Generic

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listIterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            listIterator.Print();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
        }

    }
}

