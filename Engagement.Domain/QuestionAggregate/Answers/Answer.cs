using Engagement.Common;

namespace Engagement.Domain.QuestionAggregate.Answers;

public abstract class Answer : Entity
{
    public Commentary Commentary { get; }
    public User User { get; }
    public DateTimeOffset Date { get; } = DateTimeOffset.UtcNow;
    
    public bool HasCommentary => Commentary is not EmptyCommentary;

    public bool IsEmpty => this is EmptyAnswer;

    protected Answer(Commentary commentary, User user)
    {
        Commentary = commentary;
        User = user;
    }

    //ORM
    protected Answer()
    {
    }
    
    public static EmptyAnswer Empty(User user) => new(user);
    
    public class EmptyAnswer(User user) : Answer(Commentary.Empty, user);
}