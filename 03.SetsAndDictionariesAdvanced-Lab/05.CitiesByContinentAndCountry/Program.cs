namespace _05.CitiesByContinentAndCountry
{
 /*
9
Europe Bulgaria Sofia
Asia China Beijing
Asia Japan Tokyo
Europe Poland Warsaw
Europe Germany Berlin
Europe Poland Poznan
Europe Bulgaria Plovdiv
Africa Nigeria Abuja
Asia China Shanghai
*/
    internal class Program
    {
        static void Main(string[] args)
        {
           int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continents =  new Dictionary<string, Dictionary<string, List<string>>>();
             

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continentName = input[0];
                string countryName = input[1];
                string cityName = input[2];

                if (!continents.ContainsKey(continentName))
                {
                    continents.Add(continentName, new Dictionary<string, List<string>>());
                }
                
                if (!continents[continentName].ContainsKey(countryName))
                {
                    continents[continentName].Add(countryName, new List<string>());
                }
                continents[continentName][countryName].Add(cityName);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"\t{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
