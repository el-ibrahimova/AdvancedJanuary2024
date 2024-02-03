using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            RenovatorsList = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public List<Renovator> RenovatorsList { get; set; }

        public int Count => RenovatorsList.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null || renovator.Type == null)
            {
                return "Invalid renovator's information.";
            }

            if (RenovatorsList.Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            RenovatorsList.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name) => RenovatorsList.Remove(RenovatorsList.FirstOrDefault(n => n.Name == name));

        public Renovator HireRenovator(string name)
        {
            Renovator ren = RenovatorsList.FirstOrDefault(n => n.Name == name);

            if (ren is not null)
            {
                ren.Hired = true;
            }
            return null;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            var rens = RenovatorsList.FindAll(t => t.Type == type).ToList();

            if (rens != null)
            {
                int removed = 0;
                foreach (var item in rens)
                {
                    RenovatorsList.Remove(item);
                    removed++;
                }
                return removed;
            }
            return 0;
        }

        public List<Renovator> PayRenovators(int days)
        {
            var payDay = RenovatorsList.Where(p => p.Days >= days).ToList();
            return payDay;
        }

        public string Report()
        {
            var notHired = RenovatorsList.Where(h => h.Hired == false).ToList();

            return $"Renovators available for Project {Project}:" +
                   Environment.NewLine +
                   string.Join(Environment.NewLine, notHired);
        }

    }
}
