using ACME.Shared.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACME.Shared.Interfaces
{
    public interface IPersonControllerActions : ICrudController<PersonModel>
    {
        Task<IEnumerable<PersonModel>> Get();
    }
}
