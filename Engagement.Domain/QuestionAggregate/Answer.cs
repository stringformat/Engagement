namespace Engagement.Domain.QuestionAggregate;

public class Answer : Entity
{
    public string Value { get; }

    public Commentary Commentary { get; }

    public User Person { get; }

    public DateTimeOffset Date { get; } = DateTimeOffset.UtcNow;

    public Answer(string value, Commentary commentary, User person)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        Value = value;
        Commentary = commentary;
        Person = person;
    }

    private Answer()
    {
    }

    public bool HasCommentary() => Commentary is not Commentary.EmptyCommentary;
}