using ACME.Entities.Models;
using ACME.Shared.Model;
using System.Collections.Generic;
using System.Linq;

namespace ACME.WebApi.Models.Mapper
{
    public static class MapPersonModel
    {
        public static PersonModel Map(this Person entity, PersonModel model = null)
        {
            model = new PersonModel();

            model.PersonId = entity.PersonId;
            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;
            model.BirthDate = entity.BirthDate;

            return model;
        }

        public static Person Map(this PersonModel model, Person entity = null)
        {
            entity = new Person();

            entity.PersonId = model.PersonId;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.BirthDate = model.BirthDate;

            return entity;
        }

        public static IEnumerable<PersonModel> MapToList(IQueryable<Person> entities)
        {
            var modelList = new List<PersonModel>();

            foreach(var entity in entities)
            {
                var model = new PersonModel();

                model.PersonId = entity.PersonId;
                model.FirstName = entity.FirstName;
                model.LastName = entity.LastName;
                model.BirthDate = entity.BirthDate;

                modelList.Add(model);
            }

            return modelList;
        }
    }
}