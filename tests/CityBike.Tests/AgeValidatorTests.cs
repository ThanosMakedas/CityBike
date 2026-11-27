using CityBike.Core;
using Xunit;

namespace CityBike.Tests;

public class AgeValidatorTests
{
    private readonly AgeValidator _validator = new();
    private readonly DateOnly _today = new(2026, 3, 19);

    [Fact]
    public void IsAdult_Turns18Tomorrow_ReturnsFalse()
    {
        bool isAdult = _validator.IsAdult(new DateOnly(2008, 3, 20), _today);

        Assert.False(isAdult);
    }

    [Fact]
    public void IsAdult_Turns18Today_ReturnsTrue()
    {
        bool isAdult = _validator.IsAdult(new DateOnly(2008, 3, 19), _today);

        Assert.True(isAdult);
    }

    [Fact]
    public void IsAdult_Turned18Yesterday_ReturnsTrue()
    {
        bool isAdult = _validator.IsAdult(new DateOnly(2008, 3, 18), _today);

        Assert.True(isAdult);
    }
}
