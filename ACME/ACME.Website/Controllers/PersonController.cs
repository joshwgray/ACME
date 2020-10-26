using ACME.Shared.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace ACME.Website.Controllers
{
    public class PersonController : Controller
    {
        #region GET methods
        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:64210/api/person").Result;
            var personList = response.Content.ReadAsAsync<IEnumerable<PersonModel>>().Result;
            return View(personList.ToList());
        }
        
        /// <summary>
        /// GET
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            return View(Get(id));
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            return View(Get(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        #endregion

        #region POST methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new HttpClient();
                var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = client.PostAsync("http://localhost:64210/api/person/", stringContent).Result;
                var personList = response.Content.ReadAsAsync<PersonModel>().Result;

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existingPerson = Get(id);
            if(existingPerson != null)
            {
                var client = new HttpClient();
                var response = client.DeleteAsync(string.Format("http://localhost:64210/api/person/{0}", id)).Result;
                var person = response.Content.ReadAsAsync<bool>().Result;
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private PersonModel Get(int id)
        {
            var client = new HttpClient();
            var response = client.GetAsync(string.Format("http://localhost:64210/api/person/{0}", id)).Result;
            return response.Content.ReadAsAsync<PersonModel>().Result;
        }

        #endregion
    }
}