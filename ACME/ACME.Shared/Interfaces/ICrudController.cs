using System.Threading.Tasks;

namespace ACME.Shared.Interfaces
{
    public interface ICrudController<TModel>
    {
        Task<TModel> Get(int id);
        Task<TModel> Post(TModel model);
        Task<TModel> Put(int id, TModel model);
        Task<bool> Delete(int id);
    }
}
