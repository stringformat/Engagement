namespace Engagement.Domain.QuestionAggregate;

public record Commentary
{
    public string Value { get; }
    
    private Commentary(string value)
    {
        Value = value;
    }

    public static Result<Commentary> Create(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        return value.Length > 250 ? Result<Commentary>.Failure() : Result<Commentary>.Success(new(value));
    }

    public static EmptyCommentary Empty => new();

    public record EmptyCommentary() : Commentary(string.Empty);
    
    public static implicit operator string(Commentary commentary) => commentary.Value;
}