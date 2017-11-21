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

            var sp_1 = new Question()
            {
                Person = null,
                Quest = "Hvordan kan jeg betale?",
                Answer = "Etter å velge flygninger, og registrere kundedata, vil betalingsvinduet dukke opp."
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
            var sp_4 = new Question()
            {
                Person = null,
                Quest = "Kan jeg fly hvis jeg er gravid?",
                Answer = "Mange kvinner velger å fly under svangerskapet, men det anbefales å snakke med fastlege i forkant av flyturen."
            };
            var sp_5 = new Question()
            {
                Person = null,
                Quest = "Hvor mye bagasje er inkludert i prisen?",
                Answer = "Ett kolli (23 kg) er inkludert i prisen, samt håndbagasje som følger følgende krav: Maks 55x40x23 cm, under 8 kg."
            };
            var sp_6 = new Question()
            {
                Person = null,
                Quest = "Er det lov å ta med seg alkohol i håndbagasjen?",
                Answer = "En kan kun ha med seg forseglet alkohol fra Duty Free, og medbragt alkohol kan ikke konsumeres under flyvning."
            };
            var sp_7 = new Question()
            {
                Person = null,
                Quest = "Hvordan begynner man å jobbe i LuftKlar?",
                Answer = "Enten kan man søke på utløste stillinger, ellers aksepterer vi åpne søknader hele tiden."
            };

            var bestilling = new QuestionCategory()
            {
                Type = "Bestilling",
                Questions = new List<Question>() { sp_1, sp_2 }
            };
            var spesielle_behov = new QuestionCategory()
            {
                Type = "Spesielle behov",
                Questions = new List<Question>() { sp_3, sp_4 }
            };
            var bagasje = new QuestionCategory()
            {
                Type = "Bagasje",
                Questions = new List<Question>() { sp_5, sp_6 }
            };
            var om_selskapet = new QuestionCategory()
            {
                Type = "Om selskapet",
                Questions = new List<Question>() { sp_7 }
            };

            context.People.Add(ola);
            context.People.Add(kari);

            context.Questions.Add(sp_1);
            context.Questions.Add(sp_2);
            context.Questions.Add(sp_3);
            context.Questions.Add(sp_4);
            context.Questions.Add(sp_5);
            context.Questions.Add(sp_6);
            context.Questions.Add(sp_7);

            context.Categories.Add(bestilling);
            context.Categories.Add(spesielle_behov);
            context.Categories.Add(bagasje);
            context.Categories.Add(om_selskapet);

            
            context.SaveChanges();
            base.Seed(context);

        }
    }
}