namespace Engagement.Domain.UserAggregate;

public record FirstName
{
    public string Value { get; }

    private FirstName(string value)
    {
        Value = value;
    }

    public static Result<FirstName> Create(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        return value.Length > 25 ? Result<FirstName>.Failure() : Result<FirstName>.Success(new(value));
    }
    
    public static EmptyFirstName Empty => new();
    
    public record EmptyFirstName() : FirstName(string.Empty);
    
    public static implicit operator string(FirstName firstName) => firstName.Value;
}