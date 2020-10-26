using ACME.Entities.Models;
using System;

namespace ACME.DAL.Interfaces
{
    public interface IGeneralUnitOfWork : IDisposable
    {
        IRepository<Person> Person { get; }
        IRepository<Employee> Employee { get; }
    }
}
