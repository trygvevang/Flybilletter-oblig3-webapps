using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Flybilletter_oblig3_webapps.Models;
using System.Web.Script.Serialization;
using System.Text;

namespace Flybilletter_oblig3_webapps.Controllers
{
    public class QuestionController : ApiController
    {
        // GET api/Question
        public HttpResponseMessage Get()
        {
            List<Question> allQuestions = CRUD.GetAllQuestions();

            var json = new JavaScriptSerializer();
            var stringJson = json.Serialize(allQuestions);

            return new HttpResponseMessage()
            {
                Content = new StringContent(stringJson, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }
        /*
            Do something with QuestionCategory so admin is warned that there's a lot of questions in category, perhaps create a new FAQ.
            Kanskje også bruke ajax i web-app til å gjøre den mer dynamisk?
        */
        // GET api/Question/5
        public HttpResponseMessage Get(int ID)
        {
            var question = CRUD.GetSingleQuestion(ID);

            var json = new JavaScriptSerializer();
            var stringJson = json.Serialize(question);

            return new HttpResponseMessage()
            {
                Content = new StringContent(stringJson, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        // POST api/Question
        public HttpResponseMessage Post(QuestionData question)
        {
            bool OK = CRUD.AddQuestion(question);
            if (OK)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

            }
            
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Could not add question to the database.")
            };
        }
    }
}
