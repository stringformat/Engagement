namespace Engagement.Domain.Common;

public record Name
{
    public const int MAX_LENTH = 50;
    
    public string Value { get; }

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name> Create(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        return value.Length > MAX_LENTH ? 
            CommonErrors.NameTooLongError(MAX_LENTH) : 
            new Name(value);
    }
    
    public static EmptyName Empty => new();
    
    public record EmptyName() : Name(string.Empty);
    
    public static implicit operator string(Name name) => name.Value;
}
