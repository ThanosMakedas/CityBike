# GDPR-avvikelser i CityBike

## Personuppgiftsinventering

- Users: Id, Name, Personnummer, Email, Phone, PasswordHash, Status, CreatedAt. Name, Personnummer, Email och Phone är direkt identifierande. Id, PasswordHash, Status och CreatedAt hör till en viss person och är därför också personuppgifter.
- PaymentMethods: UserId, ProviderToken, CardLast4, ExpiryMonth, ExpiryYear. UserId knyter kortet till en person och de andra kolumnerna beskriver den personens betalkort.
- Bikes: Inga personuppgifter. Tabellen har ingen UserId och beskriver bara cykeln.
- Stations: Inga personuppgifter. Name är stationens namn och inte en persons och positionen gäller stationen.
- Trips: Id, UserId, BikeId, StartStationId, EndStationId, StartedAt, EndedAt, PriceSek. UserId knyter resan till en person och de andra kolumnerna visar när, var och till vilket pris den personen har cyklat.
- GpsPoints: Id, TripId, Latitude, Longitude, RecordedAt. TripId kopplar positionen till en resa i Trips och via Trips.UserId till en person. Därför visar tabellen var och när en person har cyklat.

## A1
Rutin: R1
Vad: Personnummer krävs vid registrering trots att syftet kan nås på annat sätt.
Artikel: Art. 5.1 c, dataskyddslagen 3 kap. 10 §
Risk: Hög
Åtgärd: Ta bort kravet. Kontrollera ålder på annat sätt eller ta bara emot födelsedatum.
Testfall: Registrering utan personnummer ska fungera (systemtest).

## A2
Rutin: R2
Vad: Positioner och resor sparas för alltid, fast de inte behövs så länge.
Artikel: Art. 5.1 e
Risk: Hög
Åtgärd: Radera GpsPoints automatiskt 30 dagar efter resan. Spara Trips bara så länge bokföringslagen kräver.
Testfall: Ett program som raderar gamla positioner körs mot en testdatabas. Positioner äldre än 30 dagar ska vara borta (integrationstest).

## A3
Rutin: R3
Vad: Kunden stänger sitt konto, men alla uppgifter finns kvar i databasen.
Artikel: Art. 17
Risk: Hög
Åtgärd: Radera kundens uppgifter när kontot stängs. Resor som behövs för bokföringen sparas utan namn.
Testfall: En testkund stänger sitt konto. Namn, personnummer, e-post och telefon ska vara borta ur databasen (integrationstest).

## A4
Rutin: R4
Vad: Alla i kundtjänst loggar in med samma konto och lösenordet delas i chatten. Ingen vet vem som har gjort vad.
Artikel: Art. 32
Risk: Hög
Åtgärd: Ge varje person ett eget konto med eget lösenord. Spara i en logg vem som öppnar en kunds uppgifter.
Testfall: Det gemensamma kontot ska inte kunna logga in och loggen ska visa namnet på den som öppnar en kund (integrationstest).

## A5
Rutin: R4
Vad: Alla i kundtjänst ser alla kolumner, även personnummer, fast de inte behöver det.
Artikel: Art. 5.1 c
Risk: Hög
Åtgärd: Ge kundtjänst en roll som bara ser de kolumner de behöver. Personnummer visas inte.
Testfall: En användare med kundtjänstrollen öppnar en kund. Personnummer ska inte visas (integrationstest).

## A6
Rutin: R5
Vad: Loggen sparar allt i varje anrop, även personnummer och lösenord som vanlig text.
Artikel: Art. 5.1 c, Art. 32
Risk: Hög
Åtgärd: Skriv inte personuppgifter och lösenord i loggen. Spara loggen i högst 30 dagar.
Testfall: En testkund registrerar sig. Loggfilen ska inte innehålla personnummer eller lösenord (integrationstest).

## A7
Rutin: R6
Vad: Alla kunder får nyhetsbrev med erbjudanden utan att någon har frågat dem.
Artikel: Art. 6, Art. 21
Risk: Låg
Åtgärd: Fråga kunden vid registreringen om hen vill ha nyhetsbrevet. Rutan är tom från början. Varje brev har en länk för att avsluta.
Testfall: En testkund registrerar sig utan att kryssa i rutan. Kunden ska inte få nyhetsbrevet (systemtest).

