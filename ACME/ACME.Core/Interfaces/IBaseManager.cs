namespace ACME.Core.Interfaces
{
    public interface IBaseManager<T>
    {
        T Get(int id);
        bool Delete(int id);
        T Create(T person);
        T Update(T person, int id);
    }
}
