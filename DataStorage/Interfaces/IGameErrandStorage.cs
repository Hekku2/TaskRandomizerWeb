using DataStorage.DataObjects;
using System.Collections.Generic;

namespace DataStorage.Interfaces
{
    public interface IGameErrandStorage
    {
        IEnumerable<Errand> GetForGame(long gameId);
    }
}
