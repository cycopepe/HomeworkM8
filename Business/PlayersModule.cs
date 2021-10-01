using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class PlayersModule
    {
        private Dictionary<int, string> _players;

        public PlayersModule()
        {
        }

        /// <summary>
        /// Calculate Player couples add ups
        /// </summary>
        /// <param name="players">List of tuples (player name, player height)</param>
        /// <param name="goalValue"></param>
        /// <returns>List of tuples with the player that height sums are equal to goal value</returns>
        public List<(string, string)> GetPlayersAddUps(List<(string name, int height)> players, int goalValue)
        {
            var result = new List<(string, string)>();
            var mirror = new List<(string, string)>();
            var processed = new Dictionary<int, string>();

            foreach (var player in players)
            {
                int complementHeight = goalValue - player.height;
                if (complementHeight >= 0)
                {
                    processed.TryGetValue(complementHeight, out string playersWithComplementHeight);
                    if (!string.IsNullOrEmpty(playersWithComplementHeight))
                    {
                        var complementPlayers = playersWithComplementHeight.Split(',');
                        
                        foreach (var cp in complementPlayers)
                        {
                            if (player.name != cp && !mirror.Contains((player.name, cp)))
                            {
                                mirror.Add((player.name, cp));
                                result.Add((cp, player.name));
                            }
                        }
                        processed.Remove(player.height);
                        processed.Add(player.height, $"{string.Join(",", complementPlayers)},{player.name}");
                    }
                    else
                    {
                        processed.TryGetValue(player.height, out string playersWithSameHeight);
                        if (!string.IsNullOrEmpty(playersWithSameHeight))
                        {
                            processed.Remove(player.height);
                            processed.Add(player.height, $"{playersWithSameHeight},{player.name}");
                        }
                        else
                        {
                            processed.Add(player.height, player.name);
                        }

                    }
                }
            }

            return result;
        }
    }
}
