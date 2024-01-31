using Engagement.Domain.QuestionAggregate.Answers;
using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Domain.QuestionAggregate.Questions;

public class MultipleChoiceQuestion : Question
{
    public override ImmutableList<MultipleChoiceAnswer> Answers { get; }
    
    private readonly List<MultipleChoiceOption> _options = [];
    public virtual ImmutableList<MultipleChoiceOption> Options => _options.ToImmutableList();
    
    private MultipleChoiceQuestion(Name name, Description description, Order order, IEnumerable<MultipleChoiceOption> options) 
        : base(name, description, order)
    {
        _options.AddRange(options);
    }

    public static Result<MultipleChoiceQuestion> Create(Name name, Description description, Order order, Collection<MultipleChoiceOption> options)
    {
        if (options.Count is < 1 or > 5)
            return QuestionErrors.MultipleChoiceOptionInvalidCountError;
        
        return new MultipleChoiceQuestion(name, description, order, options);
    }

    public Result<MultipleChoiceOption> GetOption(Guid id)
    {
        return _options.SingleOrDefault(x => x.Id == id) ?? Result<MultipleChoiceOption>.Failure();
    }
}