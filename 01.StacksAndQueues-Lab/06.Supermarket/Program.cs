namespace _06.Supermarket
{ 
/*
Liam
Noah
James
Paid
Oliver
Lucas
Logan
Tiana
End
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Queue<string> customers = new Queue<string>();
            int counter = 0;

            while (command != "End")
            {
                if (command == "Paid")
                {
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                        counter = 0;
                    }
                }
                else
                {
                    customers.Enqueue(command);
                    counter++;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{counter} people remaining.");
        }
    }
}
