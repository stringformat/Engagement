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

    private Question()
    {
    }

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

        _answers.Add(answer);
    }

    private bool HasAnswers() => _answers.Count > 0;
}