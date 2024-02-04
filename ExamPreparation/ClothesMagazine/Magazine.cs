using System;
using System.Collections.Generic;
using System.Linq;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>(capacity);
        }
        public string Type { get; set; }
        public int Capacity { get; private set; }

        public List<Cloth> Clothes { get; private set; }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color) => Clothes.Remove(Clothes.FirstOrDefault(c => c.Color == color));

        public Cloth GetSmallestCloth() => Clothes.MinBy(s => s.Size);

        public Cloth GetCloth(string color) => Clothes.FirstOrDefault(s => s.Color == color);

        public int GetClothCount() => Clothes.Count;

        public string Report()
        {
            return $"{Type} magazine contains:" +
                            Environment.NewLine +
                            (string.Join(Environment.NewLine, Clothes.OrderBy(s=>s.Size)));

            
        }

    }
}
