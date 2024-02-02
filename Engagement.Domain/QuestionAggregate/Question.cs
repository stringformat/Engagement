using Engagement.Domain.QuestionAggregate.Answers;

namespace Engagement.Domain.QuestionAggregate;

public abstract class Question : Entity, IAggregateRoot 
{
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Order Order { get; private set; }
    
    private readonly Collection<Answer> _answers = [];
    public virtual IEnumerable<Answer> Answers => _answers.ToImmutableList();

    protected Question(Name name, Description description, Order order)
    {
        Name = name;
        Description = description;
        Order = order;
    }

    //ORM
    protected Question() { }

    public Result Update(Name name, Description description)
    {
        if(HasAnswers())
            return QuestionErrors.ImpossibleToUpdateQuestionWithAnswersError;
        
        if (name is EmptyName && description is EmptyDescription) 
            return QuestionErrors.DataRequiredWhenUpdateQuestionError;
        
        if(name is not EmptyName)
            Name = name;
        
        if(description is not EmptyDescription)
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

        if (answer.IsEmpty)
            throw new InvalidOperationException();

        _answers.Add(answer);
    }

    public void Skip(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        
        _answers.Add(Answer.Empty(user));
    }

    private bool HasAnswers() => _answers.Count > 0;
}