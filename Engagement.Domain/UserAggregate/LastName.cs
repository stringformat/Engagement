namespace Engagement.Domain.UserAggregate;

public record LastName
{
    public string Value { get; }

    private LastName(string value)
    {
        Value = value;
    }

    public static Result<LastName> Create(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        return value.Length > 25 ? Result<LastName>.Failure() : Result<LastName>.Success(new(value));
    }
    
    public static EmptyLastName Empty => new();
    
    public record EmptyLastName() : LastName(string.Empty);
    
    public static implicit operator string(LastName lastName) => lastName.Value;
}