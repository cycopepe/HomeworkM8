using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IPlayerService
    {
        public IEnumerable<Player> GetPlayers();
    }
}
