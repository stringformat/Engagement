namespace Engagement.Domain.CampaignAggregate;

public class Campaign : Entity, IAggregateRoot
{
    public Name Name { get; private set; }
    public Description Description { get; private set; }

    private readonly Collection<Survey> _surveys = [];
    public virtual ImmutableList<Survey> Surveys => _surveys.ToImmutableList();

    public Campaign(Name name, Description description)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(description);
        
        Name = name;
        Description = description;
    }
    
    private Campaign()
    {
    }

    public Result Update(Name? name, Description? description)
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
}