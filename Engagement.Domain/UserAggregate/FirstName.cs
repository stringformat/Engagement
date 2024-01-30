namespace Engagement.Domain.UserAggregate;

public record FirstName
{
    public const int MAX_LENTH = 25;
    
    public string Value { get; }

    private FirstName(string value)
    {
        Value = value;
    }

    public static Result<FirstName> Create(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        return value.Length > MAX_LENTH ? 
            UserErrors.FirstNameTooLongError(MAX_LENTH) : 
            new FirstName(value);
    }
    
    public static EmptyFirstName Empty => new();
    
    public record EmptyFirstName() : FirstName(string.Empty);
    
    public static implicit operator string(FirstName firstName) => firstName.Value;
}