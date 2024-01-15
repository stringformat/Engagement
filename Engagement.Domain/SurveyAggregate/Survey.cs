using System.Collections.Immutable;
using System.Collections.ObjectModel;
using Engagement.Common.ResultPattern;
using Engagement.Domain.Common;
using Engagement.Domain.QuestionAggregate;

namespace Engagement.Domain.SurveyAggregate;

public class Survey : Entity, IAggregateRoot
{
    public string Name { get; private set; }

    public string Description { get; private set; }

    public DateTimeOffset SendingDate { get; private set; }

    public Status Status { get; private set; } = Status.Draft;
    
    private readonly Collection<Question> _questions = [];
    public virtual ImmutableList<Question> Questions => _questions.ToImmutableList();
    
    public Survey(string name, string description, DateTimeOffset sendingDate)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        if (IsBeforeNow(sendingDate))
            ArgumentNullException.ThrowIfNull(sendingDate);
        
        Name = name;
        Description = description;
        SendingDate = sendingDate;
    }
    
    public Result Update(string? name, string? description)
    {
        if(Status is not Status.Draft)
            return Result.Failure();
        
        if (name is null && description is null) 
            return Result.Failure();
        
        if(name is not null)
            Name = name;
        
        if(description is not null)
            Description = description;
        
        return Result.Success();
    }

    public Result Reschedule(DateTimeOffset sendingDate)
    {
        if(IsBeforeNow(sendingDate))
            return Result.Failure();
        
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

    private static bool IsBeforeNow(DateTimeOffset date)
    {
        return date == new DateTimeOffset() && date < DateTimeOffset.UtcNow;
    }
}