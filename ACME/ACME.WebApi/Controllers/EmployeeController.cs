using ACME.Shared.Interfaces;
using System.Web.Http;
using ACME.Shared.Model;
using System.Threading.Tasks;
using ACME.Core.Interfaces;
using ACME.WebApi.Models.Mapper;
using System.Collections.Generic;

namespace ACME.WebApi.Controllers
{
    /// <summary>
    /// Employee Controller
    /// </summary>
    public class EmployeeController : ApiController, IEmployeeControllerActions
    {
        private readonly IEmployeeManager _manager;

        /// <summary>
        /// Constructor with manager injected
        /// </summary>
        /// <param name="manager"></param>
        public EmployeeController(IEmployeeManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("api/employee/")]
        public Task<IEnumerable<EmployeeModel>> Get()
        {
            return Task.Run(() =>
            {
                var entityList = _manager.Get();
                return MapEmployeeModel.MapToList(entityList) as IEnumerable<EmployeeModel>;
            });
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AcceptVerbs("DELETE")]
        [Route("api/employee/{id}")]
        public Task<bool> Delete(int id)
        {
            return Task.Run(() => _manager.Delete(id));
        }

        /// <summary>
        /// Get Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("api/employee/{id}")]
        public Task<EmployeeModel> Get(int id)
        {
            return Task.Run(() => _manager.Get(id).Map());
        }

        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AcceptVerbs("POST")]
        [Route("api/employee/")]
        public Task<EmployeeModel> Post(EmployeeModel model)
        {
            return Task.Run(() => _manager.Create(model.Map()).Map());
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [AcceptVerbs("PUT")]
        [Route("api/employee/")]
        public Task<EmployeeModel> Put(int id, EmployeeModel model)
        {
            return Task.Run(() => _manager.Update(model.Map(), id).Map());
        }
    }
}