using CityBike.Core;
using Xunit;

namespace CityBike.Tests;

public class PriceCalculatorTests
{
    private readonly PriceCalculator _calculator = new();

    [Fact]
    public void Calculate_18Minutes_Returns55()
    {
        decimal price = _calculator.Calculate(18 * 60);

        Assert.Equal(55m, price);
    }

    [Fact]
    public void Calculate_0Seconds_ReturnsUnlockFee10()
    {
        decimal price = _calculator.Calculate(0);

        Assert.Equal(10m, price);
    }

    [Fact]
    public void Calculate_100Minutes_ReturnsMaxPrice250()
    {
        decimal price = _calculator.Calculate(6000);

        Assert.Equal(250m, price);
    }

    [Fact]
    public void Calculate_61Seconds_Returns15()
    {
        decimal price = _calculator.Calculate(61);

        Assert.Equal(15m, price);
    }

    [Fact]
    public void Calculate_NegativeSeconds_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Calculate(-1));
    }
}

// Kontrollfrågor
//
// 1. Varför skriver du förväntat värde från kravet i stället för från vad koden returnerar?
// Svar: Kravet säger vad som är rätt. Om värdet tas från koden testar man bara det koden
// redan gör, och felet hittas aldrig.
//
// 2. Varför ska ett test bara ha en Act-del, och vad händer med felsökningen om det har två?
// Svar: Om testet har två Act-delar och blir rött vet man inte vilken av dem som är fel.
// Med en Act-del pekar testet direkt på felet.
//
// 3. Vad hade hänt om du hade skrivit 12,50 som förväntat värde i steg 3?
// Svar: Testet hade blivit grönt fast koden har fel. Då hade felet aldrig hittats.

