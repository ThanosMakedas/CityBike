# Regelverkschecklista för CityBike

## GDPR

### G1 Radering av kundens uppgifter
Gäller: Ja
Skäl: Art. 17, kunden har rätt att få uppgifterna raderade.
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Testrapport som visar att kundens uppgifter är borta efter att kontot har stängts.

### G2 Automatisk radering av gamla positioner
Gäller: Ja
Skäl: Art. 5.1 e, positioner får inte sparas längre än de behövs. Se A2.
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Testrapport som visar att positioner äldre än 30 dagar är borta ur testdatabasen.

### G3 Eget konto för varje person i kundtjänst
Gäller: Ja
Skäl: Art. 32, det måste gå att se vem som har öppnat en kunds uppgifter. Se A4.
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp icke-funktionell
Bevis: Testrapport och en del av loggen som visar namnet på den som öppnade kunden.

### G4 Kundtjänst ser inte personnummer
Gäller: Ja
Skäl: Art. 5.1 c, kundtjänst behöver inte personnummer för att hjälpa kunder. Se A5.
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp icke-funktionell
Bevis: Testrapport som visar att svaret från API:et inte innehåller personnummer.

### G5 Inga personuppgifter eller lösenord i loggen
Gäller: Ja
Skäl: Art. 5.1 c och Art. 32, loggen behöver inte personnummer och lösenord. Se A6.
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp icke-funktionell
Bevis: Testrapport och en kopia av loggfilen efter testet.

## CE och produktkrav

### C1 Maskindirektivet 2006/42/EG och maskinförordningen (EU) 2023/1230 för cykeln
Gäller: Ja
Skäl: Maskindirektivet gäller eftersom cykeln har motor. Cykelns tillverkare ansvarar för CE-märkningen, men CityBike måste kontrollera att den finns.
Ansvarig: Inköpsansvarig på CityBike
Verifieras med: Nivå acceptans, testtyp icke-funktionell
Bevis: Cykeltillverkarens EU-försäkran om överensstämmelse och ett foto av CE-märkningen på cykeln.

### C2 Standarden EN 15194 för elcyklar
Gäller: Ja
Skäl: EN 15194 gäller eftersom cykeln är en elcykel med högst 250 W och motorstöd upp till 25 km/h. En cykel som följer standarden anses också följa maskindirektivet i C1.
Ansvarig: Inköpsansvarig på CityBike
Verifieras med: Nivå acceptans, testtyp icke-funktionell
Bevis: Testrapport enligt EN 15194 från cykeltillverkarens provningslaboratorium.

### C3 Radioutrustningsdirektivet 2014/53/EU för styrenhetens mobilmodem
Gäller: Ja
Skäl: RED gäller eftersom styrenheten har mobilmodem och GPS.
Ansvarig: Produktansvarig för styrenheten på CityBike
Verifieras med: Nivå system, testtyp icke-funktionell
Bevis: Testrapport från ett provningslaboratorium, CityBikes EU-försäkran om överensstämmelse och den tekniska dokumentationen.

### C4 Standarden EN 50604-1 och batteriförordningen (EU) 2023/1542 för batteriet
Gäller: Ja
Skäl: EN 50604-1 gäller eftersom cykeln har litiumbatteri.
Ansvarig: Inköpsansvarig på CityBike
Verifieras med: Nivå acceptans, testtyp icke-funktionell
Bevis: Testrapport enligt EN 50604-1 från batteriets tillverkare.

### C5 Elektromagnetisk kompatibilitet
Gäller: Ja
Skäl: EMC gäller eftersom styrenheten har elektronik.
Ansvarig: Produktansvarig för styrenheten på CityBike
Verifieras med: Nivå system, testtyp icke-funktionell
Bevis: EMC-testrapport från ett provningslaboratorium.

## Cyber Resilience Act

