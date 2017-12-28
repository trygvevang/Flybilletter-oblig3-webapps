LuftKlar Kundeservice er en Angular 2 webapplikasjon som snakker med et ASP.NET WEB-API. Denne applikasjonen var tredje og siste obligatoriske innlevering i faget ITPE3200.

Rammeverk som er benyttet:
    - EntityFramework v6.1.3 (Microsoft)
    - jQuery v3.2.1 (jQuery Foundation)
    - bootstrap v3.3.7 (Twitter, inc.)

Anmerkelser:
    - Flere av spørsmålene som seedes er hentet fra www.norwegian.no/hjelp-og-kontakt/
    - Alle tidligere besvarte spørsmål blir vist i "Hjem"-viewet. Brukere har ofte samme/liknende spørsmål, og det er derfor større sjanse for å finne svaret raskt dersom svar publiseres for alle. Å ikke skille mellom brukerstilte spørsmål og spørsmål som seedes fra databasen er et bevisst valg.
    - Når en bruker stiller et spørsmål, vil det kun være synlig fra "Ubesvarte spørsmål"-viewet frem til det blir besvart. Etter spørsmålet er besvart vil det kun være synlig på "Hjem"-viewet. I praksis ville "Ubesvarte spørsmål"-viewet kun vært tilgjengelig av en administrator, da det ikke er hensiktsmessig at brukere får se ubesvarte spørsmål sammen med informasjon om person som stilte spørsmålet, samt mulighet for å besvare.
