using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Flybilletter_oblig3_webapps.Models;
using System.Web.Script.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Flybilletter_oblig3_webapps.Controllers
{
    public class QuestionController : ApiController
    {
        // Add new question to database
        public HttpResponseMessage Post([FromBody]QuestionData question)
        {
            if (ModelState.IsValid)
            {
                bool OK = CRUD.AddQuestion(question);
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
                Content = new StringContent("Could not add question to the database.")
            };
        }
        
        // Update existing question
        public HttpResponseMessage Put(int id, [FromBody]Question question)
        {
            Regex answerPattern = new Regex(@"^[a-zA-Z0-9øæåØÆÅ .,!-]{2,}$");
            if (ModelState.IsValid && question.Person != null && question.Answer != null && answerPattern.IsMatch(question.Answer))
            {
                bool OK = CRUD.AnswerQuestion(id, question);
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
                Content = new StringContent("Could not update question data in the database.")
            };

        }
    }
}
