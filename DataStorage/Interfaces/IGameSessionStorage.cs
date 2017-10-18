using DataStorage.DataObjects;
using System;
using System.Collections.Generic;

namespace DataStorage.Interfaces
{
    public interface IGameSessionStorage
    {
        Guid CreateSession(Game game, IEnumerable<Errand> errands);
        IEnumerable<GameSession> GetAll();
    }
}
