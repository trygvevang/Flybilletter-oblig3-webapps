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

            var betaling = new QuestionType()
            {
                Type = "Betaling"
            };
            var sykdom = new QuestionType()
            {
                Type = "Sykdom"
            };
            var avbestilling = new QuestionType()
            {
                Type = "Avbestille"
            };
            var endre = new QuestionType()
            {
                Type = "Endre reise"
            };
            var oppgradere = new QuestionType()
            {
                Type = "Oppgradere"
            };
            var sjekkeInn = new QuestionType()
            {
                Type = "Sjekke inn"
            };

            var sp_1 = new Question()
            {
                Person = ola,
                Quest = "Hvordan kan jeg betale?",
                QuestionType = betaling,
                Answer = "Etter å velge flygninger, og registrere kundedata, blir du promptet betalingsvinduet."
            };
            var sp_2 = new Question()
            {
                Person = ola,
                Quest = "Hvordan kan jeg avbestille?",
                QuestionType = avbestilling,
                Answer = "Dersom det er under 48 timer siden bestilling kan en avbestille ved å gå inn på bestillinger og deretter trykke på Avbestill-knappen. Hvis det er over 48 timer siden bestilling fant sted, er det kun administrator som kan avbestille."
            };
            var sp_3 = new Question()
            {
                Person = kari,
                Quest = "Kan man fly trygt mens man er forkjølet?",
                QuestionType = sykdom,
                Answer = "Ja, for din del gjør det ingenting. Derimot må du tenke på alle andre reisende som du kan smitte."
            };

            context.People.Add(ola);
            context.People.Add(kari);

            context.QuestTypes.Add(betaling);
            context.QuestTypes.Add(sykdom);
            context.QuestTypes.Add(avbestilling);
            context.QuestTypes.Add(endre);
            context.QuestTypes.Add(oppgradere);
            context.QuestTypes.Add(sjekkeInn);

            context.Questions.Add(sp_1);
            context.Questions.Add(sp_2);
            context.Questions.Add(sp_3);
            base.Seed(context);

        }
    }
}