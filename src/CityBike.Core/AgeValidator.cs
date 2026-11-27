namespace CityBike.Core;

public class AgeValidator
{
    public const int AdultAge = 18;

    public bool IsAdult(DateOnly birthDate, DateOnly today)
    {
        int age = today.Year - birthDate.Year;

        if (today.Month < birthDate.Month
            || (today.Month == birthDate.Month && today.Day < birthDate.Day))
        {
            age--;
        }

        return age >= AdultAge;
    }
}
