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

1.
2.
3.
4.

## 3. Mätbara krav

### Krav 1:
Krav:
Mått:
Gränsvärde:
Mätmetod:
Hänvisning:

### Krav 2:
Krav:
Mått:
Gränsvärde:
Mätmetod:
Hänvisning:

### Krav 3:
Krav:
Mått:
Gränsvärde:
Mätmetod:
Hänvisning:

### Krav 4:
Krav:
Mått:
Gränsvärde:
Mätmetod:
Hänvisning:

### Uträkning: tillåten nedtid vid 99,7 procent tillgänglighet över 30 dagar

30 dagar = 720 timmar = 43 200 minuter.

Uträkning:
Svar:

