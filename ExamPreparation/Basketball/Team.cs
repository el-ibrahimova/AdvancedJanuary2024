using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();

        }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> Players => players;



        public int Count => players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            OpenPositions--;
            players.Add(player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            Player toRemove = players.Find(p => p.Name == name);

            if (toRemove != null)
            {
                players.Remove(toRemove);
                OpenPositions++;
                return true;
            }
            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            List<Player> playersToRemove = players.FindAll(p => p.Position == position);
            int count = playersToRemove.Count;

            players.RemoveAll(p => p.Position == position);
            OpenPositions += count;

            return count;
        }

        public Player RetirePlayer(string name)
        {
            Player retired = players.Find(p => p.Name == name);

            if (retired != null)
            {
                retired.Retired = true;
            }

            return retired;
        }

        public List<Player> AwardPlayers(int games) => players.FindAll(p => p.Games >= games);



        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in players.FindAll(p => p.Retired == false))
            {
                reportBuilder.AppendLine(player.ToString());
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }

}

