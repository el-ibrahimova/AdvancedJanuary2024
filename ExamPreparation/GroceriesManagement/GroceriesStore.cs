using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            Stall = new(capacity);
        }
        public List<Product> Stall { get; private set; }
        public int Capacity { get; private set; }
        public double Turnover { get; set; }

        public void AddProduct(Product product)
        {
            if (Capacity > Stall.Count)
            {
                if (!Stall.Any(n => n.Name == product.Name))
                {
                    Stall.Add(product);
                }
            }
        }

        public bool RemoveProduct(string name) =>
            Stall.Remove(Stall.FirstOrDefault(n => n.Name == name));


        public string SellProduct(string name, double quantity)
        {
            Product product = Stall.FirstOrDefault(p => p.Name == name);

            if (product == null)
            {
                return "Product not found";
            }

            double totalPrice = product.Price * quantity;
            Turnover += totalPrice;
            return $"{product.Name} - {totalPrice:F2}$";

        }

        public string GetMostExpensive() =>
            $"{Stall.MaxBy(p => p.Price).ToString()}";


        public string CashReport()
        {
            return $"Total Turnover: {Turnover:f2}$";
        }

        public string PriceList()
        {
            StringBuilder sb = new();
            sb.AppendLine("Groceries Price List:");

            foreach (var item in Stall)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
