using Engagement.Domain.QuestionAggregate.Answers;

namespace Engagement.Domain.QuestionAggregate.Questions;

public class MultipleChoiceQuestion : Question
{
    public override ImmutableList<MultipleChoiceAnswer> Answers => [];
    
    private readonly List<Option> _options = [];
    public virtual ImmutableList<Option> Options => _options.ToImmutableList();
    
    private MultipleChoiceQuestion(Name name, Description description, Order order, IEnumerable<Option> options) 
        : base(name, description, order)
    {
        _options.AddRange(options);
    }

    //ORM
    private MultipleChoiceQuestion() { }

    public static Result<MultipleChoiceQuestion> Create(Name name, Description description, Order order, Collection<Option> options)
    {
        if (options.Count is < 1 or > 5)
            return QuestionErrors.MultipleChoiceOptionInvalidCountError;
        
        return new MultipleChoiceQuestion(name, description, order, options);
    }

    public Result<Option> GetOption(Guid id)
    {
        return _options.SingleOrDefault(x => x.Id == id) ?? Result<Option>.Failure();
    }
}