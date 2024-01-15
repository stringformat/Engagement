using System.Collections.Immutable;
using System.Collections.ObjectModel;
using Engagement.Common.ResultPattern;
using Engagement.Domain.Common;
using Engagement.Domain.SurveyAggregate;
using Engagement.Domain.UserAggregate;

namespace Engagement.Domain.CampaignAggregate;

public class Campaign : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    private readonly Collection<Survey> _surveys = [];
    public virtual ImmutableList<Survey> Surveys => _surveys.ToImmutableList();
    
    private readonly Collection<User> _populations;
    public virtual ImmutableList<User> Populations => _populations.ToImmutableList();

    public Campaign(string name, string description, Collection<User> populations)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentNullException.ThrowIfNull(populations);
        
        if(populations.Count == 0)
            throw new ArgumentNullException(nameof(populations));
        
        Name = name;
        Description = description;
        _populations = populations;
    }

    public Result Update(string? name, string? description)
    {
        if (name is null && description is null)
            return Result.Failure();

        if (name is not null)
            Name = name;

        if (description is not null)
            Description = description;

        return Result.Success();
    }

    public void AddSurvey(Survey survey)
    {
        ArgumentNullException.ThrowIfNull(survey);

        _surveys.Add(survey);
    }

    public void AddPerson(User person)
    {
        ArgumentNullException.ThrowIfNull(person);
        
        _populations.Add(person);
    }
}