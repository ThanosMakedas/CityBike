# Kvalitetsanalys CityBike

## 1. Observationer och egenskaper

### K1
> Kartan över lediga cyklar tar 9 sekunder att ladda när 300 användare är inloggade samtidigt.

Egenskap: Performance efficiency
Delegenskap: Time behaviour
Motivering: Kartan är för långsam under belastning (9 sekunder för 300 användare).

### K2
> En kund debiteras två gånger för samma resa när appen skickar betalningsbegäran två gånger vid dålig täckning.

Egenskap: Functional suitability
Delegenskap: Functional correctness
Motivering: Kunden debiteras dubbelt för samma resa utan att veta om det när appen skickar betalningsbegäran två gånger vid dålig täckning. Det är teknisk fel.

### K3
> När en styrenhet tappar mobiltäckning under en resa ska resan fortsätta och positionerna skickas när uppkopplingen kommer tillbaka.

Egenskap: Reliability
Delegenskap: Fault tolerance
Motivering: Resan ska fortsätta trots att styrenheten tappar mobiltäckning samt att positionerna skickas när uppkopplingen kommer tillbaka visar också på Recoverability för det här fallet.

### K4
> Nya kunder hittar inte knappen för att avsluta resan. Kundtjänst får 40 samtal per vecka om det.

Egenskap: Interaction capability
Delegenskap: Learnability
Motivering: Knappen för att avsluta resan är inte tillräckligt ocj tydligt utformad, så nya kunder hittar den inte.

### K5
> Genom att byta id i adressen till en resa kan en inloggad kund se en annan kunds resa.

Egenskap: Security
Delegenskap: Confidentiality
Motivering: En inloggad kund kan se en annan kunds resa och personuppgifter bara genom att byta id i adressen, vilket är en personuppgiftsincident.

### K6
> Prisberäkningen (avsnitt 2) ligger i samma klass som bokningsflödet och ingen utvecklare vågar ändra den.

Egenskap: Maintainability
Delegenskap: Modularity
Motivering: Prisberäkningen ligger i samma klass som bokningsflödet och ingen utvecklare vågar ändra den.

### K7
> Adminpanelen (S2) går inte att använda på surfplattorna som teknikerna har i fält. Knapparna är för små och innehållet går utanför skärmen.

Egenskap: Interaction capability
Delegenskap: Operability
Motivering: Teknikerna kan inte använda adminpanelen på sina surfplattor eftersom knapparna är för små och innehållet går utanför skärmen, vilket också visar brister i flexibility.

### K8
> Om batteritemperaturen i en cykel överstiger 60 grader måste laddningen brytas och ett larm skickas till teknikerna.

Egenskap: Safety
Delegenskap: Operational constraint
Motivering: Laddningen måste brytas när batteritemperaturen överstiger 60 grader så att cykeln inte skadas, och larmet till teknikerna visar också på Hazard warning.

### K9
> API:et (S3) ska kunna ta emot positionsdata både från nuvarande styrenheter och från nästa modell, som skickar ett annat dataformat.

Egenskap: Compatibility
Delegenskap: Interoperability
Motivering: API:et måste kunna ta emot och förstå positionsdata från två olika modeller av styrenheter som skickar olika dataformat.

### K10
> En andra stad vill börja använda systemet. I dag kräver det kodändringar på tolv ställen eftersom stadens namn, priser och zoner står i koden.

Egenskap: Flexibility
Delegenskap: Adaptability
Motivering: Systemet kan inte anpassas till en andra stad utan kodändringar på tolv ställen eftersom stadens namn, priser och zoner står i koden, vilket också visar brister i maintainability i det här fallet.

## 2. De fyra viktigaste egenskaperna för CityBike

