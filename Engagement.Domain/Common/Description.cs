namespace Engagement.Domain.Common;

public record Description
{
    public const int MAX_LENTH = 100;
    public string Value { get; }

    private Description(string value)
    {
        Value = value;
    }

    public static Result<Description> Create(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        return value.Length > MAX_LENTH ? Result<Description>.Failure() : Result<Description>.Success(new(value));
    }
    
    public static EmptyDescription Empty => new();
    
    public record EmptyDescription() : Description(string.Empty);
    
    public static implicit operator string(Description description) => description.Value;
}