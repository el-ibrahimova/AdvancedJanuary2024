namespace _09.SoftUniExamResults
{
  /*
Peter-Java-84
George-C#-70
George-C#-84
Sam-C#-94
exam finished
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> studentsPoints = new();  // students and points

            SortedDictionary<string, int> languagesSubmissions = new();  // contests and count of submissions

            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] commands = input.Split("-", StringSplitOptions.RemoveEmptyEntries);

                string username = commands[0];
               
                if (commands[1] == "banned")
                {
                    studentsPoints.Remove(username);
                    continue;
                }

                string language = commands[1];
                int points = int.Parse(commands[2]);

                if (!studentsPoints.ContainsKey(username))
                {
                    studentsPoints.Add(username, 0);
                }

                if (studentsPoints[username]<points)
                {
                    studentsPoints[username] = points;
                }

                if (!languagesSubmissions.ContainsKey(language))
                {
                    languagesSubmissions.Add(language, 0);
                }
                languagesSubmissions[language]++;
            }

            Console.WriteLine("Results:");

            foreach (var student in studentsPoints.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var contest in languagesSubmissions.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{contest.Key} - {contest.Value}");
            }
        }
    }
}
