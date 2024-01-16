namespace Engagement.Domain.CampaignAggregate;

public class Campaign : Entity, IAggregateRoot
{
    public Name Name { get; private set; }
    public Description Description { get; private set; }

    private readonly Collection<Survey> _surveys = [];
    public virtual ImmutableList<Survey> Surveys => _surveys.ToImmutableList();
    
    private readonly HashSet<User> _populations;
    public virtual ImmutableHashSet<User> Populations => _populations.ToImmutableHashSet();

    public Campaign(Name name, Description description, HashSet<User> populations)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(description);
        ArgumentNullException.ThrowIfNull(populations);
        
        if(populations.Count == 0)
            throw new ArgumentNullException(nameof(populations));
        
        Name = name;
        Description = description;
        _populations = populations;
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

    public void AddPerson(User person)
    {
        ArgumentNullException.ThrowIfNull(person);
        
        _populations.Add(person);
    }
}