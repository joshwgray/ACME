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
    /// Person Controller
    /// </summary>
    public class PersonController : ApiController, IPersonControllerActions
    {
        private readonly IPersonManager _manager;

        /// <summary>
        /// Constructor with manager injected
        /// </summary>
        /// <param name="manager"></param>
        public PersonController(IPersonManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("api/person/")]
        public Task<IEnumerable<PersonModel>> Get()
        {
            return Task.Run(() =>
            {
                var entityList = _manager.Get();
                return MapPersonModel.MapToList(entityList) as IEnumerable<PersonModel>;
            });
        }

        /// <summary>
        /// Delete Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AcceptVerbs("DELETE")]
        [Route("api/person/{id}")]
        public Task<bool> Delete(int id)
        {
            return Task.Run(() => _manager.Delete(id));
        }
        
        /// <summary>
        /// Get Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("api/person/{id}")]
        public Task<PersonModel> Get(int id)
        {
            return Task.Run(() => _manager.Get(id).Map());
        }

        /// <summary>
        /// Create Person
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AcceptVerbs("POST")]
        [Route("api/person/")]
        public Task<PersonModel> Post(PersonModel model)
        {
            return Task.Run(() => _manager.Create(model.Map()).Map());
        }

        /// <summary>
        /// Update Person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [AcceptVerbs("PUT")]
        [Route("api/person/")]
        public Task<PersonModel> Put(int id, PersonModel model)
        {
            return Task.Run(() => _manager.Update(model.Map(), id).Map());
        }
    }
}