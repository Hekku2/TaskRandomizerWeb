using DataStorage.DataObjects;
using System;
using System.Collections.Generic;

namespace DataStorage.Interfaces
{
    public interface IGameSessionStorage
    {
        Guid CreateSession(Game game, IEnumerable<Errand> errands);
        void JoinSession(Guid sessionId, string playerName);
        IEnumerable<GameSession> GetAll();
    }
}
