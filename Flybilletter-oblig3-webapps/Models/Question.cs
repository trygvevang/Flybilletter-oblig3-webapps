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
        public Person Person { get; set; }
        [Required]
        public string Quest { get; set; }
        public string Answer { get; set; } // If answer == null then it is not answered
    }

    public class QuestionData
    {
        [Required(ErrorMessage = "Person cannot be null")]
        public Person Person { get; set; }
        [RegularExpression(@"^[a-zA-ZøæåØÆÅ .,0-9\n]{2,}[?]$", ErrorMessage = "Question can only be normal characters, be over two characters long, and end with a questionmark.")]
        public string Quest { get; set; }
        [RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Category have to be a number in the range 0-99")]
        public int Category { get; set; } // Question type ID
    }

    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

    }

    public class QuestionCategory // Has class because this allows to get all questions with of a certain type
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }
        public List<Question> Questions { get; set; }
    }

    public static class CRUD
    {
        public static List<Question> GetAllQuestions()
        {
            using (var db = new DB())
            {
                try
                {
                    return db.Questions.Include("Person").ToList();
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
                        return db.Questions.Include("Person").FirstOrDefault(k => k.ID == ID);
                    }
                    catch (Exception e)
                    {
                        // TODO: Handle exception
                    }
                }
            }
            return null;
        }

        public static List<QuestionCategory> GetAllQuestionCategories()
        {
            using (var db = new DB())
            {
                try
                {
                    return db.Categories.Include("Questions.Person").ToList();
                }
                catch (Exception e)
                {
                    // TODO: Handle exception
                }
            }
            return null;
        }

        public static QuestionCategory GetSingleQuestionCategory(int ID)
        {
            if (ID >= 0)
            {
                using (var db = new DB())
                {
                    try
                    {
                        return db.Categories.Include("Questions").FirstOrDefault(k => k.ID == ID);
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
            using (var db = new DB())
            {
                try
                {
                    var questionObj = new Question();
                    questionObj.Quest = question.Quest;
                
                    bool personExists = db.People.FirstOrDefault(p => p.Firstname.Equals(question.Person.Firstname) && p.Lastname.Equals(question.Person.Lastname)) != null;
                    if (!personExists)
                    {
                        var person = new Person();
                        person.Firstname = question.Person.Firstname;
                        person.Lastname = question.Person.Lastname;
                        person.Email = question.Person.Email;
                        db.People.Add(person);
                        db.SaveChanges(); // Save changes for fetching person on the next line
                    }
                    questionObj.Person = db.People.FirstOrDefault(p => p.Firstname.Equals(question.Person.Firstname) && p.Lastname.Equals(question.Person.Lastname));
                    
                    db.Questions.Add(questionObj);
                    db.SaveChanges(); // Save changes before retrieving the question
                    questionObj = db.Questions.FirstOrDefault(q => q.Quest.Equals(question.Quest));
                    var categoryObj = db.Categories.FirstOrDefault(q => q.ID == question.Category);
                    if (categoryObj.Questions == null)
                        categoryObj.Questions = new List<Question>();
                    categoryObj.Questions.Add(questionObj);
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

        public static bool AnswerQuestion(int ID, Question question)
        {
            using (var db = new DB())
            {
                try
                {
                    var foundQuestion = db.Questions.FirstOrDefault(q => q.ID == ID);
                    if (foundQuestion == null || question == null) return false;

                    foundQuestion.Answer = question.Answer;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    // TODO: Handle exception
                    return false;
                }
            }
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
                    return db.People.FirstOrDefault(p => p.Firstname == Firstname && p.Lastname == Lastname);
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