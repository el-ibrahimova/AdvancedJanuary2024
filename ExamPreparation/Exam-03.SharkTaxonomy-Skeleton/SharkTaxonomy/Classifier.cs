using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        private List<Shark> species;
        public Classifier(int capacity)
        {
            Capacity=capacity;
            species = new List<Shark>();
        }
        
        public int Capacity { get; set; }
        public List<Shark> Species => species;

        public int GetCount => species.Count;

        public void AddShark(Shark shark)
        {   
            var isAlreadyExist = species.FirstOrDefault(k => k.Kind == shark.Kind);
       
            if (species.Count < Capacity && isAlreadyExist== null)
            {
                    species.Add(shark);
            }
        }

        public bool RemoveShark(string kind) => species.Remove(species.FirstOrDefault(k => k.Kind == kind));

        public string GetLargestShark()
        {
            var ordered = species.OrderByDescending(l => l.Length).ToList();
            Shark largest = ordered.FirstOrDefault();

            if (largest == null)
            {
                return string.Empty;
            }

            return largest.ToString().TrimEnd();
        }

        public double GetAverageLength()
        {
            double sum = species.Sum(l => l.Length);
            return sum/species.Count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetCount} sharks classified:");

            foreach (var item in species)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
