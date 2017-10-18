using DataStorage.Interfaces;
using System;
using System.Collections.Generic;
using DataStorage.DataObjects;
using System.Linq;

namespace DataStorage.Implementations
{
    public class MockGameSessionStorage : IGameSessionStorage
    {
        private readonly List<GameSession> _sessions = new List<GameSession>();

        public Guid CreateSession(Game game, IEnumerable<Errand> errands)
        {
            var session = new GameSession
            {
                Id = Guid.NewGuid(),
                GameName = game.Name
            };
            _sessions.Add(session);
            return session.Id;
        }

        public IEnumerable<GameSession> GetAll()
        {
            return _sessions.ToList();
        }
    }
}
