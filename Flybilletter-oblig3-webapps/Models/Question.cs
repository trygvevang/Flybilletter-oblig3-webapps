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

    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

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
                    return db.Questions.ToList();
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

        public static bool AddQuestion(Question question)
        {
            // ModelState.IsValid
            using (var db = new DB())
            {
                try
                {
                    bool personExists = db.People.Where(p => p.Firstname == question.Person.Firstname && p.Lastname == question.Person.Lastname).FirstOrDefault() != null;
                    if (!personExists) db.People.Add(question.Person);
                    db.Questions.Add(question);
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

        public static Person GetSinglePerson(int ID)
        {
            if (ID >= 0)
            {
                using (var db = new DB())
                {
                    try
                    {
                        return db.People.Where(p => p.ID == ID).FirstOrDefault();
                    }
                    catch (Exception e)
                    {
                        // TODO: Handle exception
                    }
                }
            }
            return null;
        }
    }
    
}