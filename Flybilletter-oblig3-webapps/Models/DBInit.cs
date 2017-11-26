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

            var sp_1_med_svar = new Question()
            {
                Person = null,
                Quest = "Hvordan kan jeg betale?",
                Answer = "Etter å velge flygninger, og registrere kundedata, vil betalingsvinduet dukke opp."
            };
            var sp_2_med_svar = new Question()
            {
                Person = null,
                Quest = "Hvordan kan jeg avbestille?",
                Answer = "Dersom det er under 48 timer siden bestilling kan en avbestille ved å gå inn på bestillinger og deretter trykke på Avbestill-knappen. Hvis det er over 48 timer siden bestilling fant sted, er det kun administrator som kan avbestille."
            };
            var sp_3_med_svar = new Question()
            {
                Person = null,
                Quest = "Kan man fly trygt mens man er forkjølet?",
                Answer = "Ja, for din del gjør det ingenting. Derimot må du tenke på alle andre reisende som du kan smitte."
            };
            var sp_4_med_svar = new Question()
            {
                Person = null,
                Quest = "Kan jeg fly hvis jeg er gravid?",
                Answer = "Mange kvinner velger å fly under svangerskapet, men det anbefales å snakke med fastlege i forkant av flyturen."
            };
            var sp_5_med_svar = new Question()
            {
                Person = null,
                Quest = "Hvor mye bagasje er inkludert i prisen?",
                Answer = "Ett kolli (23 kg) er inkludert i prisen, samt håndbagasje som følger følgende krav: Maks 55x40x23 cm, under 8 kg."
            };
            var sp_6_med_svar = new Question()
            {
                Person = null,
                Quest = "Er det lov å ta med seg alkohol i håndbagasjen?",
                Answer = "En kan kun ha med seg forseglet alkohol fra Duty Free, og medbragt alkohol kan ikke konsumeres under flyvning."
            };
            var sp_7_med_svar = new Question()
            {
                Person = null,
                Quest = "Hvordan begynner man å jobbe i LuftKlar?",
                Answer = "Enten kan man søke på utløste stillinger, ellers aksepterer vi åpne søknader hele tiden."
            };
            var sp_8_med_svar = new Question()
            {
                Person = null,
                Quest = "Når ble LuftKlar etablert?",
                Answer = "LuftKlar ble etablert høsten 2017."
            };
            var sp_9_med_svar = new Question()
            {
                Person = null,
                Quest = "Kan man få kvittering tilsendt i post?",
                Answer = "Nei. LuftKlar gir kvittering elektronisk."
            };
            var sp_10_med_svar = new Question()
            {
                Person = null,
                Quest = "Kan cabin crew medisinere meg under reisen?",
                Answer = "Våre kabinansatte kan ikke hjelpe til med medisinering, eller oppbevare medisin kjølig. Dersom du reiser med medisiner anbefaler vi å pakke den i håndbagasjen samt om mulig i originalemballasjen."
            };
            var sp_11_med_svar = new Question()
            {
                Person = null,
                Quest = "Hva gjør man dersom bagasjen ikke ankommer med flyet?",
                Answer = "Dersom bagasje ikke ankommer må det meldes i fra om så fort som mulig. Når hendelsen er rapportert kan man handle nødvendige varer, så sørger vi for at bagasjen blir returnert til deg ved første anledning."
            };
            var sp_12_med_svar = new Question()
            {
                Person = null,
                Quest = "Hvilke fly har dere?",
                Answer = "Luftklar opererer hovedsakelig med Boeing 737-800 og Airbus A380."
            };
            var sp_13_uten_svar = new Question()
            {
                Person = ola,
                Quest = "Har dere avtale med Hertz eller noen andre aktører som leier ut bil?",
                Answer = null
            };
            var sp_14_uten_svar = new Question()
            {
                Person = kari,
                Quest = "Arrangerer dere charter-turer?",
                Answer = null
            };
            var sp_15_uten_svar = new Question()
            {
                Person = ola,
                Quest = "Hvor mange bagasjer kan man maks sjekke inn?",
                Answer = null
            };
            var sp_16_uten_svar = new Question()
            {
                Person = kari,
                Quest = "Hvor ligger kundeservice-disken deres på Gardemoen?",
                Answer = null
            };

            var bestilling = new QuestionCategory()
            {
                Type = "Bestilling",
                Questions = new List<Question>() { sp_1_med_svar, sp_2_med_svar, sp_9_med_svar, sp_14_uten_svar }
            };
            var spesielle_behov = new QuestionCategory()
            {
                Type = "Spesielle behov",
                Questions = new List<Question>() { sp_3_med_svar, sp_4_med_svar, sp_10_med_svar, sp_13_uten_svar }
            };
            var bagasje = new QuestionCategory()
            {
                Type = "Bagasje",
                Questions = new List<Question>() { sp_5_med_svar, sp_6_med_svar, sp_11_med_svar, sp_15_uten_svar }
            };
            var om_selskapet = new QuestionCategory()
            {
                Type = "Om selskapet",
                Questions = new List<Question>() { sp_7_med_svar, sp_8_med_svar, sp_12_med_svar, sp_16_uten_svar }
            };

            context.People.Add(ola);
            context.People.Add(kari);

            context.Questions.Add(sp_1_med_svar);
            context.Questions.Add(sp_2_med_svar);
            context.Questions.Add(sp_3_med_svar);
            context.Questions.Add(sp_4_med_svar);
            context.Questions.Add(sp_5_med_svar);
            context.Questions.Add(sp_6_med_svar);
            context.Questions.Add(sp_7_med_svar);
            context.Questions.Add(sp_8_med_svar);
            context.Questions.Add(sp_13_uten_svar);
            context.Questions.Add(sp_14_uten_svar);
            context.Questions.Add(sp_15_uten_svar);
            context.Questions.Add(sp_16_uten_svar);

            context.Categories.Add(bestilling);
            context.Categories.Add(spesielle_behov);
            context.Categories.Add(bagasje);
            context.Categories.Add(om_selskapet);

            
            context.SaveChanges();
            base.Seed(context);

        }
    }
}