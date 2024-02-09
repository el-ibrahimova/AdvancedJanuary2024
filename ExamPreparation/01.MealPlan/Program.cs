namespace _01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meals = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] maxCaloriesPerDay = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<string> mealCalories = new Queue<string>(meals);
            Stack<int> calPerDay = new Stack<int>(maxCaloriesPerDay);

            int numberOfMeals = mealCalories.Count;

            Dictionary<string, int> menu = new Dictionary<string, int>()
            {
                { "salad", 350},
                { "soup", 490},
                { "pasta", 680},
                { "steak", 790},
               };

            Queue<string> mealNames = new Queue<string>(meals);

            while (mealCalories.Any() && calPerDay.Any() && mealNames.Any())
            {
                string currentMeal = mealCalories.Peek();
                int currentCalories = calPerDay.Peek();
                string currentMealName = mealNames.Peek();

                if (currentMeal == currentMealName)
                {
                    currentCalories -= menu[currentMealName];
                    calPerDay.Pop();
                    calPerDay.Push(currentCalories);
                    mealCalories.Dequeue();
                    mealNames.Dequeue();

                    if (currentCalories == 0)
                    {
                        calPerDay.Pop();
                        continue;
                    }
                    else if (currentCalories < 0)
                    {
                        int dayConsumed = 350 + currentCalories;
                        int forNextDay = Math.Abs(currentCalories);
                        calPerDay.Pop();
                        if (calPerDay.Count > 0)
                        {
                            int nextDayTotal = calPerDay.Peek();
                            nextDayTotal -= forNextDay;
                            calPerDay.Pop();
                            calPerDay.Push(nextDayTotal);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (mealCalories.Count == 0)
            {
                Console.WriteLine($"John had {numberOfMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calPerDay)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {numberOfMeals - mealCalories.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealCalories)}");
            }
        }
    }
}
