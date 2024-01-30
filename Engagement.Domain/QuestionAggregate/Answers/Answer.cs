using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Domain.QuestionAggregate.Answers;

public abstract class Answer : Entity
{
    public Commentary Commentary { get; }

    public User Person { get; }

    public DateTimeOffset Date { get; } = DateTimeOffset.UtcNow;

    protected Answer(Commentary commentary, User person)
    {
        Commentary = commentary;
        Person = person;
    }

    private Answer()
    {
    }

    public bool HasCommentary() => Commentary is not EmptyCommentary;
}