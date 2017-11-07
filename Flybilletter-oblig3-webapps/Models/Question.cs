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

        public List<Question> GetAll()
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

        public Question Get(int ID)
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

        public bool Add(Question question)
        {
            // ModelState.IsValid
            using (var db = new DB())
            {
                try
                {
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
    }

    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public List<Person> GetAll()
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

        public Person Get(int ID)
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

        public bool Add(Person person)
        {
            // ModelState.IsValid
            using (var db = new DB())
            {
                try
                {
                    bool exists = db.People.Where(p => p.Firstname == person.Firstname && p.Lastname == person.Lastname).FirstOrDefault() != null;
                    if (!exists)
                    {
                        db.People.Add(person);
                        db.SaveChanges();
                    }
                    return true; // Return true even if person exists. This method is to be used when adding a question
                }
                catch (Exception e)
                {
                    // TODO: Handle exception
                }
            }
            return false;
        }
    }

    public class QuestionType // Has class because this allows to get all questions with of a certain type
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }
    }
    
}