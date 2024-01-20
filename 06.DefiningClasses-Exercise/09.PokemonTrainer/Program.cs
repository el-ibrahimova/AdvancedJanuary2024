namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<Trainer> listOfTrainers = new();
            
            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                if (!listOfTrainers.Any(x => x.Name == trainerName))
                {
                    listOfTrainers.Add(new Trainer(trainerName));
                }

                var currentTrainer = listOfTrainers.Find(t => t.Name == trainerName);
                currentTrainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }

            string elements;
            while ((elements = Console.ReadLine()) != "End")
            {
                foreach (Trainer trainer in listOfTrainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == elements))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {

                            trainer.Pokemons[i].Health -= 10;
                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.RemoveAt(i);
                                i--; // като изтрием елемент трябва да се върнем един ход назад, за да не пропуснем елемент от колекцията
                            }
                        }
                    }
                }
            }

            foreach (Trainer trainer in listOfTrainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
