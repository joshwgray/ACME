using ACME.Entities.Models;
using System.Linq;

namespace ACME.Core.Interfaces
{
    public interface IEmployeeManager : IBaseManager<Employee>
    {
        IQueryable<Employee> Get();
    }
}
