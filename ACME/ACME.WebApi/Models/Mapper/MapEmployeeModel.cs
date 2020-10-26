using ACME.Entities.Models;
using ACME.Shared.Model;
using System.Collections.Generic;
using System.Linq;

namespace ACME.WebApi.Models.Mapper
{
    public static class MapEmployeeModel
    {
        public static EmployeeModel Map(this Employee entity, EmployeeModel model = null)
        {
            model = new EmployeeModel();

            model.EmployeeId = entity.EmployeeId;
            model.PersonId = entity.PersonId;
            model.EmployeeNum = entity.EmployeeNum;
            model.EmployedDate = entity.EmployedDate;
            model.TerminatedDate = entity.TerminatedDate;

            return model;
        }

        public static Employee Map(this EmployeeModel model, Employee entity = null)
        {
            entity = new Employee();

            entity.EmployeeId = model.EmployeeId;
            entity.PersonId = model.PersonId;
            entity.EmployeeNum = model.EmployeeNum;
            entity.EmployedDate = model.EmployedDate;
            entity.TerminatedDate = model.TerminatedDate;

            return entity;
        }

        public static IEnumerable<EmployeeModel> MapToList(IQueryable<Employee> entities)
        {
            var modelList = new List<EmployeeModel>();

            foreach (var entity in entities)
            {
                var model = new EmployeeModel();

                model.EmployeeId = entity.EmployeeId;
                model.PersonId = entity.PersonId;
                model.EmployeeNum = entity.EmployeeNum;
                model.EmployedDate = entity.EmployedDate;
                model.TerminatedDate = entity.TerminatedDate;

                modelList.Add(model);
            }

            return modelList;
        }
    }
}