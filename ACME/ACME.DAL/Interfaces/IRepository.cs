using System.Linq;

namespace ACME.DAL.Interfaces
{
    public interface IRepository<T> : IQueryable<T>
    {
        T Add(T entity);
        bool Remove(T entity);
        T Update(T entity);
    }
}
