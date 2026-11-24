# Testnivåkarta CityBike

## T1
> PriceCalculator returnerar 55 kr för en resa på 18 minuter.

Nivå: enhet
Motivering: Testet kör bara PriceCalculator, utan databas eller nätverk, så fråga fyra gäller.

## T2
> PriceCalculator returnerar 250 kr för en resa på 100 minuter, enligt taket i P3.

Nivå: enhet
Motivering: Testet kör bara PriceCalculator och kollar taket på 250 kr, utan databas eller nätverk, så fråga fyra gäller.

## T3
> Ett anrop som startar en resa körs mot API:et i en testserver tillsammans med en riktig SQL Server-databas, och en ny rad skapas i tabellen Trips.

Nivå: integration
Motivering: Testet kör API:et tillsammans med en riktig databas, så fråga tre gäller.

## T4
> BookingService anropar upplåsningsklienten exakt en gång när bokningen är giltig. Upplåsningsklienten är ersatt av en testdubbel.

Nivå: enhet
Motivering: Upplåsningsklienten är en testdubbel och bara BookingService körs, så fråga fyra gäller.

## T5
> Kundresan körs automatiskt: kundappen (S1) skickar en upplåsningsbegäran via API:et (S3), en simulerad styrenhet svarar och cykeln visas som upplåst inom 3 sekunder.

Nivå: system
Motivering: Hela kedjan körs från appen via API:et till styrenheten, så fråga två gäller.

## T6
> Tre pilotkunder med varsin iPhone registrerar sig, bokar och avslutar en resa utan hjälp. Projektledaren godkänner resultatet.

Nivå: acceptans
Motivering: Projektledaren godkänner resultatet, så fråga ett gäller.

## T7
> Repositoryt för GpsPoints sparar en position och läser tillbaka samma koordinater från en riktig SQL Server-databas.

Nivå: integration
Motivering: Repositoryt arbetar med en riktig databas, så fråga tre gäller.

## T8
> 500 samtidiga användare hämtar kartan mot en driftlik testmiljö. 95:e percentilen av svarstiden ska vara under 2 sekunder.

Nivå: system
Motivering: Hela systemet testas med 500 användare i en driftlik testmiljö, så fråga två gäller.

## T9
> AgeValidator.IsAdult returnerar false för en person som fyller 18 år i morgon. Dagens datum skickas in som parameter.

Nivå: enhet
Motivering: Bara AgeValidator körs och datumet skickas in som parameter, så fråga fyra gäller.

## T10
> Ekonomiansvarig går igenom ett kvitto från testmiljön och godkänner att innehållet och priset stämmer med P1 till P3.

Nivå: acceptans
Motivering: Ekonomiansvarig godkänner kvittot, så fråga ett gäller.

## T11
> Ett anrop till en administratörsfunktion utan inloggning ska ge svaret 401. Testet körs mot API:et i en testserver i samma process, utan att övriga delar startas.

Nivå: integration
Motivering: Testet skickar ett riktigt HTTP-anrop till API:et, så fråga tre gäller.

## T12
> Hela resflödet (registrera, boka, låsa upp, cykla, återlämna och betala) körs i testmiljön med betaltjänstens testläge.

Nivå: system
Motivering: Hela resflödet körs genom alla systemdelar i testmiljön, så fråga två gäller.

## T13
> EmailValidator.IsValid avvisar texten anna@.

Nivå: enhet
Motivering: Testet kör bara EmailValidator, utan databas eller nätverk, så fråga fyra gäller.

## T14
> Kundtjänst går före lansering igenom tolv användarfall i adminpanelen och skriver under ett protokoll.

Nivå: acceptans
Motivering: Kundtjänst godkänner och skriver under, så fråga ett gäller.

## T15
> StationService och databasen tillsammans returnerar rätt antal lediga cyklar för en station med tre cyklar där en är bokad.

Nivå: integration
Motivering: StationService arbetar med databasen men hela kedjan körs inte, så fråga tre gäller.

## T16
> En firmwareuppdatering skickas till 20 styrenheter i en testrigg. Efter uppdateringen låser alla upp och rapporterar position.

Nivå: system
Motivering: Riktiga styrenheter pratar med API:et via mobilnätet, så hela kedjan körs och fråga två gäller.

## Sammanställning

Enhet: 5
Integration: 4
System: 4
Acceptans: 3

Jämförelse med pyramiden: Fördelningen liknar en pyramid eftersom enhetstesterna är flest och acceptanstesterna färst, men den är ganska platt.

## Eget testfall

Krav: Krav 4: Security i docs/01-kvalitetsanalys.md
Givet: Kund A och kund B har varsin resa. Kund A är inloggad.
När: Kund A byter id i adressen till id:t för kund B:s resa.
Då: API:et svarar med HTTP 403 i 100 procent av försöken, och kund A ser inget om kund B:s resa.
Nivå: integration
Testtyp: icke-funktionellt, svartlåda

## Kontrollfrågor

1. En resa på 61 sekunder debiteras 12,50 kr i stället för 15 kr. På vilken nivå hittar du felet billigast, och vilket testfall (T-nummer) ligger närmast att fånga det?

Svar: På enhetsnivå, eftersom felet finns i PriceCalculator. T1 ligger närmast. Men T1 testar 18 hela minuter, så vi behöver ett nytt test med 61 sekunder.

2. Vilket av testfallen T1 till T16 var svårast att placera, och mellan vilka två nivåer tvekade du?

Svar: T9 var svårast. Jag tvekade mellan integration och enhet. Jag tänkte först på att köra appen och läsa loggar, men testet kör bara AgeValidator.IsAdult, så det är ett enhetstest.
