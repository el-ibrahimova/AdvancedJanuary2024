namespace _07.ParkingLot
{
/*
IN, CA2844AA
   IN, CA1234TA
   OUT, CA2844AA
   IN, CA9999TT
   IN, CA2866HI
   OUT, CA1234TA
   IN, CA2844AA
   OUT, CA2866HI
   IN, CA9876HH
   IN, CA2822UU
   END
   
 */
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            HashSet<string> parking = new HashSet<string>();

            while (command != "END")
            {
                string direction = command.Split(", ")[0];
                string carNumber = command.Split(", ")[1];

                if (direction == "IN")
                {
                    parking.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    parking.Remove(carNumber);
                }

                command = Console.ReadLine();
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(string.Join("\n", parking));
            }
        }
    }
}
