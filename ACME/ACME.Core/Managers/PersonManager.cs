using ACME.Core.Interfaces;
using System.Linq;
using ACME.Entities.Models;
using ACME.DAL.Interfaces;

namespace ACME.Core.Managers
{
    public class PersonManager : IPersonManager
    {
        private readonly IGeneralUnitOfWork _generalUnitOfWork;

        public PersonManager(IGeneralUnitOfWork generalUnitOfWork)
        {
            _generalUnitOfWork = generalUnitOfWork;
        }

        public IQueryable<Person> Get()
        {
            return _generalUnitOfWork.Person;
        }

        public Person Create(Person person)
        {
            return _generalUnitOfWork.Person.Add(person);
        }

        public bool Delete(int id)
        {
            var existingPerson = _generalUnitOfWork.Person.FirstOrDefault(x => x.PersonId == id);
            if(existingPerson != null)
            {
                _generalUnitOfWork.Person.Remove(existingPerson);
                return true;
            }
            return false;
        }

        public Person Get(int id)
        {
            return _generalUnitOfWork.Person.FirstOrDefault(x => x.PersonId == id);
        }

        public Person Update(Person person, int id)
        {
            var existingPerson = _generalUnitOfWork.Person.FirstOrDefault(x => x.PersonId == id);
            if (existingPerson != null)
            {
                existingPerson = _generalUnitOfWork.Person.Update(person);
            }

            return existingPerson;
        }
    }
}
