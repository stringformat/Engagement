namespace Engagement.Domain.UserAggregate;

public record LastName
{
    public const int MAX_LENTH = 25;
    
    public string Value { get; }

    private LastName(string value)
    {
        Value = value;
    }

    public static Result<LastName> Create(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        return value.Length > MAX_LENTH ? 
            UserErrors.LastNameTooLongError(MAX_LENTH) : 
            new LastName(value);
    }
    
    public static EmptyLastName Empty => new();
    
    public record EmptyLastName() : LastName(string.Empty);
    
    public static implicit operator string(LastName lastName) => lastName.Value;
}