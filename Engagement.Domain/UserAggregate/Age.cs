namespace Engagement.Domain.UserAggregate;

public record Age(int Value)
{
    public static Age Create(int age)
    {
        if (age is <= 0 or >= 150)
            throw new Exception();
        
        return new(age);
    }

    public static Age Create(DateOnly birthdate)
    {
        if (birthdate == new DateOnly() || birthdate == DateOnly.MinValue)
            throw new Exception();
        
        return new Age(DateTime.Today.Year - birthdate.Year);
    }

    public static implicit operator int(Age age) => age.Value;
}