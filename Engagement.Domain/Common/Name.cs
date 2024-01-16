namespace Engagement.Domain.Common;

public record Name
{
    public string Value { get; }

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name> Create(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        return value.Length > 50 ? Result<Name>.Failure() : Result<Name>.Success(new(value));
    }
    
    public static EmptyName Empty => new();
    
    public record EmptyName() : Name(string.Empty);
    
    public static implicit operator string(Name name) => name.Value;
}