### CRA1 Förteckning över komponenter (SBOM)
Gäller: Ja
Skäl: SBOM gäller eftersom styrenheten har firmware.
Ansvarig: Firmware-utvecklare
Verifieras med: Nivå acceptans, testtyp icke-funktionell
Bevis: En SBOM-fil för varje firmwareversion, sparad med versionsnumret.

### CRA2 Säkerhetsuppdateringar av firmware
Gäller: Ja
Skäl: Säkerhetsuppdateringar gäller eftersom firmware uppdateras trådlöst.
Ansvarig: Firmware-utvecklare
Verifieras med: Nivå system, testtyp funktionell
Bevis: Testrapport från testriggen med firmwareversion före och efter uppdateringen.

### CRA3 Hantering av sårbarhetsrapporter
Gäller: Ja
Skäl: CRA3 gäller eftersom CityBike är tillverkare av styrenheten och måste kunna ta emot och åtgärda rapporter om sårbarheter. R11 är en känd sårbarhet: lösenord sparas med SHA-256 utan salt. Den ska hanteras som ett ärende och åtgärdas enligt A13 i 03-gdpr-avvikelser.md.
Ansvarig: Säkerhetsansvarig på CityBike
Verifieras med: Nivå acceptans, testtyp icke-funktionell
Bevis: Ärendelogg med datum för när sårbarheten rapporterades, när den åtgärdades och i vilken version.

## Spårbarhet

### K1 Batteriet får inte överstiga 60 °C vid laddning
Källa: C4
Testfall: Koppla en styrenhet i testriggen till laddning. Låt batterisensorn simulera en temperatur på 61 °C. Mät tiden tills laddningen bryts och tiden tills larmet kommer fram till teknikerna. Gör testet 20 gånger. Laddningen ska brytas inom 5 sekunder och larmet ska komma fram inom 60 sekunder varje gång (se Krav 1 i 01-kvalitetsanalys.md).
Nivå och testtyp: system, icke-funktionell
Resultat som ska sparas: Datum, namn på den som testade, firmwareversion, temperatur, tid till brytning och tid till larm för varje försök och om testet blev godkänt.
Teknisk dokumentation: Testrapporten sparas som PDF i den tekniska dokumentationen för styrenheten, med firmwareversionen i filnamnet.

### K2 Inga personuppgifter eller lösenord i loggen
Källa: G5
Testfall: Starta API:et i testmiljön med loggning på. Registrera en testkund med ett påhittat personnummer och ett påhittat lösenord. Öppna loggfilen och sök efter personnumret och lösenordet. Inget av dem ska finnas i loggen.
Nivå och testtyp: integration, icke-funktionell
Resultat som ska sparas: Datum, namn på den som testade, programversion av API:et, vilka värden som söktes efter, antal träffar i loggen (ska vara 0) och om testet blev godkänt.
Teknisk dokumentation: Testrapporten och en kopia av loggfilen sparas i CityBikes dokumentation för GDPR, med programversionen i filnamnet.

## Kontrollfrågor

1. Varför är CityBike tillverkare av styrenheten, trots att en underleverantör har byggt den?

Svar: CityBike släpper ut styrenheten på marknaden under sitt eget varumärke (avsnitt 7). Då räknas CityBike som tillverkare, även om en underleverantör har byggt den. CityBike äger också firmwaren (avsnitt 3).

2. Vad händer med behovet av testning när CityBike släpper en ny firmwareversion?

Svar: Vi måste testa igen, eftersom ny firmware kan ge nya fel. Testerna, till exempel K1, körs igen med den nya versionen (regressionstest) och resultatet sparas med det nya versionsnumret. En ny SBOM skapas också (CRA1).

3. Vilket fält i spårbarhetsblocket gör att en inspektör kan lita på ett testresultat flera år senare?

Svar: Resultat som ska sparas, eftersom det har firmwareversion och datum. Då vet inspektören exakt vilken version som testades och när. Teknisk dokumentation visar var resultatet finns.
