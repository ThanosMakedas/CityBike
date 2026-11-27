# Gränsfall i PriceCalculator

## Värden jag testar

- -1 sekunder: felet ArgumentOutOfRangeException. Precis under 0, negativ tid är inte tillåten.
- 0 sekunder: 10 kr. Bara upplåsningsavgiften (P1).
- 1 sekund: 12,50 kr. Den första sekunden startar en minut (P2).
- 59 sekunder: 12,50 kr. Precis före en hel minut.
- 60 sekunder: 12,50 kr. Exakt en minut, ingen ny minut börjar.
- 61 sekunder: 15 kr. Precis efter en minut, den andra minuten börjar.
- 120 sekunder: 15 kr. Exakt två minuter.
- 121 sekunder: 17,50 kr. Precis efter två minuter, den tredje minuten börjar.
- 5 760 sekunder: 250 kr. 96 minuter ger 10 + 96 × 2,50 = 250 kr, precis på taket (P3).
- 5 761 sekunder: 250 kr. 97 påbörjade minuter ger 252,50 kr, men taket är 250 kr (P3).

## Varför de är intressanta

- Fel uppstår ofta vid en gräns, till exempel när koden avrundar fel.
- 0 visar det lägsta priset (P1).
- 1, 59, 60, 61, 120 och 121 visar om koden räknar påbörjade minuter rätt (P2).
- 5 760 och 5 761 visar om taket fungerar (P3).
- -1 visar att koden stoppar en tid som inte är tillåten.
