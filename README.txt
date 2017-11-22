LuftKlar Kundeservice er en Angular 2 web applikasjon som snakker med et .net web-api.

Rammeverk som er benyttet:
    - EntityFramework v6.1.3 (Microsoft)
    - jQuery v3.2.1 (jQuery Foundation)
    - bootstrap v3.3.7 (Twitter, inc.)

Anmerkelser:
    - Flere av spørsmålene som seedes er hentet fra www.norwegian.no/hjelp-og-kontakt/
    - Alle tidligere besvarte spørsmål blir vist i viewet på "Hjem"-viewet. Brukere har ofte samme/liknende spørsmål, og det er derfor større sjanse for å finne svaret med det samme dersom svar publiseres for alle. Å ikke skille mellom brukerstilte spørsmål og spørsmål som seedes fra databasen er et bevisst valg.
    - Når en bruker stiller et spørsmål, vil det kun være synlig fra "Ubesvarte spørsmål"-viewet frem til det blir besvart. Etter det er besvart vil spørsmålet kun være synlig på "Hjem"-siden.
    - Besvarelse av spørsmål og liste av ubesvarte spørsmål ville i praksis vært på en side for inlogget bruker, men er ikke implementert da det ikke er relevant for oppgaven.