namespace _08.Ranking
{
    /*
    Part One Interview:success
       Js Fundamentals:JSFundPass
       C# Fundamentals:fundPass
       Algorithms:fun
       end of contests
       C# Fundamentals=>fundPass=>Tanya=>350
       Algorithms=>fun=>Tanya=>380
       Part One Interview=>success=>Nikola=>120
       Java Basics Exam=>JSFundPass=>Parker=>400
       Part One Interview=>success=>Tanya=>220
       OOP Advanced=>password123=>BaiIvan=>231
       C# Fundamentals=>fundPass=>Tanya=>250
       C# Fundamentals=>fundPass=>Nikola=>200
       Js Fundamentals=>JSFundPass=>Tanya=>400
       end of submissions

     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new();

            Dictionary<string, Dictionary<string, int>> students = new();

            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] info = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contestName = info[0];
                string password = info[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, password);
                }
            }

            string input2;
            while ((input2 = Console.ReadLine()) != "end of submissions")
            {
                string[] info2 = input2.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contestName = info2[0];
                string password2 = info2[1];
                string username = info2[2];
                int points = int.Parse(info2[3]);

                if (contests.ContainsKey(contestName) && contests[contestName] == password2)
                {
                    if (!students.ContainsKey(username))
                    {
                        students.Add(username, new Dictionary<string, int>());

                        students[username].Add(contestName, points);
                    }
                    else
                    {
                        if (!students[username].ContainsKey(contestName))
                        {
                            students[username].Add(contestName, points);
                        }
                        else
                        {
                            if (students[username][contestName] < points)
                            {
                                students[username][contestName] = points;
                            }
                        }
                    }
                }
            }

            string bestStudent = "";
            int highPoints = 0;

            foreach (var name in students)
            {
                int totalPoints = 0;

                foreach (var course in name.Value)
                {
                    totalPoints += course.Value;
                }

                if (totalPoints > highPoints)
                {
                    bestStudent = name.Key;
                    highPoints = totalPoints;
                }
            }

            Console.WriteLine($"Best candidate is {bestStudent} with total {highPoints} points.");

            students = students
                .OrderBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine("Ranking: ");

            foreach (var name in students)
            {
                Console.WriteLine(name.Key);
                foreach (var course in name.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
        }
    }
}