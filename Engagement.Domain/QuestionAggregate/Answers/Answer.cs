namespace Engagement.Domain.QuestionAggregate.Answers;

public abstract class Answer : Entity
{
    public Commentary Commentary { get; }

    public User User { get; }

    public DateTimeOffset Date { get; } = DateTimeOffset.UtcNow;

    protected Answer(Commentary commentary, User user)
    {
        Commentary = commentary;
        User = user;
    }

    //ORM
    protected Answer()
    {
    }

    public bool HasCommentary() => Commentary is not EmptyCommentary;
    
    public static EmptyAnswer Ignore(User user) => new(user);
    
    public class EmptyAnswer(User user) : Answer(Commentary.Empty, user);
}