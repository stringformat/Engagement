namespace Engagement.Domain.QuestionAggregate.ValueObjects;

public record Commentary
{
    public const int MAX_LENTH = 250;
    
    public string Value { get; }
    
    private Commentary(string value)
    {
        Value = value;
    }

    public static Result<Commentary> Create(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        return value.Length > MAX_LENTH ? 
            QuestionErrors.CommentaryTooLongError(MAX_LENTH) : 
            new Commentary(value);
    }

    public static EmptyCommentary Empty => new();

    public record EmptyCommentary() : Commentary(string.Empty);
    
    public static implicit operator string(Commentary commentary) => commentary.Value;
}