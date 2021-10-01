using Common.Dtos;
using Common.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class PlayerService : IPlayerService
    {
        private string baseUrl = "https://mach-eight.uc.r.appspot.com/";

        public IEnumerable<Player> GetPlayers()
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.GET);

            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            var playersResponse = JsonConvert.DeserializeObject<PlayersResponse>(response.Content);

            var result = new List<Player>();
            foreach (var player in playersResponse.Values) {
                result.Add(new Player { Name = $"{player.first_name} {player.last_name}", Height = player.h_in});
            }

            return result;
        }
    }
}
