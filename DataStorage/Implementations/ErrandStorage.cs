using DataStorage.DataObjects;
using DataStorage.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Optional;

namespace DataStorage.Implementations
{
    /// <summary>
    /// Local mock implementation for Errand storage
    /// </summary>
    public class ErrandStorage : IErrandStorage
    {
        private readonly List<Errand> _mockRepo = new List<Errand>()
        {
            new Errand{Id = 1, Description = "Task1"},
            new Errand{Id = 2, Description = "Task2"},
            new Errand{Id = 3, Description = "Task3"},
            new Errand{Id = 4, Description = "Task4"},
            new Errand{Id = 5, Description = "Task5"}
        };

        public IEnumerable<Errand> GetAll()
        {
            return _mockRepo.ToList();
        }

        public Option<Errand> GetSingle(long id)
        {
            return _mockRepo.FirstOrDefault(task => task.Id == id).SomeNotNull();
        }
    }
}
