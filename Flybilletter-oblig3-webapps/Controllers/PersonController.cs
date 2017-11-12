using Flybilletter_oblig3_webapps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Flybilletter_oblig3_webapps.Controllers
{
    public class PersonController : ApiController
    {
        // GET api/Person
        public HttpResponseMessage Get()
        {
            List<Person> allPeople = CRUD.GetAllPeople();

            var json = new JavaScriptSerializer();
            var stringJson = json.Serialize(allPeople);

            return new HttpResponseMessage()
            {
                Content = new StringContent(stringJson, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        // GET api/Person/5
        public HttpResponseMessage Get(string Firstname, string Lastname)
        {
            var person = CRUD.GetSinglePerson(Firstname, Lastname);

            if (person != null)
            {
                var json = new JavaScriptSerializer();
                var stringJson = json.Serialize(person);

                return new HttpResponseMessage()
                {
                    Content = new StringContent(stringJson, Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.OK
                };
            }
            return new HttpResponseMessage()
            {
                Content = new StringContent("Could not find person in database"),
                StatusCode = HttpStatusCode.NotFound
            };
        }

        // POST api/Person
        public HttpResponseMessage Post(Person person)
        {
            if (ModelState.IsValid)
            {
                bool OK = CRUD.AddPerson(person);
                if (OK)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };

                }
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Could not add person to the database.")
            };
        }
    }
}
