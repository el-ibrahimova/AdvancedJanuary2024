namespace _08.SoftUniParty
{
    /*
   7IK9Yo0h
   9NoBUajQ
   Ce8vwPmE
   SVQXQCbc
   tSzE5t0p
   PARTY
   9NoBUajQ
   Ce8vwPmE
   SVQXQCbc
   END
   */
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            bool partyStarted = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (input == "PARTY")
                {
                    partyStarted = true;
                }

                if (partyStarted)
                {
                    if (char.IsDigit(input[0]))
                    {
                        vipGuests.Remove(input);
                    }
                    else
                    {
                        regularGuests.Remove(input);
                    }
                }
                else
                {
                    if (char.IsDigit(input[0]))
                    {
                        vipGuests.Add(input);
                    }
                    else
                    {
                        regularGuests.Add(input);
                    }
                }
            }

            Console.WriteLine(vipGuests.Count + regularGuests.Count);

            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }


        }

    }
}