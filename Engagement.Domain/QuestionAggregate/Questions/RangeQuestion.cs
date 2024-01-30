using Engagement.Domain.QuestionAggregate.Answers;
using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Domain.QuestionAggregate.Questions;

public class RangeQuestion : Question
{
    public override ImmutableList<RangeAnswer> Answers { get; }

    public RangeQuestion(Name name, Description description, Order order) 
        : base(name, description, order)
    {
    }
}