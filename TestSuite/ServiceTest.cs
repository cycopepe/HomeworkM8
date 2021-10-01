using Moq;
using Services;
using System;
using System.Linq;
using Xunit;

namespace TestSuite
{
    public class ServiceTest
    {
        [Fact]
        public void CanGetPlayers()
        {
            var service = new PlayerService();
            
            var players = service.GetPlayers();

            Assert.True(players.Any());
        }

        [Fact]
        public void CanGetValidInformationFromAllPlayers()
        {
            var service = new PlayerService();

            var players = service.GetPlayers();

            Assert.Contains(players, x => x.Height > 0);            
            Assert.Contains(players, x => !string.IsNullOrEmpty( x.Name ));            
        }
    }
}
