using ACME.DAL.Interfaces;
using ACME.Entities.Models;
using System;

namespace ACME.DAL
{
    public class GeneralUnitOfWork : IGeneralUnitOfWork
    {
        private readonly string _connectionStringName;
        private Lazy<GeneralDbContext> _context;

        #region Constructors

        public GeneralUnitOfWork() : this("AcmeEntities")
		{
        }

        public GeneralUnitOfWork(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
            ReCreateContext();
        }

        #endregion

        #region IGeneralUnitOfWork Implementation

        public IRepository<Person> Person { get; private set; }
        public IRepository<Employee> Employee { get; private set; }

        #endregion

        #region Implementation of IDisposable

        public virtual void Dispose()
        {
            if (_context.IsValueCreated) _context.Value.Dispose();
        }

        #endregion

        #region Private Methods

        private void ReCreateContext()
        {
            if (_context != null && _context.IsValueCreated) _context.Value.Dispose();
            _context = new Lazy<GeneralDbContext>(() => new GeneralDbContext(_connectionStringName));
            Person = new Repository<Person>(_context.Value.Person, _context.Value);
            Employee = new Repository<Employee>(_context.Value.Employee, _context.Value);
        }

        #endregion
    }
}
