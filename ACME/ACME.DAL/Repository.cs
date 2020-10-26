using ACME.DAL.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace ACME.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbSet<T> _dbSet;
        private readonly GeneralDbContext _value;
        private IQueryable<T> _asQueryable;
        string errorMessage = string.Empty;

        public Repository(DbSet<T> dbSet, GeneralDbContext value)
        {
            _dbSet = dbSet;
            _value = value;
            _asQueryable = dbSet;
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            T add = _dbSet.Add(entity);
            _value.SaveChanges();
            return add;
        }

        public bool Remove(T entity)
        {
            _dbSet.Remove(entity);
            return _value.SaveChanges() > 0;
        }

        public T Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _value.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw new Exception(errorMessage, dbEx);
            }

            return entity;
        }

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return _asQueryable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of IQueryable

        public Expression Expression
        {
            get { return _asQueryable.Expression; }
        }

        public Type ElementType
        {
            get { return _asQueryable.ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return _asQueryable.Provider; }
        }

        #endregion
    }
}
