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
    public class QuestionTypeController : ApiController
    {
        // GET api/QuestionType
        public HttpResponseMessage Get()
        {
            List<QuestionType> allQuestions = CRUD.GetAllQuestionTypes();

            var json = new JavaScriptSerializer();
            var stringJson = json.Serialize(allQuestions);

            return new HttpResponseMessage()
            {
                Content = new StringContent(stringJson, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        // GET api/QuestionType/5
        public HttpResponseMessage Get(int ID)
        {
            var question = CRUD.GetSingleQuestionType(ID);

            var json = new JavaScriptSerializer();
            var stringJson = json.Serialize(question);

            return new HttpResponseMessage()
            {
                Content = new StringContent(stringJson, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
