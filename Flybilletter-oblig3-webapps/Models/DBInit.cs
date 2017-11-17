using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Flybilletter_oblig3_webapps.Models
{
    public class DBInit : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            var ola = new Person()
            {
                Firstname = "Ola",
                Lastname = "Nordmann",
                Email = "ola@nordmann.no"
            };
            var kari = new Person()
            {
                Firstname = "Kari",
                Lastname = "Nordmann",
                Email = "kari@nordmann.no"
            };

            var betaling = new QuestionCategory()
            {
                Type = "Betaling"
            };
            var sykdom = new QuestionCategory()
            {
                Type = "Sykdom"
            };
            var avbestilling = new QuestionCategory()
            {
                Type = "Avbestille"
            };
            var endre = new QuestionCategory()
            {
                Type = "Endre reise"
            };
            var oppgradere = new QuestionCategory()
            {
                Type = "Oppgradere"
            };
            var sjekkeInn = new QuestionCategory()
            {
                Type = "Sjekke inn"
            };

            var sp_1 = new Question()
            {
                Person = null,
                Quest = "Hvordan kan jeg betale?",
                Answer = "Etter å velge flygninger, og registrere kundedata, blir du promptet betalingsvinduet."
            };
            var sp_2 = new Question()
            {
                Person = null,
                Quest = "Hvordan kan jeg avbestille?",
                Answer = "Dersom det er under 48 timer siden bestilling kan en avbestille ved å gå inn på bestillinger og deretter trykke på Avbestill-knappen. Hvis det er over 48 timer siden bestilling fant sted, er det kun administrator som kan avbestille."
            };
            var sp_3 = new Question()
            {
                Person = null,
                Quest = "Kan man fly trygt mens man er forkjølet?",
                Answer = "Ja, for din del gjør det ingenting. Derimot må du tenke på alle andre reisende som du kan smitte."
            };

            context.People.Add(ola);
            context.People.Add(kari);

            context.Categories.Add(betaling);
            context.Categories.Add(sykdom);
            context.Categories.Add(avbestilling);
            context.Categories.Add(endre);
            context.Categories.Add(oppgradere);
            context.Categories.Add(sjekkeInn);

            context.Questions.Add(sp_1);
            context.Questions.Add(sp_2);
            context.Questions.Add(sp_3);
            context.SaveChanges();
            base.Seed(context);

        }
    }
}