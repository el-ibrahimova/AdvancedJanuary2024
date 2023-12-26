namespace _06.SongsQueue
{
    /*
    All Over Again, Watch Me
    Play
    Add Watch Me
    Add Love Me Harder
    Add Promises
    Show
    Play
    Play
    Play
    Play
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", "); // All Over Again, Watch Me

            Queue<string> songs = new Queue<string>(input);

            while (true)
            {
                string[] commandInfo = Console.ReadLine().Split();

                if (commandInfo[0] == "Play")
                {
                    if (songs.Any())
                    {
                        songs.Dequeue();
                    }

                    if (songs.Count == 0)
                    {
                        Console.WriteLine("No more songs!");
                        break;
                    }
                }
                else if (commandInfo[0] == "Add")
                {
                    // Add Watch Me 
                    // ["Add", "Watch", "Me"]
                    // ["Watch", "Me"]
                    // string.Join -> Watch Me

                    string songName = string.Join((" "), commandInfo.Skip(1));
                    if (songs.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(songName);
                    }
                }
                else if (commandInfo[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
        }
    }
}
