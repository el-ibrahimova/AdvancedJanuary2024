using System;
using System.Collections.Generic;
using System.Linq;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();

        }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public List<Player> Players { get; set; }

        public int Count => Players.Count;

        public string AddPlayer(Player player)
        {
            if (player.Name is null || player.Position is null)
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
            Players.Add(player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            Player toRemove = Players.FirstOrDefault(p => p.Name == name);

            if (toRemove != null)
            {
                Players.Remove(toRemove);
                OpenPositions++;

            }
                return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            var toRemoveInPosition = Players.FindAll(p => p.Position== position).ToList();

            if (toRemoveInPosition.Count > 0)
            {
                Players.RemoveAll(p => p.Position==position);
                return toRemoveInPosition.Count;
                OpenPositions -= toRemoveInPosition.Count;
              
            }
            return 0;
        }

        public Player RetirePlayer(string name)
        {
            Player retired = Players.FirstOrDefault(p => p.Name == name);

            if (retired != null)
            {
                retired.Retired=true;
                return retired;
            }

            return default;
        }

        public List<Player> AwardPlayers(int games)
        {
            var awarded = Players.Where(p => p.Games >= games);
            return awarded.ToList();

        }

        public  string Report()
        {
            var notRetired = Players.Where(p => p.Retired == false);

            return $"Active players competing for Team {Name} from Group {Group}:" +
                   Environment.NewLine +
                   string.Join(Environment.NewLine, notRetired);
        }
    }
}

