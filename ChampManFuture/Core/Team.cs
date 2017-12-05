using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManFuture.Core
{
    public class Team
    {
        public string Name { get; }
        public IEnumerable<Player> Players { get; }
        public Team(string name, IEnumerable<Player> players)
        {
            Name = name;
            Players = players;
            foreach(Player p in players)
            {
                p.BaseData.TeamName = name;
            }
        }
        public Player GetKeeper()
        {
            Func<Player, bool> PlayerIsKeeper = (player) =>
            {
                return player.CurrentRole == Role.Goalkeeper;
            };
            return Players.Where(PlayerIsKeeper).Single();
        }
    }
}
