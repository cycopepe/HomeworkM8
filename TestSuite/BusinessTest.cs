using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace TestSuite
{
    public class BusinessTest
    {
        [Fact]
        public void CanMakeBasicSetUp()
        {
            int addUpValue = 0;
            var players = new List<(string, int)>();
            players.Add(("A", 1));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            Assert.NotNull(result);
        }

        [Fact]
        public void CaseOneMatchDifferntValues()
        {
            int addUpValue = 3;
            var players = new List<(string, int)>();
            players.Add(("A", 1));
            players.Add(("B", 2));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            var expected = new List<(string, string)>();
            expected.Add(("A", "B"));
            
            Assert.Equal(expected.OrderBy(x=>x.Item1).ThenBy(x=>x.Item2), result.OrderBy(x => x.Item1).ThenBy(x => x.Item2));
        }

        [Fact]
        public void CaseMoreThanOneMatch()
        {
            int addUpValue = 3;
            var players = new List<(string, int)>();
            players.Add(("A", 1));
            players.Add(("B", 1));
            players.Add(("C", 2));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            var expected = new List<(string, string)>();
            expected.Add(("A","C"));
            expected.Add(("B","C"));

            Assert.Equal(expected.OrderBy(x=>x.Item1).ThenBy(x=>x.Item2), result.OrderBy(x => x.Item1).ThenBy(x => x.Item2));
        }

        [Fact]
        public void CaseMoreThanOneMatchDifferentOrder()
        {
            int addUpValue = 3;
            var players = new List<(string, int)>();
            players.Add(("A", 1));
            players.Add(("B", 2));
            players.Add(("C", 2));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            var expected = new List<(string, string)>();
            expected.Add(("A", "B"));
            expected.Add(("A", "C"));

            Assert.Equal(expected.OrderBy(x=>x.Item1).ThenBy(x=>x.Item2), result.OrderBy(x => x.Item1).ThenBy(x => x.Item2));
        }

        [Fact]
        public void CaseOneMatchSameValues()
        {
            int addUpValue = 2;
            var players = new List<(string, int)>();
            players.Add(("A", 1));
            players.Add(("B", 1));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            var expected = new List<(string, string)>();
            expected.Add(("A", "B"));
            
            Assert.Equal(expected.OrderBy(x=>x.Item1).ThenBy(x=>x.Item2), result.OrderBy(x => x.Item1).ThenBy(x => x.Item2));
        }

        [Fact]
        public void CaseMultipleMatcheSamevalueOddNumberOfPlayers()
        {
            int addUpValue = 2;
            var players = new List<(string, int)>();
            players.Add(("A", 1));
            players.Add(("B", 1));
            players.Add(("C", 1));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            var expected = new List<(string, string)>();
            expected.Add(("A", "B"));
            expected.Add(("A", "C"));
            expected.Add(("B", "C"));

            Assert.Equal(expected.OrderBy(x=>x.Item1).ThenBy(x=>x.Item2), result.OrderBy(x => x.Item1).ThenBy(x => x.Item2));
        }

        [Fact]
        public void CaseMultipleMatchesSameValueEvenNUmberPlayers()
        {
            int addUpValue = 2;
            var players = new List<(string, int)>();
            players.Add(("A", 1));
            players.Add(("B", 1));
            players.Add(("C", 1));
            players.Add(("D", 1));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            var expected = new List<(string, string)>();
            expected.Add(("A", "B"));
            expected.Add(("A", "C"));
            expected.Add(("A", "D"));
            expected.Add(("B", "C"));
            expected.Add(("B", "D"));
            expected.Add(("C", "D"));

            Assert.Equal(expected.OrderBy(x=>x.Item1).ThenBy(x=>x.Item2), result.OrderBy(x => x.Item1).ThenBy(x => x.Item2));
        }

        [Fact]
        public void CaseValidationsAgainsZero()
        {
            int addUpValue = 2;
            var players = new List<(string, int)>();
            players.Add(("A", 1));
            players.Add(("B", 1));
            players.Add(("C", 1));
            players.Add(("D", 0));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            var expected = new List<(string, string)>();
            expected.Add(("A", "B"));
            expected.Add(("A", "C"));           
            expected.Add(("B", "C"));
            

            Assert.Equal(expected.OrderBy(x=>x.Item1).ThenBy(x=>x.Item2), result.OrderBy(x => x.Item1).ThenBy(x => x.Item2));
        }

        [Fact]
        public void CaseHalfAndHalfMatch()
        {
            int addUpValue = 3;
            var players = new List<(string, int)>();
            players.Add(("A", 1));
            players.Add(("B", 1));
            players.Add(("C", 2));
            players.Add(("D", 2));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            var expected = new List<(string, string)>();
            expected.Add(("A", "C"));
            expected.Add(("A", "D"));
            expected.Add(("B", "C"));
            expected.Add(("B", "D"));


            Assert.Equal(expected.OrderBy(x=>x.Item1).ThenBy(x=>x.Item2), result.OrderBy(x => x.Item1).ThenBy(x => x.Item2));
        }

        [Fact]
        public void CaseNegativeAddUpValue()
        {
            int addUpValue = -3;
            var players = new List<(string, int)>();
            players.Add(("A", 1));
            players.Add(("B", 1));
            players.Add(("C", 2));
            players.Add(("D", 2));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            var expected = new List<(string, string)>();
            
            Assert.Equal(expected.OrderBy(x => x.Item1).ThenBy(x => x.Item2), result.OrderBy(x => x.Item1).ThenBy(x => x.Item2));
        }

        [Fact]
        public void CaseNoMatches()
        {
            int addUpValue = 10;
            var players = new List<(string, int)>();
            players.Add(("A", 1));
            players.Add(("B", 1));
            players.Add(("C", 2));
            players.Add(("D", 2));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            var expected = new List<(string, string)>();

            Assert.Equal(expected.OrderBy(x => x.Item1).ThenBy(x => x.Item2), result.OrderBy(x => x.Item1).ThenBy(x => x.Item2));
        }

        [Fact]
        public void CaseZeroGoalZeroAddUpvalue()
        {
            int addUpValue = 0;
            var players = new List<(string, int)>();
            players.Add(("A", 1));
            players.Add(("B", 1));
            players.Add(("C", 1));
            players.Add(("D", 0));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            var expected = new List<(string, string)>();

            Assert.Equal(expected.OrderBy(x => x.Item1).ThenBy(x => x.Item2), result.OrderBy(x => x.Item1).ThenBy(x => x.Item2));
        }

        [Fact]
        public void CaseMatchesWithZero()
        {
            int addUpValue = 1;
            var players = new List<(string, int)>();
            players.Add(("A", 1));
            players.Add(("B", 1));
            players.Add(("C", 1));
            players.Add(("D", 0));

            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addUpValue);

            var expected = new List<(string, string)>();
            expected.Add(("A", "D"));
            expected.Add(("B", "D"));
            expected.Add(("C", "D"));

            Assert.Equal(expected.OrderBy(x => x.Item1).ThenBy(x => x.Item2), result.OrderBy(x => x.Item1).ThenBy(x => x.Item2));
        }
    }
}
