using CityBike.Core;
using Xunit;

namespace CityBike.Tests;

public class EmailValidatorTests
{
    private readonly EmailValidator _validator = new();

    [Fact]
    public void IsValid_CorrectEmail_ReturnsTrue()
    {
        bool isValid = _validator.IsValid("anna@stad.se");

        Assert.True(isValid);
    }

    [Theory]
    [InlineData("anna@")]
    [InlineData("anna@.")]
    [InlineData("@stad.se")]
    [InlineData("")]
    public void IsValid_InvalidEmail_ReturnsFalse(string email)
    {
        bool isValid = _validator.IsValid(email);

        Assert.False(isValid);
    }
}
