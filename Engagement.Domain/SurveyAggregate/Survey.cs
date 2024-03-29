using Engagement.Common;
using Engagement.Domain.QuestionAggregate;

namespace Engagement.Domain.SurveyAggregate;

public class Survey : Entity, IAggregateRoot
{
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public SendingDate SendingDate { get; private set; }
    public Status Status { get; private set; } = Status.Draft;
    
    private readonly ICollection<Question> _questions = [];
    public virtual ImmutableList<Question> Questions => _questions.ToImmutableList();
    
    private readonly ICollection<User> _users = [];
    public virtual ImmutableList<User> Users => _users.ToImmutableList();
    
    public Survey(Name name, Description description, SendingDate sendingDate, IEnumerable<User> users)
    {
        Name = name;
        Description = description;
        SendingDate = sendingDate;
        _users = users.ToList();
    }

    private Survey()
    {
    }

    public Result Update(Name name, Description description)
    {
        if(Status is not Status.Draft)
            return Result.Failure();
        
        if (name is EmptyName && description is EmptyDescription) 
            return Result.Failure();
        
        if(name is not EmptyName)
            Name = name;
        
        if(description is not EmptyDescription)
            Description = description;
        
        return Result.Success();
    }

    public Result Reschedule(SendingDate sendingDate)
    {
        SendingDate = sendingDate;
        
        return Result.Success();
    }

    public Result Open()
    {
        if(Status is not Status.Draft)
            return Result.Failure();
        
        Status = Status.Open;
        
        return Result.Success();
    }

    public Result Close()
    {
        if(Status is not Status.Open)
            return Result.Failure();
        
        Status = Status.Closed;
        
        return Result.Success();
    }

    public void AddQuestion(Question question)
    {
        ArgumentNullException.ThrowIfNull(question);
        
        _questions.Add(question);
    }
}