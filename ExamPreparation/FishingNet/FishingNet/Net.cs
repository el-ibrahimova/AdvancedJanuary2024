using System;
using System.Collections.Generic;
using System.Linq;


namespace FishingNet
{
   
    public class Net
    { 
        private List<Fish> fishCollection;
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            fishCollection = new List<Fish>();
        }

        public IReadOnlyCollection<Fish> Fish => fishCollection;
        
        public string Material { get; set; }
        public int Capacity { get; private set; }

        public int Count => fishCollection.Count;

        public string AddFish(Fish fish)
        {
            if (fishCollection.Count < Capacity)
            {
                if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
                {
                    return "Invalid fish.";
                }
                
                fishCollection.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";

            }
            else
            {
                return "Fishing net is full.";
            }
        }

        public bool ReleaseFish(double weight)
        {
            Fish currentFish = fishCollection.FirstOrDefault(f => f.Weight.Equals(weight));

            if (currentFish != null)
            {
                fishCollection.Remove(currentFish);
                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType) => fishCollection.FirstOrDefault(f => f.FishType == fishType);

        public Fish GetBiggestFish()
        {
            return fishCollection.OrderByDescending(f => f.Length).First();
        }

        public string Report()
        {
            return $"Into the {Material}:" + Environment.NewLine
                                           + string.Join(Environment.NewLine, fishCollection.OrderByDescending(l => l.Length));
        }


    }
}
