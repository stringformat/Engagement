namespace Engagement.Domain.QuestionAggregate;

public class Question : Entity, IAggregateRoot
{
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Order Order { get; private set; }
    
    private readonly Collection<Answer> _answers = [];
    public virtual ImmutableList<Answer> Answers => _answers.ToImmutableList();
    
    public Question(Name name, Description description, Order order)
    {
        Name = name;
        Description = description;
        Order = order;
    }
    
    public Result Update(Name name, Description description)
    {
        if(HasAnswers())
            return Result.Failure();
        
        if (name is Name.EmptyName && description is Description.EmptyDescription) 
            return Result.Failure();
        
        if(name is not Name.EmptyName)
            Name = name;
        
        if(description is not Description.EmptyDescription)
            Description = description;
        
        return Result.Success();
    } 

    public void Reorder(Order order)
    {
        Order = order;
    }

    public void Reply(Answer answer)
    {
        ArgumentNullException.ThrowIfNull(answer);

        _answers.Add(answer);
    }

    private bool HasAnswers() => _answers.Count > 0;
}