using ACME.Entities.Models;
using System.Linq;

namespace ACME.Core.Interfaces
{
    public interface IPersonManager : IBaseManager<Person>
    {
        IQueryable<Person> Get();
    }
}
