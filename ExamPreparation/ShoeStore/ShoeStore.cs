using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>(storageCapacity);
        }
        public string Name { get; set; }
        public int StorageCapacity { get; private set; }
        public List<Shoe> Shoes { get; set; }

        public int Count => Shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            
            if (Shoes.Count < StorageCapacity)
            {
               Shoes.Add(shoe);
               
               return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            else
            {
               return "No more space in the storage room.";
            }
        }

        public int RemoveShoes(string material)
        {
            var toRemove = Shoes.FindAll(s => s.Material == material);
            Shoes.RemoveAll(s=>s.Material== material);

            return toRemove.Count;
        }

        public List<Shoe> GetShoesByType(string type)
        {
           List<Shoe> filtered = Shoes.FindAll(s => s.Type.ToLower() == type);
            return filtered;
        }

        public Shoe GetShoeBySize(double size) => Shoes.First(s => s.Size == size);

        public string StockList(double size, string type)
        {
            List<Shoe> matchingShoes = Shoes
            .Where(shoe => shoe.Size == size && shoe.Type==type)
            .ToList();

            if (matchingShoes.Count > 0)
            {
                return $"Stock list for size {size} - {type} shoes:" +
                       Environment.NewLine +
                       string.Join(Environment.NewLine, matchingShoes);
            }
            else
            {
                return $"No matches found!";
            }
        }
    }
}
