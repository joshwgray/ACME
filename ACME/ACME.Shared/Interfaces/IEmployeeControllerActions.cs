using ACME.Shared.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACME.Shared.Interfaces
{
    public interface IEmployeeControllerActions : ICrudController<EmployeeModel>
    {
        Task<IEnumerable<EmployeeModel>> Get();
    }
}
