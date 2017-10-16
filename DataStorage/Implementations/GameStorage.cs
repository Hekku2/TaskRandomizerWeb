using DataStorage.DataObjects;
using System.Collections.Generic;
using Optional;
using System.Linq;
using DataStorage.Interfaces;

namespace DataStorage.Implementations
{
    /// <summary>
    /// Local mock implementation for game storage
    /// </summary>
    public class GameStorage : IGameStorage
    {
        private readonly List<Game> _mockRepo = new List<Game>()
        {
            new Game{Id = 1, Name = "Game 1"},
            new Game{Id = 2, Name = "Game 2"},
            new Game{Id = 3, Name = "Game 3"},
            new Game{Id = 4, Name = "Game 4"},
            new Game{Id = 5, Name = "Game 5"}
        };

        public IEnumerable<Game> GetAll()
        {
            return _mockRepo.ToList();
        }

        public Option<Game> GetSingle(long id)
        {
            return _mockRepo.FirstOrDefault(task => task.Id == id).SomeNotNull();
        }
    }
}
