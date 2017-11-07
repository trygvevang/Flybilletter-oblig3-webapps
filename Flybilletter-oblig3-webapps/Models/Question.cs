using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flybilletter_oblig3_webapps.Models
{
    public class Question
    {
        public int ID { get; set; }
        public Person Person { get; set; }
        public string Quest { get; set; }
        public QuestionType QuestionType { get; set; }
        public string Answer { get; set; } // If answer == null then it is not answered
    }

    public class Person
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public class QuestionType // Has class because this allows to get all questions with of a certain type
    {
        public int ID { get; set; }
        public string Type { get; set; }
    }
    
}