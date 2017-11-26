LuftKlar Kundeservice er en Angular 2 web applikasjon som snakker med et .net web-api.

Rammeverk som er benyttet:
    - EntityFramework v6.1.3 (Microsoft)
    - jQuery v3.2.1 (jQuery Foundation)
    - bootstrap v3.3.7 (Twitter, inc.)

Anmerkelser:
    - Flere av sp�rsm�lene som seedes er hentet fra www.norwegian.no/hjelp-og-kontakt/
    - Alle tidligere besvarte sp�rsm�l blir vist i "Hjem"-viewet. Brukere har ofte samme/liknende sp�rsm�l, og det er derfor st�rre sjanse for � finne svaret raskt dersom svar publiseres for alle. � ikke skille mellom brukerstilte sp�rsm�l og sp�rsm�l som seedes fra databasen er et bevisst valg.
    - N�r en bruker stiller et sp�rsm�l, vil det kun v�re synlig fra "Ubesvarte sp�rsm�l"-viewet frem til det blir besvart. Etter sp�rsm�let er besvart vil det kun v�re synlig p� "Hjem"-viewet. I praksis ville "Ubesvarte sp�rsm�l"-viewet kun v�rt tilgjengelig av en administrator, da det ikke er hensiktsmessig at brukere f�r se ubesvarte sp�rsm�l sammen med informasjon om person som stilte sp�rsm�let, samt mulighet for � besvare.

Link til applikasjonen:
    http://itpe3200-oblig-luftklar.azurewebsites.net/