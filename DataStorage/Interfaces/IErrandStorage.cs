using DataStorage.DataObjects;
using Optional;
using System.Collections.Generic;

namespace DataStorage.Interfaces
{
    public interface IErrandStorage
    {
        IEnumerable<Errand> GetAll();
        Option<Errand> GetSingle(long id);
    }
}
