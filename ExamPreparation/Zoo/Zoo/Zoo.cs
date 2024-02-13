using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>(capacity);
        }

        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }


        public string AddAnimal(Animal animal)
        {
            if (Animals.Count < Capacity)
            {
                if (string.IsNullOrWhiteSpace(animal.Species))
                {
                    return "Invalid animal species.";
                }
                else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
                {
                    return "Invalid animal diet.";
                }
                else
                {
                  Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";  
                }
            }
            else
            {
                return "The zoo is full."; 
            }
        }

        public int RemoveAnimals(string species)
        {
            int count = 0;
            while (Animals.Any(s => s.Species == species))
            {
                Animals.Remove(Animals.First(s => s.Species == species));
                count++;
            }
            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var AnimalByDiet = Animals.FindAll(a => a.Diet == diet);
            return AnimalByDiet;
        }

        public Animal GetAnimalByWeight(double weight) => Animals.FirstOrDefault(a => a.Weight == weight);

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var AnimalsLength = Animals.FindAll(a => a.Length >= minimumLength && a.Length <= maximumLength);

            return $"There are {AnimalsLength.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
