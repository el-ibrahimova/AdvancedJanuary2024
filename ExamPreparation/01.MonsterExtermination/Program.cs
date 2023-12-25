namespace _01.MonsterExtermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] monsterArmor = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            int[] soldierStrice = Console.ReadLine().Split(",").Select(int.Parse).ToArray();

            Stack<int> strike = new Stack<int>(soldierStrice);
            Queue<int> armor = new Queue<int>(monsterArmor);

            int totalMonstersKilled = 0;

            while (strike.Any() && armor.Any())
            {
                int currentSoldier = strike.Peek();
                int currentMonster = armor.Peek();

                if (currentSoldier >= currentMonster)
                {
                    currentSoldier -= currentMonster;
                    totalMonstersKilled++;

                    if (currentSoldier == 0)
                    {
                        strike.Pop();
                        armor.Dequeue();
                    }
                    else
                    {
                        armor.Dequeue();

                        if (strike.Count == 1)
                        {
                            strike.Pop();
                            strike.Push(currentSoldier);
                        }
                        else
                        {
                            strike.Pop();
                            strike.Push(strike.Pop() + currentSoldier);
                        }
                    }
                }
                else
                {
                    currentMonster -= currentSoldier;
                    strike.Pop();
                    armor.Dequeue();
                    armor.Enqueue(currentMonster);
                }
            }

            if (!armor.Any())
            {
                Console.WriteLine("All monsters have been killed!");
            }
            if (!strike.Any())
            {
                Console.WriteLine("The soldier has been defeated.");
            }

            Console.WriteLine($"Total monsters killed: {totalMonstersKilled} ");

        }
    }
}
    

