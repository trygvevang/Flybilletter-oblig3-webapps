using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flybilletter_oblig3_webapps.Models
{
    public class Question
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Person Person { get; set; }
        [Required]
        public string Quest { get; set; }
        [Required]
        public QuestionType QuestionType { get; set; }
        public string Answer { get; set; } // If answer == null then it is not answered
    }

    public class QuestionData
    {
        public Person Person { get; set; }
        public string Quest { get; set; }
        public int QuestionType { get; set; }
    }

    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

    }

    public class QuestionType // Has class because this allows to get all questions with of a certain type
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }
    }

    public static class CRUD
    {
        public static List<Question> GetAllQuestions()
        {
            using (var db = new DB())
            {
                try
                {
                    return db.Questions.Include("Person").Include("QuestionType").ToList();
                }
                catch (Exception e)
                {
                    // TODO: Handle exception
                }
            }
            return null;
        }
        
        public static Question GetSingleQuestion(int ID)
        {
            if (ID >= 0)
            {
                using (var db = new DB())
                {
                    try
                    {
                        return db.Questions.Include("Person").Include("QuestionType").Where(k => k.ID == ID).FirstOrDefault();
                    }
                    catch (Exception e)
                    {
                        // TODO: Handle exception
                    }
                }
            }
            return null;
        }

        public static List<QuestionType> GetAllQuestionTypes()
        {
            using (var db = new DB())
            {
                try
                {
                    return db.QuestTypes.ToList();
                }
                catch (Exception e)
                {
                    // TODO: Handle exception
                }
            }
            return null;
        }

        public static Question GetSingleQuestionType(int ID)
        {
            if (ID >= 0)
            {
                using (var db = new DB())
                {
                    try
                    {
                        return db.Questions.Where(k => k.ID == ID).FirstOrDefault();
                    }
                    catch (Exception e)
                    {
                        // TODO: Handle exception
                    }
                }
            }
            return null;
        }

        public static bool AddQuestion(QuestionData question)
        {
            // ModelState.IsValid
            using (var db = new DB())
            {
                try
                {
                    var questionObj = new Question();
                    questionObj.Quest = question.Quest;
                
                    bool personExists = db.People.Where(p => p.Firstname.Equals(question.Person.Firstname) && p.Lastname.Equals(question.Person.Lastname)).FirstOrDefault() != null;
                    if (!personExists)
                    {
                        var person = new Person();
                        person.Firstname = question.Person.Firstname;
                        person.Lastname = question.Person.Lastname;
                        db.People.Add(person);
                        db.SaveChanges(); // Save changes for fetching person on the next line
                        questionObj.Person = db.People.Where(p => p.Firstname.Equals(question.Person.Firstname) && p.Lastname.Equals(question.Person.Lastname)).FirstOrDefault();
                    }
                    
                    questionObj.QuestionType = db.QuestTypes.Where(q => q.ID == question.QuestionType).FirstOrDefault();
                    db.Questions.Add(questionObj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    // TODO: Handle exception
                }
            }
            return false;
        }

        public static bool AddPerson(Person person)
        {
            using (var db = new DB())
            {
                try
                {
                    db.People.Add(person);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    // TODO: Handle exception
                }
            }
            return false;
        }

        public static List<Person> GetAllPeople()
        {
            using (var db = new DB())
            {
                try
                {
                    return db.People.ToList();
                }
                catch (Exception e)
                {
                    // TODO: Handle exception
                }
            }
            return null;
        }

        public static Person GetSinglePerson(string Firstname, string Lastname)
        {
            using (var db = new DB())
            {
                try
                {
                    return db.People.Where(p => p.Firstname == Firstname && p.Lastname == Lastname).FirstOrDefault();
                }
                catch (Exception e)
                {
                    // TODO: Handle exception
                }
            }
            return null;
        }
    }
    
}