1. Safety: om laddningen inte bryts och inget larm skickas när batteritemperaturen överstiger 60 grader kan kunden skadas fysiskt, se K8 och avsnitt 7, och CityBike ansvarar eftersom företaget räknas som tillverkare av styrenheten.
2. Functional suitability: om betalningen inte fungerar korrekt debiteras kunder dubbelt för samma resa, se K2 och avsnitt 2 och 4, vilket ger återbetalningar, fler samtal till kundtjänst och förlorat förtroende.
3. Interaction capability: om nya kunder inte hittar knappen för att avsluta resan får kundtjänst, som har sex anställda, 40 samtal per vecka och kunderna betalar för fler minuter än de har cyklat, se K4 och avsnitt 1 och 2.
4. Security: om en inloggad kund kan se andra kunders resor bara genom att byta id i adressen läcker personuppgifter, se K5 och R4 i avsnitt 6, vilket är en personuppgiftsincident som kan ge sanktionsavgift från IMY.

## 3. Mätbara krav

### Krav 1: Safety
Krav: Laddningen bryts inom 5 sekunder och ett larm om hög batteritemperatur når teknikerna inom 60 sekunder i 100 procent av fallen när batteritemperaturen överstiger 60 grader.
Mått: tid från att temperaturen överstiger 60 grader till att laddningen är bruten, och till att larmet har kommit fram till teknikerna
Gränsvärde: 5 sekunder för brytning av laddning, 60 sekunder för larm, i 100 procent av fallen
Mätmetod: test i testmiljö där batterisensorn i styrenheten får simulera en temperatur över 60 grader, och tiden mäts i 20 upprepade försök
Hänvisning: K8, avsnitt 7

### Krav 2: Functional suitability
Krav: Varje avslutad resa debiteras exakt en gång i 100 procent av fallen, även när samma betalningsbegäran kommer fram upp till 5 gånger på grund av dålig täckning.
Mått: antal debiteringar per avslutad resa
Gränsvärde: exakt 1 debitering per resa, 0 dubbla debiteringar
Mätmetod: test i testmiljö där appen skickar samma betalningsbegäran 5 gånger för 100 testresor, samt en daglig kontroll där alla resor i tabellen Trips jämförs med betaltjänstens transaktioner för att hitta dubbla debiteringar hos alla kunder.
Hänvisning: K2, avsnitt 2, 4 och 5

### Krav 3: Interaction capability
Krav: Minst 90 procent av kunderna, både nya och befintliga, hittar och använder knappen för att avsluta resan inom 10 sekunder utan hjälp, och samtalen till kundtjänst om att avsluta resan minskar från 40 till högst 5 per vecka efter uppdateringen.
Mått: andel testpersoner som avslutar resan utan hjälp inom 10 sekunder, samt antal samtal per vecka till kundtjänst om att avsluta resan
Gränsvärde: minst 90 procent inom 10 sekunder, högst 5 samtal per vecka
Mätmetod: test under 2 veckor med 20 ambassadörer, 10 nya och 10 befintliga kunder, innan den nya versionen lanseras, samt räkning av samtal till kundtjänst under de första 4 veckorna efter lanseringen
Hänvisning: K4, avsnitt 1 och 4

### Krav 4: Security
Krav: När en inloggad kund begär en resa som tillhör en annan kund svarar API:et med ett felmeddelande (HTTP 403 eller 404) i 100 procent av fallen, och kunden kan bara se resor där Trips.UserId är kundens eget Id.
Mått: andel anrop med en annan kunds resa-id som nekas
Gränsvärde: 100 procent nekade anrop, 0 visade resor som tillhör andra kunder
Mätmetod: automatiskt test i testmiljö med en testdatabas med 50 påhittade kunder och 500 resor, där varje testkund försöker hämta alla resor som tillhör de andra kunderna och svaren jämförs med Trips.UserId
Hänvisning: K5, avsnitt 5

### Uträkning: tillåten nedtid vid 99,7 procent tillgänglighet över 30 dagar

30 dagar = 720 timmar = 43 200 minuter.

Uträkning: 100 - 99,7 = 0,3 procent av tiden får vara nedtid. 0,003 × 43 200 = 129,6 minuter.
Svar: Högst 129,6 minuter nedtid är tillåten under 30 dagar, alltså ungefär 2 timmar och 10 minuter.

