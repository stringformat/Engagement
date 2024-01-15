using Engagement.Domain.Common;
using Engagement.Domain.UserAggregate;

namespace Engagement.Domain.QuestionAggregate;

public class Answer : Entity
{
    public string Value { get; }

    public string? Commentary { get; }

    public User Person { get; }

    public DateTimeOffset Date { get; } = DateTimeOffset.UtcNow;

    public Answer(string value, string? commentary, User person)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentNullException.ThrowIfNull(person);
        
        Value = value;
        Commentary = commentary;
        Person = person;
    }

    public bool HasCommentary() => Commentary is not null;

    // public static EmptyAnswer Empty => new();
    //
    // public class EmptyAnswer() : Answer(string.Empty, string.Empty, null);
}