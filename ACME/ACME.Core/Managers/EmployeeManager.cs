using ACME.Core.Interfaces;
using System;
using ACME.Entities.Models;
using ACME.DAL.Interfaces;
using System.Linq;

namespace ACME.Core.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IGeneralUnitOfWork _generalUnitOfWork;

        public EmployeeManager(IGeneralUnitOfWork generalUnitOfWork)
        {
            _generalUnitOfWork = generalUnitOfWork;
        }

        public IQueryable<Employee> Get()
        {
            return _generalUnitOfWork.Employee;
        }

        public Employee Create(Employee employee)
        {
            return _generalUnitOfWork.Employee.Add(employee);
        }

        public bool Delete(int id)
        {
            var existingEmployee = _generalUnitOfWork.Employee.FirstOrDefault(x => x.EmployeeId == id);
            if (existingEmployee != null)
            {
                _generalUnitOfWork.Employee.Remove(existingEmployee);
                return true;
            }
            return false;
        }

        public Employee Get(int id)
        {
            return _generalUnitOfWork.Employee.FirstOrDefault(x => x.EmployeeId == id);
        }

        public Employee Update(Employee employee, int id)
        {
            var existingPerson = _generalUnitOfWork.Employee.FirstOrDefault(x => x.PersonId == id);
            if (existingPerson != null)
            {
                existingPerson = _generalUnitOfWork.Employee.Update(employee);
            }

            return existingPerson;
        }
    }
}