## A8
Rutin: R7
Vad: Verktyget får kundernas e-post, Id och resor, men det finns inget avtal med leverantören.
Artikel: Art. 28
Risk: Medel
Åtgärd: Skriv ett avtal med leverantören. Skicka bara det som behövs för statistiken, utan e-post.
Testfall: En testresa skickas till verktyget. Anropet ska inte innehålla någon e-postadress (integrationstest).

## A9
Rutin: R7
Vad: Kunduppgifter skickas till USA utan att CityBike har kontrollerat att det är tillåtet.
Artikel: Art. 44
Risk: Medel
Åtgärd: Välj en leverantör som sparar data i EU.
Testfall: Anropen från API:et till verktyget ska gå till en server i EU (integrationstest).

## A10
Rutin: R8
Vad: Ingen konsekvensbedömning har gjorts, fast CityBike sparar positioner för många kunder.
Artikel: Art. 35
Risk: Medel
Åtgärd: Gör en konsekvensbedömning för positioner och personnummer.
Testfall: En jurist läser konsekvensbedömningen och godkänner den (acceptanstest).

## A11
Rutin: R8
Vad: Det finns ingen lista över hur CityBike behandlar personuppgifter.
Artikel: Art. 30
Risk: Låg
Åtgärd: Skriv en lista över alla behandlingar, till exempel registrering, resor, betalning och nyhetsbrev.
Testfall: Den som ansvarar för dataskydd jämför listan med de sex tabellerna och godkänner att allt finns med (acceptanstest).

## A12
Rutin: R8
Vad: Appen har ingen text om personuppgifter, så kunden vet inte vad som händer med uppgifterna.
Artikel: Art. 13
Risk: Medel
Åtgärd: Lägg till en integritetspolicy i appen som visas vid registreringen.
Testfall: En ny kund ser länken till integritetspolicyn innan hen registrerar sig (systemtest).

## A13
Rutin: R11
Vad: Lösenord sparas med SHA-256 utan salt. Samma lösenord ger samma hash och SHA-256 är så snabbt att lösenord kan gissas fram.
Artikel: Art. 32, Art. 5.1 f
Risk: Hög
Åtgärd: Spara lösenord med salt och en långsam hashmetod, till exempel bcrypt eller Argon2.
Testfall: Samma lösenord hashas två gånger och ska ge två olika hashar (enhetstest).

## Rutiner i ordning

Rutin: R9
Bedömning: i ordning. Säkerhetskopior behövs om något går sönder och de sparas bara i 90 dagar.

## Kontrollfrågor

1. Nämn ett giltigt skäl för att använda personnummer enligt dataskyddslagen, och förklara om det skälet gäller CityBikes registrering.

Svar: Ett giltigt skäl är att det är klart motiverat för en säker identifiering, till exempel när en bank ger ett lån. Det gäller inte CityBike, eftersom ålder kan kontrolleras med födelsedatum och påminnelser kan skickas via e-post.

2. Varför räcker det inte att ändra Users.Status till Inactive när en kund vill avsluta sitt konto?

Svar: Med Inactive finns alla uppgifter kvar i databasen, även personnummer. Kunden har rätt att få uppgifterna raderade enligt Art. 17, så de måste raderas.

3. Vilken testnivå har ett test som kontrollerar att en kundtjänstroll inte kan se kolumnen Personnummer? Motivera.

Svar: Integration. Testet skickar ett anrop till API:et med kundtjänstrollen och kör mot en riktig databas, men hela kedjan körs inte.

## Incident R10
Tidpunkt för kännedom: tisdag 3 mars 2026 14:20
Frist för anmälan (datum och klockslag): fredag 6 mars 2026 14:20
Anmäla till IMY: Ja
Informera berörda kunder: Nej
Motivering: Namn, e-post och telefon för 2 100 kunder skickades till ett externt företag. Det är inte osannolikt att det ger en risk, så CityBike ska anmäla till IMY. Risken är inte hög, eftersom inga personnummer, lösenord eller kort skickades och mottagaren är ett företag som kan radera filen. Därför behöver kunderna inte informeras.
Åtgärder för att förhindra upprepning: Kryptera filen innan den skickas. Dubbelkolla mottagaren innan man skickar. I en framtida uppdatering kan systemet själv varna innan en fil med kunduppgifter skickas.
