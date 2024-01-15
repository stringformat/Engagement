using System.Collections.Immutable;
using System.Collections.ObjectModel;
using Engagement.Common.ResultPattern;
using Engagement.Domain.Common;

namespace Engagement.Domain.QuestionAggregate;

public class Question : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public uint Order { get; private set; }
    
    private readonly Collection<Answer> _answers = [];
    public virtual ImmutableList<Answer> Answers => _answers.ToImmutableList();
    
    public Question(string name, string description, uint order)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        
        Name = name;
        Description = description;
        Order = order;
    }
    
    public Result Update(string? name, string? description)
    {
        if(HasAnswers())
            return Result.Failure();
        
        if (name is null && description is null) 
            return Result.Failure();
        
        if(name is not null)
            Name = name;
        
        if(description is not null)
            Description = description;
        
        return Result.Success();
    } 

    public void Reorder(uint order)
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