using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Flybilletter_oblig3_webapps.Models
{
    public class DB : DbContext
    {
        public DB() : base("name=Questions")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DBInit());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestTypes { get; set; }
    }
}